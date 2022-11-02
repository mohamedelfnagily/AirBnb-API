using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.DTOs.UserDTOs
{
    public class UserLoginDTO
    {
        [Required]
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$")]

        public string Email { get; set; } = "";
        [Required]
        [RegularExpression(@"^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{8,}$")]
        public string Password { get; set; } = "";
    }
}
