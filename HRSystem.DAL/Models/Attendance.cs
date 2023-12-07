using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.DAL.Data.Models
{
    public class Attendance
    {

        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Attendance()
        {
            Id = GenerateUniqueId();
        }
        [Key]
        public string Id { get; set; }
        public TimeSpan? CheckIn { get; set; }
        public TimeSpan? CheckOut { get; set; }

        public DateTime Date { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(Employee))]
        public string EMPId { get; set; }
        public virtual Employee Employee { get; set; }



    }
}
