using AirBnb.BL.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.DTOs.ReservationDTOs
{
    public class ReservationAddDto
    {
        public string UserId { get; set; } = "";
        public Guid PropertyId { get; set; }
        [CheckReservationDate(ErrorMessage = "Invalid date")]
        public DateTime StartDate { get; set; }
        [CheckReservationDate(ErrorMessage = "Invalid date")]
        public DateTime EndDate { get; set; }
    }
}
