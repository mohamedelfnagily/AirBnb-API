using AirBnb.DAL.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    //base.OnModelCreating(builder);
        //    //builder.Entity<UserLanguage>()
        //    //    .HasOne<User>(e=>e.id)
        //    //    .WithMany<UserLanguage>(p=>p.Id)
        //    //    .HasForeignKey(e=>e.UserId);
        //}
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
    }
}
