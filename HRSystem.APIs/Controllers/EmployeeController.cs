using HRSystem.BL.DTO.Department;
using HRSystem.BL.DTO.Employee;
using HRSystem.BL.DTO.RegisterDTO;
using HRSystem.BLL.Mangers.EmpManger;
using HRSystem.DAL.Data.Models;
using  HRSystem.DAL.Repository.EmployeeRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HRSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _config;
        IEmpManger _empManger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public EmployeeController(IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            IEmpManger empManger
             )
        {
            jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                // Other options...
            };
            _userManager = userManager;
            _config = configuration;
            _empManger = empManger;

        }
        #region Register

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterEmployeeDTO registerDto)
        {
            ApplicationUser employee = new Employee
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.Phone,
                Address = registerDto.Address,
                Gender = registerDto.Gender,
                Nationality = registerDto.Nationality,
                NationalID = registerDto.NationalID,
                Salary = registerDto.Salary,
                HireDate = registerDto.HireDate,
                Attendance = registerDto.Attendance,
                CheckOut = registerDto.CheckOut,
                DeptID = registerDto.Department
            };

            var result = await _userManager.CreateAsync(employee, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, employee.Id),
            new Claim(ClaimTypes.Name, employee.UserName),
            new Claim(ClaimTypes.Role, "Employee"),
        };
            await _userManager.AddClaimsAsync(employee, claims);

            return Ok();
        }

        #endregion


        #region GetAll
        [HttpGet]
        public ActionResult<IEnumerable<AllEmployeesDTO>> GetAllEmp()
        {
           return _empManger.GetAllEmp().ToList();

        }
        #endregion

        #region Get By Id
        [HttpGet]
        [Route("getById/{id}")]
        public ActionResult GetEmpById(string id)
        {
            var employee = _empManger.GetEmployeeById(id);
            if (id == null)
            {
                return NotFound();
            }
            var jsonString = JsonSerializer.Serialize(employee, jsonSerializerOptions);

            return Content(jsonString, "application/json");


        }
        #endregion

        #region Update

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult> UpdateEmp(string id, AllEmployeesDTO DTO)
        {
            if (DTO.Id == id)
            {
                var employee = _empManger.GetEmployeeById(id);
                if (employee != null)
                {
                    employee.UserName = DTO.UserName;
                    employee.PhoneNumber = DTO.Phone;
                    employee.Email = DTO.email;
                    employee.Address = DTO.Address;
                    employee.Department.Name = DTO.Department;
                    employee.Attendance = DTO.Attendance;
                    employee.Nationality = DTO.Nationality;
                    employee.Gender = DTO.Gender;
                    employee.BirthDate = DTO.BirthDate;
                    employee.HireDate = DTO.HireDate;
                    employee.NationalID = DTO.NationalID;
                    employee.CheckOut = DTO.CheckOut;
                   _empManger.update(employee);

                    return Ok();
                    
                }
                var jsonString = JsonSerializer.Serialize(employee, jsonSerializerOptions);

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
            _empManger.delete(id);
            return Ok();

        }

        #endregion


        #region Get Emp By Dept Id

        [HttpGet("ByDepartment/{DeptID}")]
        public IActionResult GetByDeptID(string DeptID)
        {
            var employees =_empManger.GetEmpByDeptID(DeptID);
            if (employees != null)
            {
                return Ok(employees);
            }
            return BadRequest();
        }
        #endregion


    }
}
