using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.DTOs.UserDTOs
{
    public class UserReadDTO
    {
        public string Id { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public double Rating { get; set; }
        public double Balance { get; set; }
        public string Errors { get; set; } = "";
        public IEnumerable<UserLanguagesDTO> Languagues { get; set; }= new HashSet<UserLanguagesDTO>();
    }
 }

