using System.ComponentModel.DataAnnotations;

namespace HRSystem.DAL.Data.Models
{
    public class Group
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Group()
        {
            Id = GenerateUniqueId();
        }
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set;}
        public virtual ICollection<GroupPermissions> GroupPermissions { get; set;}
    }
}
