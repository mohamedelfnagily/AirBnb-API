using AirBnb.BL.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.DTOs.EmployeeDTOs
{
    public class EmployeeUpdateDTO
    {
        [Required]
        public string Id { get; set; } = "";
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string UserName { get; set; } = "";

        [Required]
        [RegularExpression(@"[a-z0-9]+@[a-z]+\.[a-z]{2,3}")]
        public string Email { get; set; } = "";

        [Required]
        [RegularExpression(@"^01[0125][0-9]{8}$")]
        public string PhoneNumber { get; set; } = "";

        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        [Required]
        [CheckBdDate(ErrorMessage = "Date Should not be in the future")]
        public DateTime BirthDate { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{8,}$")]
        public string Password { get; set; } = "";

        public string? ProfilePicture { get; set; }
        [Required]
        public double SSN { get; set; }
        [Required]

        public double Salary { get; set; }

        public string Role { get; set; } = "";
    }
}
