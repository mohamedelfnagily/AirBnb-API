using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.DTOs.EmployeeDTOs
{
    public class EmployeeReadDTO
    {
        public string Id { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        
        public string PhoneNumber { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public byte[]? ProfilePicture { get; set; } = null!;
        public double SSN { get; set; }
        public double Salary { get; set; }

        public string Errors { get; set; } = string.Empty;

        public string Role { get; set; } = "";
    }
}
