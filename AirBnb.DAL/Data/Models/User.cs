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
        public double Rating { get; set; }
        public double Balance { get; set; }
    }
}
