using HRSystem.BLL.DTO.AttendanceReport;
using HRSystem.BLL.Mangers.EmpAttendanceReportManger;
using HRSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace HRSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceReportController : ControllerBase
    {
        private readonly IAttendanceReportManger _reportManger;
        public AttendanceReportController(IAttendanceReportManger reportManger)
        {
            _reportManger = reportManger;
        }

        [HttpGet]
        public ActionResult ReadReport()
        {
            var Report = _reportManger.ReadEmpReportAttendance();
            return Ok(Report);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var attendance = _reportManger.GetAttendanceById(id);
            if (attendance != null)
            {
                return Ok(attendance);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddAttendanceReport(AddAttendanceReportDTO reportDTO)
        {
            var res = _reportManger.AddAttendanceReport(reportDTO);
            if (res == 1)
            {
                if (ModelState.IsValid == true)
                {
                    return Ok();
                }
                return BadRequest();
            }
            else
            {
                if (ModelState.IsValid == true)
                {
                    var sentence = new { Message = "AddedBefore" };

                    return Ok(sentence);
                }
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        public ActionResult Update(UpdateAttendanceReportDTO Attendance)
        {
            _reportManger.UpdateAttendanceReport(Attendance);
            if (ModelState.IsValid == true) { return Ok(); }
            return BadRequest();
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                _reportManger.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //[HttpPost("Upload")]
        //public IActionResult Upload(IFormFile file)
        //{
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //    try
        //    {
        //        using (var package = new ExcelPackage(file.OpenReadStream()))
        //        {
        //            var worksheet = package.Workbook.Worksheets[0]; // Assuming the data is on the first sheet
        //            var rowCount = worksheet.Dimension.Rows;

        //            var excelDataList = new List<AttendanceInsertDto>();

        //            for (int row = 1; row <= rowCount; row++) // Start from row 2 to skip the header row
        //            {
        //                var dto = new AttendanceInsertDto()
        //                {
        //                    EMPId = int.Parse(worksheet.Cells[row, 1].Value?.ToString()),
        //                    CheckIn = TimeSpan.Parse(worksheet.Cells[row, 2].Value?.ToString()),
        //                    CheckOut = TimeSpan.Parse(worksheet.Cells[row, 3].Value?.ToString()),
        //                    Date = DateTime.Parse(worksheet.Cells[row, 4].Value?.ToString())
        //                };

        //                excelDataList.Add(dto);
        //            }

        //            _attendenceRepository.SaveExcelData(excelDataList);

        //            return Ok();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any exceptions that occurred during file processing
        //        return BadRequest("An error occurred: " + ex.Message);
        //    }
        //}

        [HttpGet("name")]
        public IActionResult GetbyNAme(string name)
        {
            var emps = _reportManger.GetByName(name);
            if (emps != null)
            {
                return Ok(emps);
            }
            return BadRequest();
        }

        [HttpGet("date")]
        public IActionResult GetbyDate(string d1, string d2)
        {
            var date1 = Convert.ToDateTime(d1);
            var date2 = Convert.ToDateTime(d2);

            var emps = _reportManger.GetByDate(date1, date2);
            if (emps != null)
            {
                return Ok(emps);
            }
            return BadRequest();
        }
    }
}
