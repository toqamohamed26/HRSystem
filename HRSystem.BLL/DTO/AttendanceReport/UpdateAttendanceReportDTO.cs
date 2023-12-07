using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BLL.DTO.AttendanceReport
{
    public class UpdateAttendanceReportDTO
    {
        public string ID { get; set; }
        public string EMP_Id { get; set; }
        public TimeSpan? CheckIn { get; set; }
        public TimeSpan? CheckOut { get; set; }
        public DateTime Date { get; set; }
    }
}
