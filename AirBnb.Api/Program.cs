using AirBnb.BL.AutoMapper;
using AirBnb.BL.Emails.Services;
using AirBnb.BL.Emails.Settings;
using AirBnb.BL.Managers.ManageEmployee;
using AirBnb.BL.Managers.ManageUser;
using AirBnb.DAL.Data.Context;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Non_Generic.PersonRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.Api
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Email Configuration-Fnagily
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("MailSettings"));
            builder.Services.AddTransient<IEmailService, EmailService>();

            #endregion

            #region Context class Configuration-Fnagily
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region Identity Class Configuration-Fnagily
            builder.Services.AddIdentity<Employee, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                
                options.Password.RequireNonAlphanumeric = false;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            #endregion

            #region Special Repos-Fnagily
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            #endregion

            #region AutoMapper Configuration-WholeTeam
                builder.Services.AddAutoMapper(typeof(AutoMapperProfiler).Assembly);
            #endregion

            #region Managers Configs-Whole Team
            builder.Services.AddScoped<IUserManager, UserManage>();
            builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();
            
            #endregion

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();



            app.MapControllers();

            app.Run();
        }
    }
}