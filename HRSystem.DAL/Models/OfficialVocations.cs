using System.ComponentModel.DataAnnotations;

namespace HRSystem.DAL.Data.Models
{
    public class OfficialVocations
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public OfficialVocations()
        {
            Id = GenerateUniqueId();
        }
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }

    }
}
