using System.ComponentModel.DataAnnotations;

namespace HRSystem.DAL.Data.Models
{
    public class Department
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Department()
        {
            Id = GenerateUniqueId();
        }
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } 
    }
}
