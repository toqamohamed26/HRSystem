using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.DTO.AttendanceReport
{
    public class AddAttendanceReportDTO
    {
        public string EMP_Id { get; set; }
        public TimeSpan? checkIn { get; set; }
        public TimeSpan? CheckOut { get; set; }
        public DateTime Date { get; set; }
    }
}
