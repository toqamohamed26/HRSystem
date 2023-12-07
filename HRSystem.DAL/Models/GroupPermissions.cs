using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.DAL.Data.Models
{
    public class GroupPermissions
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public GroupPermissions()
        {
            GroupID = GenerateUniqueId();
            PermissionID = GenerateUniqueId();
        }
        [Key]
        public string GroupID { get; set; }
        [Key]
        public string PermissionID { get; set; }
        public bool Add { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }

        [ForeignKey("GroupID")]
        public virtual Group Group { get; set; }

        [ForeignKey("PermissionID")]
        public virtual Permissions Permissions { get; set; }


    }
}
