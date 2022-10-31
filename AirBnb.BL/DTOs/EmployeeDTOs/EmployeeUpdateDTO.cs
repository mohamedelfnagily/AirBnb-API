using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.DTOs.EmployeeDTOs
{
    public class EmployeeUpdateDTO
    {
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        
        public string? ProfilePicture { get; set; } 
        public double Salary { get; set; }
    }
}
