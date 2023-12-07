using HRSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repository.EmpAttendanceReportRepo
{
    public interface IAttendanceReportRepo
    {
        List<Attendance> ReadEmpReportAttendance();
        Attendance GetByID(string id);
        void AddAsync(Attendance attendance);
        void Update (Attendance attendance);
        Task<int> SaveChangesAsync();
        Task SaveExcelData(IEnumerable<Attendance> attendances);


    }
}
