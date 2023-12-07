using HRSystem.BL.DTO.Employee;
using HRSystem.BLL.DTO.GeneralSettings;
using HRSystem.BLL.Mangers.GeneralSettingsManger;
using HRSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HRSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralSettingsController : ControllerBase
    {
        private readonly ISettingsManger _settingsManger;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public GeneralSettingsController(ISettingsManger settingsManger)
        {
            jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                // Other options...
            };
            _settingsManger = settingsManger;
        }

        [HttpGet]
        public IActionResult GetAllSettings()
        {
            var Settings = _settingsManger.GetAllSettings();
            return Ok(Settings);
        }

        [HttpPost]
        public IActionResult CreateSettings(AddGeneralSettDTO settings)
        {
            GeneralSettings generalSettings = new GeneralSettings
            {
                Add_hours = settings.Add_hours,
                Sub_hours = settings.sub_hours,
                vacation1 = settings.vacation1,
                vacation2 = settings.vacation2,
            };
            if (settings != null)
            {
                _settingsManger.Insert(generalSettings);
                return Created("", settings);
            }
            return BadRequest();

        }


        #region Get By Id
        [HttpGet]
        [Route("getById/{id}")]
        public ActionResult GetDeptById(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var settings = _settingsManger.GetSettingById(id);
            var jsonString = JsonSerializer.Serialize(settings, jsonSerializerOptions);

            return Content(jsonString, "application/json");


        }
        #endregion

        #region Update

        [HttpPut]
        [Route("Update/{id}")]
        public ActionResult Updatesettings(string id, UpdateSettingsDTO DTO)
        {
            if (DTO.Id == id)
            {
                var settings = _settingsManger.GetSettingById(id);
                if (settings != null)
                {
                    settings.Add_hours = DTO.Add_hours;
                    settings.Sub_hours = DTO.sub_hours;
                    settings.vacation1 = DTO.vacation1;
                    settings.vacation2 = DTO.vacation2;
                  _settingsManger.update(settings);
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
            _settingsManger.delete(id);
            return Ok();

        }

        #endregion

    }
}
