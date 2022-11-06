using AirBnb.BL.AutoMapper;
using AirBnb.BL.Emails.Services;
using AirBnb.BL.Emails.Settings;
using AirBnb.BL.Managers.ManageCategories;
using AirBnb.BL.Helpers;
using AirBnb.BL.Managers.ManageAuthentication;
using AirBnb.BL.Managers.ManageEmployee;
using AirBnb.BL.Managers.ManageUser;
using AirBnb.DAL.Data.Context;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Non_Generic.CategoryRepo;
using AirBnb.DAL.Repository.Non_Generic.PersonRepo;
using AirBnb.DAL.Repository.Non_Generic.PropertyRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using AirBnb.DAL.Repository.Generic;
using AirBnb.BL.Managers.ManageProperty;
using AirBnb.DAL.Repository.Non_Generic.UserRepo;
using AirBnb.DAL.Repository.Non_Generic.LanguageRepo;
using AirBnb.BL.Managers.ManageLanguage;

namespace AirBnb.Api
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Cors Configuration-WholeTeam
            string allowPolicy = "AllowAll";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(allowPolicy, p =>
                {
                    p.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true);
                });
            });
            #endregion

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

            builder.Services.AddIdentityCore<Employee>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Lockout.AllowedForNewUsers = false;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddIdentityCore<User>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Lockout.AllowedForNewUsers = false;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            #endregion

            #region Special Repos-Fnagily
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
            #endregion

            #region AutoMapper Configuration-WholeTeam
            builder.Services.AddAutoMapper(typeof(AutoMapperProfiler).Assembly);
            #endregion

            #region Managers Configs-Whole Team
            builder.Services.AddScoped<IUserManager, UserManage>();
            builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();
            builder.Services.AddScoped<ICategoryManager, CategoryManager>();
            builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            builder.Services.AddScoped<IPropertyManager, PropertyManager>();
            builder.Services.AddScoped<ILanguageManager, LanguageManager>();

            #endregion

            #region Authentication Configs-WholeTeam
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Default";
                options.DefaultChallengeScheme = "Default";
            }).AddJwtBearer("Default", options =>
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
            app.UseCors(allowPolicy);

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}