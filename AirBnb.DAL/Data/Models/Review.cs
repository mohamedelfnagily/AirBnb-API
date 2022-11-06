using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Data.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public string? Description { get; set; } = "";
        public DateTime ReviewDate { get; set; }
        public double Rating { get; set; }
        [ForeignKey("Reservation")]
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; } = null!;
    }
}
