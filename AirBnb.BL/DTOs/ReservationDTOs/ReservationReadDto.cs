using AirBnb.BL.DTOs.PropertyDTOs;
using AirBnb.BL.DTOs.ReviewDTOs;
using AirBnb.BL.DTOs.UserDTOs;
using AirBnb.BL.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.DTOs.ReservationDTOs
{
    public class ReservationReadDto
    {
        public Guid Id { get; set; }
        [CheckReservationDate(ErrorMessage ="Invalid date")]
        public DateTime StartDate { get; set; }
        [CheckReservationDate(ErrorMessage = "Invalid date")]
        public DateTime EndDate { get; set; }
        [StringLength(350)]
        public string Note { get; set; } = "";
        [Range(0,double.MaxValue)]
        public double TotalPrice { get; set; }
        public string UserId { get; set; }
        public Guid PropertyId { get; set; }
        public ReviewReadDto Review { get; set; } = null!;
        public string Errors { get; set; } = "";
    }
}
