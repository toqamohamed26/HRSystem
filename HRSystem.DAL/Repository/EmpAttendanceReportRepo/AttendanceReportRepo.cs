using HRSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repository.EmpAttendanceReportRepo
{
    public class AttendanceReportRepo:IAttendanceReportRepo
    {
        HREntity context;
        public AttendanceReportRepo
            (HREntity context)
        {
            this.context = context;

        }

        public List<Attendance> ReadEmpReportAttendance()
        {
            var res = context.Attendances.Include(a => a.Employee).ThenInclude(e => e.Department).Where(a => a.IsDeleted != true);
            return res.ToList();
        }

        public Attendance GetByID(string id)
        {
            return context.Attendances.Include(a => a.Employee).ThenInclude(e => e.Department).FirstOrDefault(a => a.Id == id && a.IsDeleted != true);
        }

        public void AddAsync(Attendance Attendance)
        {
             context.AddAsync(Attendance);
            context.SaveChanges();
        }

        public void Update(Attendance attendance)
        {
             context.Update(attendance);
            context.SaveChanges();
        }

    

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task SaveExcelData(IEnumerable<Attendance> attendances)
        {
            await context.Attendances.AddRangeAsync(attendances);
            await context.SaveChangesAsync();
        }

      
    }
}
