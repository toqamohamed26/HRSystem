using HRSystem.BL.DTO.Employee;
using HRSystem.BLL.DTO.AttendanceReport;
using HRSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.Mangers.EmpAttendanceReportManger
{
    public interface IAttendanceReportManger
    {
        IEnumerable<ReadAttendanceReportDTO> ReadEmpReportAttendance();
        int AddAttendanceReport(AddAttendanceReportDTO reportDTO);
        void UpdateAttendanceReport(UpdateAttendanceReportDTO UpdatereportDTO);
        void Delete(string id);
        AttendanceByIdDTO GetAttendanceById(string id);
        void SaveExcelData(List<UpdateAttendanceReportDTO> excelDataList);
        List<ReadAttendanceReportDTO> GetByName(string name);
        List<ReadAttendanceReportDTO> GetByDate(DateTime date1, DateTime date2);

    }
}
