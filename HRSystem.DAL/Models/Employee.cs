using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.DAL.Data.Models
{
    public class Employee: ApplicationUser
    {
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string NationalID { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }
        public double Salary { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime HireDate { get; set; }
        public TimeSpan? Attendance { get; set; }
        public TimeSpan? CheckOut { get; set;}

        [ForeignKey(nameof(Department))]
        public string DeptID { get; set; }
        public virtual Department? Department { get; set; }
        public virtual ICollection<Attendance> Attendences { get; set; } = new List<Attendance>();

    }
}
