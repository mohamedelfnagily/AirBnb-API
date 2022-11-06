using AirBnb.BL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.DTOs.ReservationDTOs
{
    public class ReservationUserDto
    {
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public double Rating { get; set; }
        public IEnumerable<UserLanguagesDTO> Languagues { get; set; } = new HashSet<UserLanguagesDTO>();

    }
}
