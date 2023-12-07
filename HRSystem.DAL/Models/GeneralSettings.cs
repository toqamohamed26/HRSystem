using System.ComponentModel.DataAnnotations;

namespace HRSystem.DAL.Data.Models
{
    public class GeneralSettings
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public GeneralSettings()
        {
            ID = GenerateUniqueId();
        }
        [Key]
        public string ID { get; set; }
        public int Add_hours { get; set; }
        public int Sub_hours { get; set; }
        public string vacation1 { get; set;}
        public string vacation2 { get; set; }
        public bool IsDeleted { get; set; }



    }
}
