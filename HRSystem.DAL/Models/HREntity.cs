using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HRSystem.DAL.Data.Models
{
    public class HREntity :IdentityDbContext<ApplicationUser>
    {
        public HREntity(DbContextOptions<HREntity> options) 
            : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<GeneralSettings> GeneralSettings { get; set; }
        public DbSet<GroupPermissions> GroupPermissions { get; set; }
        public DbSet<OfficialVocations> OfficialVocations { get; set; }
        public DbSet<Permissions> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                     .HasDiscriminator<string>("UserType")
                     .HasValue<User>("User")
                     .HasValue<Employee>("Employee");


            modelBuilder.Entity<GroupPermissions>()
                .HasKey(ea => new { ea.GroupID, ea.PermissionID });
        }

        
    }
}
