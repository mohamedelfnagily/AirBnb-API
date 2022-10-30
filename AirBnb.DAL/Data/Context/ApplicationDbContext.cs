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
        public virtual DbSet<Person> Persons { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
    }
}
