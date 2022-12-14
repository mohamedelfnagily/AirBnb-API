using AirBnb.BL.DTOs.UserDTOs;
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
    public class ReviewReadDTO
    {
        public Guid Id { get; set; }
        public string? Description { get; set; } = "";
        public DateTime ReviewDate { get; set; }
        [Range(0, 5)]
        public double Rating { get; set; }
        public UserReadDTO User { get; set; }
    }
}
