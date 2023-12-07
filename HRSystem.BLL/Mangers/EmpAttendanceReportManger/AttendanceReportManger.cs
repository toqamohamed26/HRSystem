using HRSystem.BL.DTO.Employee;
using HRSystem.BLL.DTO.AttendanceReport;
using HRSystem.DAL.Data.Models;
using HRSystem.DAL.Repository.EmpAttendanceReportRepo;
using HRSystem.DAL.Repository.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.Mangers.EmpAttendanceReportManger
{
    public class AttendanceReportManger : IAttendanceReportManger
    {
        private readonly IAttendanceReportRepo _attendanceReportRepo;
        private readonly IEmpRepo _empRepo;

        public AttendanceReportManger(IAttendanceReportRepo attendanceReportRepo , IEmpRepo empRepo) 
        {
            this._attendanceReportRepo = attendanceReportRepo;
            this._empRepo = empRepo;
        }

        public int AddAttendanceReport(AddAttendanceReportDTO reportDTO)
        {
            var Attendance = new Attendance
            {
                Date = reportDTO.Date,
                CheckOut = reportDTO.CheckOut,
                CheckIn= reportDTO.checkIn,
                EMPId=reportDTO.EMP_Id,
                
            };
            var all = ReadEmpReportAttendance();
            foreach (var attendance in all)
            {

                if (attendance.Emp_Name==(_empRepo.GetbyId(Attendance.EMPId).UserName)&& (_empRepo.GetbyId(Attendance.EMPId).IsDeleted) != true && Attendance.Date.Date == Attendance.Date.Date)
                  {
                     return 0;

                  }
            }
            _attendanceReportRepo.AddAsync(Attendance);
            return 1;

        }

        public IEnumerable<ReadAttendanceReportDTO> ReadEmpReportAttendance()
        {
            IEnumerable<Attendance> FromDB = _attendanceReportRepo.ReadEmpReportAttendance();
            return FromDB.Select(attendance => new ReadAttendanceReportDTO()
            {
                ID = attendance.Id,
                Emp_Name= attendance.Employee.UserName,
                Dept=attendance.Employee.Department.Name,
                CheckIn = attendance.CheckIn,
                CheckOut = attendance.CheckOut,
                Date=attendance.Date,
            }).ToList();

        }
        public AttendanceByIdDTO GetAttendanceById(string id)
        {
            var attendance =_attendanceReportRepo.GetByID(id);
            var AttDto = new AttendanceByIdDTO();
            AttDto.Id = id;
            AttDto.DeptId = attendance.Employee.Department.Id;
            AttDto.CheckOut = (TimeSpan)attendance.CheckOut;
            AttDto.CheckIn = (TimeSpan)attendance.CheckIn;
            AttDto.Date = attendance.Date;
            AttDto.EmpId = attendance.Employee.Id;
            return (AttDto);

        }

        public void UpdateAttendanceReport(UpdateAttendanceReportDTO UpdatereportDTO)
        {
            var Attendance = new Attendance
            {
                Id = UpdatereportDTO.ID,
                Date = UpdatereportDTO.Date,
                CheckIn = UpdatereportDTO.CheckIn,
                CheckOut = UpdatereportDTO.CheckOut,
                EMPId = UpdatereportDTO.EMP_Id,
            };
             _attendanceReportRepo.Update(Attendance);
        }

        public void Delete(string id)
        {
            var OldAttendance = _attendanceReportRepo.GetByID(id);
            if (OldAttendance != null)
            {
                OldAttendance.IsDeleted = true;
                _attendanceReportRepo.SaveChangesAsync();

            }
        }

        public void SaveExcelData(List<UpdateAttendanceReportDTO> excelDataList)
        {
            var entities = excelDataList.Select(dto => new Attendance()
            {
                EMPId = dto.ID,
                CheckIn = dto.CheckIn,
                CheckOut = dto.CheckOut,
                Date = dto.Date
            }).ToList();

            _attendanceReportRepo.SaveExcelData(entities);
        }

        public List<ReadAttendanceReportDTO> GetByName(string name)
        {
            var att = ReadEmpReportAttendance();
            return att.Where(e => e.Emp_Name.Contains(name)).ToList();

        }

        public List<ReadAttendanceReportDTO> GetByDate(DateTime date1, DateTime date2)
        {
            var Attendances = ReadEmpReportAttendance();

            return Attendances.Where(e => e.Date >= date1 && e.Date <= date2).ToList();
        }

    }
}
