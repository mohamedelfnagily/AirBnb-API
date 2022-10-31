using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Data.Models
{
    //This class represents the Employees  of the application
    //An employee could be an CEO or an admin or customer service
    [Table("Employees")]
    public class Employee:Person
    {
        public double SSN { get; set; }
        public double Salary { get; set; }

    }
}
