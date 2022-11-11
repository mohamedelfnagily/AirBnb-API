using AirBnb.BL.Validations;
using Microsoft.AspNetCore.Http;
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
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$")]
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


        public IFormFile? ProfilePicture { get; set; } = null!;
        [Required]
        public double SSN { get; set; }
        [Required]

        public double Salary { get; set; }

        public string Role { get; set; } = "";
    }
}
