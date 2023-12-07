using HRSystem.BL.DTO.Register;
using HRSystem.BLL.DTO.Users;
using HRSystem.BLL.Mangers.UserManger;
using HRSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace HR_System.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserManger _userClientManger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public UsersController(IConfiguration configuration,
            UserManager<ApplicationUser> userManager ,
                IUserManger userMangerr
             )
        {

            jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                // Other options...
            };
            _userManager = userManager;
            _config = configuration;
            _userClientManger = userMangerr;

        }
        #region Register

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterUserDTO registerDto)
        {
            ApplicationUser user = new User
            {
                UserName = registerDto.UserName,
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                GroupID = registerDto.Group,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, "user"),
        };
            await _userManager.AddClaimsAsync(user, claims);

            return Ok();
        }

        #endregion


        #region GetAll

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            List<AllUsersDTO> User = new List<AllUsersDTO>();
            foreach (var item in _userClientManger.GetAllUsers())
            {
                AllUsersDTO e = new AllUsersDTO();
                e.ID = item.Id;
                e.username = item.UserName;
                e.fullname = item.FullName;
                e.email = item.Email;
                e.Permissions = item.Group.Name;
              

                User.Add(e);
            }
            return Ok(User);

        }
        #endregion

        #region Get By Id
        [HttpGet]
        [Route("getById/{id}")]
        public ActionResult GetUserById(string id)
        {
            var user = _userClientManger.GetUserById(id);
            if (id == null)
            {
                return NotFound();
            }
            var jsonString = JsonSerializer.Serialize(user, jsonSerializerOptions);

            return Content(jsonString, "application/json");


        }
        #endregion

        #region Update

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult> UpdateUser(string id, AllUsersDTO DTO)
        {
            if (DTO.ID == id)
            {
                var user = _userClientManger.GetUserById(id);
                if (user != null)
                {
                    user.UserName = DTO.username;
                    user.FullName = DTO.fullname;
                    //user.Permissions = DTO.Permissions;
                    user.Email = DTO.email;

                    _userClientManger.update(user);

                    return Ok();

                }
                var jsonString = JsonSerializer.Serialize(user, jsonSerializerOptions);

                return Content(jsonString, "application/json");
            }

            return BadRequest();

        }


        #endregion

        #region Delete
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _userClientManger.delete(id);
            return Ok();

        }

        #endregion

    }
}
