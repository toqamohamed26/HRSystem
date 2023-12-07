using HRSystem.BL.DTO.Employee;
using HRSystem.BLL.DTO.GeneralSettings;
using HRSystem.BLL.DTO.OfficialVocations;
using HRSystem.BLL.Mangers.OfficialVacationManger;
using HRSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HRSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficialVocationsController : ControllerBase
    {
        private readonly IOfficialVacationManger _officialVacationManger;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public OfficialVocationsController(IOfficialVacationManger officialVacationManger)
        {
            jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                // Other options...
            };
            _officialVacationManger = officialVacationManger;
        }

        [HttpGet]
        public IActionResult GetAllVacations()
        {
            var vocations = _officialVacationManger.GetAllVacations();
            return Ok(vocations);
        }


        [HttpPost]
        public IActionResult AddVacations(AddOfficialVocationsDTO OfficialVocations)
        {
            OfficialVocations vocations = new OfficialVocations
            {
                Name = OfficialVocations.Name,
                Date = OfficialVocations.Date,
            };
            if (OfficialVocations != null)
            {
                _officialVacationManger.Insert(vocations);
                return Created("", OfficialVocations);
            }
            return BadRequest();

        }


        #region Get By Id
        [HttpGet]
        [Route("getById/{id}")]
        public ActionResult GetDeptById(string id)
        {
            var Vacation = _officialVacationManger.GetVacationById(id);
            if (id == null)
            {
                return NotFound();
            }
            var jsonString = JsonSerializer.Serialize(Vacation, jsonSerializerOptions);

            return Content(jsonString, "application/json");


        }
        #endregion

        #region Update

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult> UpdateVacation(string id, UpdateOfficialVocationsDTO DTO)
        {
            if (DTO.ID == id)
            {
                var Vacation = _officialVacationManger.GetVacationById(id);
                if (Vacation != null)
                {
                    Vacation.Name = DTO.Name;
                    Vacation.Date = DTO.Date;
                    _officialVacationManger.update(Vacation);
                    return Ok();

                }
                var jsonString = JsonSerializer.Serialize(Vacation, jsonSerializerOptions);

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
            _officialVacationManger.delete(id);
            return Ok();

        }
        #endregion

    }
}
