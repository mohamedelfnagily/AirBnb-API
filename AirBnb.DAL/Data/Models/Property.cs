using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Data.Models
{
    public class Property
    {
        public Property()
        {
            Rooms = new HashSet<Room>();
            Reservations=new HashSet<Reservation>();
            Pictures=new HashSet<PropertyPicture>();
        }
        public Guid Id { get; set; }
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
        public ICollection<Room> Rooms { get; set; }

        [ForeignKey("Hoster")]
        public string HosterId { get; set; } = "";
        public User Hoster { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<PropertyPicture> Pictures { get; set; }
    }
}
