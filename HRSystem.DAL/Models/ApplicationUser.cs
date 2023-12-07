using Microsoft.AspNetCore.Identity;

namespace HRSystem.DAL.Data.Models
{
    public class ApplicationUser: IdentityUser
    {
        public bool IsDeleted { get; set; }  = false;

    }
}
