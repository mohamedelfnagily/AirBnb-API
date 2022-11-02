using AirBnb.DAL.Data.Models;
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

            builder.Entity<Category>().HasData( 
                 new Category {Id= Guid.NewGuid() , Name="Amazing Pools", Description="seaviewairbnb"},
                 new Category { Id =Guid.NewGuid() , Name = "National Parks", Description = "Nationalparksairbnb" },
                 new Category { Id = Guid.NewGuid(), Name = "Shared Homes", Description = "Shared Homesairbnb" },
                 new Category { Id = Guid.NewGuid(), Name = "Amazing Views", Description = "Amazing Viewsairbnb" },
                 new Category { Id = Guid.NewGuid(), Name = "Bed & breakfasts", Description = "Bed & breakfastsairbnb" },
                 new Category { Id = Guid.NewGuid(), Name = "Lake", Description = "Lakeairbnb" },
                 new Category { Id = Guid.NewGuid(), Name = "Farms", Description = "Farmsairbnb" },
                 new Category { Id = Guid.NewGuid(), Name = "Boats", Description = "Boatsairbnb" },
                 new Category { Id = Guid.NewGuid(), Name = "Deserts", Description = "Desertsairbnb" },
                 new Category { Id = Guid.NewGuid(), Name = "Countryside", Description = "Countrysideairbnb" },
                 new Category { Id = Guid.NewGuid(), Name = "Earth homes", Description = "Earth homesairbnb" },
                 new Category { Id = Guid.NewGuid(), Name = "Golfing", Description = "Golfing airbnb" }
                );
            builder.Entity<Category>().Property(e => e.URL).HasComputedColumnSql("CONCAT(TRIM(Name),'.jpg') ");
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
