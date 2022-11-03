using AirBnb.BL.DTOs.PropertyPicsDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.DTOs.PropertyDTOs
{
    public class PropertyAddDto
    {
        public string Description { get; set; } = "";
        public string Location { get; set; } = "";
        public double Price { get; set; }
        public double Rating { get; set; }
        public string PropertyType { get; set; } = "";
        public int MaxNumberOfUsers { get; set; }
        public int NumberOfRooms { get; set; }
        public bool Wifi { get; set; }
        public bool Parking { get; set; }
        public bool Tv { get; set; }
        public bool Washer { get; set; }
        public bool Elevator { get; set; }
        public bool Generator { get; set; }
        public bool PrivateRoom { get; set; }
        public bool SmokeAlarm { get; set; }
        public bool SeaView { get; set; }
        public Guid CategoryId { get; set; }
        public string HosterId { get; set; } = "";
        public IEnumerable<IFormFile> Pictures { get; set; } = new HashSet<IFormFile>();
    }
}
