using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Data.Models
{
    //This class represents the customers of the application
    //Customer in the application could be Customer or hoster or both
    [Table("Users")]
    public class User:Person
    {
        public User()
        {
            Reservations = new HashSet<Reservation>();
            Properties = new HashSet<Property>();
            Languages = new HashSet<Language>();
        }
        public double Rating { get; set; }
        public double Balance { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<Language> Languages { get; set; }
    }
}
