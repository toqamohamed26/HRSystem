
using HRSystem.BL.Mangers.DepartmentManger;
using HRSystem.BLL.Mangers.EmpAttendanceReportManger;
using HRSystem.BLL.Mangers.EmpManger;
using HRSystem.BLL.Mangers.GeneralSettingsManger;
using HRSystem.BLL.Mangers.GroupManger;
using HRSystem.BLL.Mangers.OfficialVacationManger;
using HRSystem.BLL.Mangers.UserManger;
using HRSystem.DAL.Data.Models;
using HRSystem.DAL.Repository.DepartmentRepo;
using HRSystem.DAL.Repository.EmpAttendanceReportRepo;
using HRSystem.DAL.Repository.EmployeeRepo;
using HRSystem.DAL.Repository.GeneralSettingsRepo;
using HRSystem.DAL.Repository.OfficialVacationRepo;
using HRSystem.DAL.Repository.UserRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace HRSystem.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Database 

            var ConnectionString = builder.Configuration.GetConnectionString("HREntity");
            builder.Services.AddDbContext<HREntity>(options =>
            options.UseSqlServer(ConnectionString)
            );
            #endregion

            #region IdentityMangers and Repos

            builder.Services
                .AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 5;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<HREntity>();
            builder.Services.AddScoped<IDeptRepo, DeptRepo>();
            builder.Services.AddScoped<IEmpRepo, EmpRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IGeneralSettRepo, GeneralSettRepo>();
            builder.Services.AddScoped<IOfficialVacationRepo, OfficialVacationRepo>();
            builder.Services.AddScoped<IAttendanceReportRepo, AttendanceReportRepo>();

            #endregion

            #region Authentication Scheme

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Cool";
                options.DefaultChallengeScheme = "Cool";
            })
            .AddJwtBearer("Cool", options =>
            {
                var secretKeyString = builder.Configuration.GetValue<string>("SecretKey");
                var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
                var secretKey = new SymmetricSecurityKey(secretyKeyInBytes);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = secretKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            #endregion

            #region Policies
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy
                    .RequireClaim(ClaimTypes.Role, "User")
                    .RequireClaim(ClaimTypes.NameIdentifier));

                options.AddPolicy("Employee", policy => policy
                     .RequireClaim(ClaimTypes.Role, "Employee")
                     .RequireClaim(ClaimTypes.NameIdentifier));
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
            #endregion

            #region Mangers

            builder.Services.AddScoped<IDeptManger, DeptManger>();
            builder.Services.AddScoped<IEmpManger, EmpManger>();
            builder.Services.AddScoped<IUserManger, UserManger>();
            builder.Services.AddScoped<ISettingsManger, SettingsManger>();
            builder.Services.AddScoped<IOfficialVacationManger, OfficialVacationManger>();
            builder.Services.AddScoped<IAttendanceReportManger, AttendanceReportManger>();


            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}