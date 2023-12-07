using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.DTO.AttendanceReport
{
    public class AttendanceByIdDTO
    {
        public string Id { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan CheckOut { get; set; }
        public DateTime Date { get; set; }
        public string DeptId { get; set; }
        public string EmpId { get; set; }
    }
}
