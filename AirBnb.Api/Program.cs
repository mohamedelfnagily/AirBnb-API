using AirBnb.BL.AutoMapper;
using AirBnb.BL.Emails.Services;
using AirBnb.BL.Emails.Settings;
using AirBnb.BL.Helpers;
using AirBnb.BL.Managers.ManageAuthentication;
using AirBnb.BL.Managers.ManageEmployee;
using AirBnb.BL.Managers.ManageUser;
using AirBnb.DAL.Data.Context;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Non_Generic.PersonRepo;
using AirBnb.DAL.Repository.Non_Generic.PropertyRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            //builder.Services.AddIdentity<Employee, IdentityRole>(options =>
            //{
            //    options.User.RequireUniqueEmail = true;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Lockout.MaxFailedAccessAttempts = 3;
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            //}).AddEntityFrameworkStores<ApplicationDbContext>();
            //builder.Services.AddIdentity<User, IdentityRole>(options =>
            //{
            //    options.User.RequireUniqueEmail = true;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Lockout.MaxFailedAccessAttempts = 3;
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            //}).AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddIdentityCore<Employee>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddIdentityCore<User>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            #endregion

            #region Special Repos-Fnagily
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
            #endregion

            #region AutoMapper Configuration-WholeTeam
                builder.Services.AddAutoMapper(typeof(AutoMapperProfiler).Assembly);
            #endregion

            #region Managers Configs-Whole Team
            builder.Services.AddScoped<IUserManager, UserManage>();
            builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();
            builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            #endregion

            #region JWT Configuration-WholeTeam
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "AirbBnbDefault";
                options.DefaultChallengeScheme = "AirbBnbDefault";
            }).AddJwtBearer("AirbBnbDefault", options =>
            {
                SymmetricSecurityKey key = JWTHelper.getKey(builder.Configuration);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            #region Cors Configuration-WholeTeam
            string AllowPolicy = "Allow";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(AllowPolicy, opt =>
                {
                    opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
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
            app.UseCors(AllowPolicy);

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}