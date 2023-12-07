using HRSystem.BL.DTO.Department;
using HRSystem.BL.Mangers.DepartmentManger;
using HRSystem.BLL.DTO.Department;
using HRSystem.DAL.Data.Models;
using  HRSystem.DAL.Repository.DepartmentRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HRSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDeptManger _deptManger;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public DepartmentController(IDeptManger deptManger)
        {
            _deptManger = deptManger;
            jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                // Other options...
            };
        }

        [HttpPost]
        public ActionResult CreateDept(AddDeptDTO dept )
        {
            Department department = new Department
            {
             Name = dept.Name,

            };
            if (dept != null)
            {
                _deptManger.Insert(department);
                return Created("", dept);
            }
            return BadRequest();
        }

        [HttpGet]
        public ActionResult GetAllDepts()
        {
            var Depts = _deptManger.GetDepartments();
            return Ok(Depts);

        }

        [HttpGet("{id}")]
        public ActionResult GetDeptById(string id)
        {
           var department= _deptManger.GetDepartmentsById(id);
            if (id == null)
            {
                return NotFound();
            }
            var jsonString = JsonSerializer.Serialize(department, jsonSerializerOptions);

            return Content(jsonString, "application/json");


        }

        #region Update

        [HttpPut]
        [Route("Update/{id}")]
        public ActionResult UpdateDept(string id,UpdateDeptDTO DTO)
        {
            if (DTO.Id == id)
            {
                var department = _deptManger.GetDepartmentsById(id);
                if (department != null)
                {
                    department.Name = DTO.name;
                    _deptManger.update(department);

                    return Ok();
                }
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
            _deptManger.delete(id);
            return Ok();

        }

        #endregion
    }
}
