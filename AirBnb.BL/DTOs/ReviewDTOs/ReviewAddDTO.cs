using AirBnb.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.DTOs.ReviewDTOs
{
    public class ReviewAddDTO
    {
        [Required]

        public string Description { get; set; } = "";
        [Required]
        [Range(0,5)]
        public double Rating { get; set; }
        [Required]
        public Guid ReservationId { get; set; }
    }
}
