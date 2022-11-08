using AirBnb.BL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.DTOs.ReservationDTOs
{
    public class ReservationReviewReadDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; } = "";
        public DateTime ReviewDate { get; set; }
        public double Rating { get; set; }
    }
}
