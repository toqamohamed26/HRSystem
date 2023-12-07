using System.ComponentModel.DataAnnotations;

namespace HRSystem.DAL.Data.Models
{
    public class Permissions
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Permissions()
        {
            Id = GenerateUniqueId();
        }
        [Key]
        public string Id { get; set; }
        public bool UserPage { get; set; }
        public bool EmployeePage { get; set; }
        public bool DepartmentPage { get; set; }
        public bool GeneralSettingsPage { get; set; }
        public bool SalaryReportPage { get; set; }
        public bool AttendancePage { get; set; }
        public virtual ICollection<GroupPermissions> GroupPermissions { get; set; }






    }
}
