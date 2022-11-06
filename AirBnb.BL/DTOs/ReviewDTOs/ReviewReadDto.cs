using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.DTOs.ReviewDTOs
{
    public class ReviewReadDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; } = "";
        public DateTime ReviewDate { get; set; }
        public double Rating { get; set; }
    }
}
