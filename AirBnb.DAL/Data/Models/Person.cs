using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Data.Models
{
    //This is the base class of person having all the properties of a person
    //Two classes will be inheriting from this class :User and Employee
    //This class is implemented to have all the common properties between both classes
    [Table("Persons")]
    public class Person:IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public string? ProfilePicture { get; set; } = "";
    }
}
