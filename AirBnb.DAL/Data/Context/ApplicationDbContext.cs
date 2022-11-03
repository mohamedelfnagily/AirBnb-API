using AirBnb.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Data.Context
{
    //This is the context class representing the data base
    public class ApplicationDbContext:IdentityDbContext<Person>
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            builder.Entity<UserLanguage>()
                .HasKey(bc => new { bc.UserId, bc.LanguageId });
            builder.Entity<UserLanguage>()
                .HasOne(e=>e.Language)
                .WithMany(p => p.userLanguages)
                .HasForeignKey(e => e.LanguageId);
            builder.Entity<UserLanguage>()
                .HasOne(e => e.User)
                .WithMany(p => p.userLanguages)
                .HasForeignKey(e => e.UserId);
            builder.Entity<Category>().Property(e => e.URL).HasComputedColumnSql("CONCAT(TRIM(Name),'.jpg') ");
            
        }
        private void SeedUsers(ModelBuilder builder)
        {
            //Person person = new Person()
            //{
            //    Id = "b74ddd14-6340-4840-95c2-db12554843e5",
            //    UserName = "User@gmail.com",
            //    FirstName = "Ramzy",
            //    LastName = "Bassem",
            //    BirthDate = DateTime.UtcNow,           
            //    Email = "User@gmail.com",
            //    LockoutEnabled = false,
            //    PhoneNumber = "1234567890",
            //    NormalizedUserName = "USER@GMAIL.COM"

            //};

            //PasswordHasher<Person> passwordHasher = new PasswordHasher<Person>();
            //person.PasswordHash = passwordHasher.HashPassword(person, "Mm123321#$");
            //builder.Entity<Person>().HasData(person);
            User user = new User()
            {
                //  Id = "b74ddd14-6340-4840-95c2-db12554843e5",

                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "user@gmail.com",
                FirstName = "Ramzy",
                LastName = "Bassem",
                BirthDate = DateTime.UtcNow,
                Email = "user@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                NormalizedUserName = "USER@GMAIL.COM",
                Rating = 0,
                Balance = 0,
                EmailConfirmed = true,
                NormalizedEmail = "USER@GMAIL.COM"
            };
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Mm123321#$");
            builder.Entity<User>().HasData(user);

        }
        public virtual DbSet<Person> Persons { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<Property> Properties { get; set; } = null!;
        public virtual DbSet<PropertyPicture> PropertyPictures { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<UserLanguage> UserLanguages { get; set; } = null!;
    }
}
