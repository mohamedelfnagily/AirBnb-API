using AirBnb.DAL.Data.Context;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Repository.Non_Generic.PropertyRepo
{
    public class PropertyRepository:BaseRepository<Property>,IPropertyRepository
    {
        private readonly ApplicationDbContext _context;
        public List<string> MyEssentials { get; set; } = new List<string>{ 
            "Wifi","Parking","Tv","Washer","Elevator","Generator","PrivateRoom","SmokeAlarm","SeaView"
        };
        public PropertyRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        //Getting all the reservations of this property
        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync(Guid PropertyId)
        {
            Property myProperty = await _context.Properties.Include(e => e.Reservations).FirstOrDefaultAsync(p => p.Id == PropertyId);
            var myReservations =  myProperty.Reservations.ToList();
            return myReservations;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync(Guid PropertyId)
        {
            Property myProperty = await _context.Properties.Include(e => e.Reviews).FirstOrDefaultAsync(p => p.Id == PropertyId);
            var myReviews = myProperty.Reviews.ToList();
            return myReviews;
        }
        //Filteration section implementation
        public async Task<IEnumerable<Property>> GetPropertiesByEssentials(params string[] Essentials)
        {
            
            IEnumerable<Property> myProperties = await _context.Properties.ToListAsync();
            foreach (var ess in Essentials)
            {
                if(MyEssentials.Contains(ess))
                {
                    myProperties = myProperties.Where(t => ((bool)t.GetType().GetProperty(ess).GetValue(t)).Equals(true));
                }
            }
            return myProperties;
        }

        public async Task<IEnumerable<Property>> GetPropertiesByLanguage(params string[] language)
        {
            var myLanguages = await _context.Languages.Include(e => e.userLanguages).Where(e => language.Contains(e.Name)).ToListAsync();
            HashSet<string> userIds = new HashSet<string>(); 
            foreach (var lang in myLanguages)
            {
                foreach(var user in lang.userLanguages)
                {
                    if(!userIds.Contains(user.UserId))
                    {
                        userIds.Add(user.UserId);
                    }
                }
            }
            var myProperties =await _context.Properties.Include(p => p.Hoster).Where(e=>userIds.Contains(e.HosterId)).ToListAsync();
            return myProperties;
        }

        public async Task<IEnumerable<Property>> GetPropertiesByNumberOfRooms(int num)
        {
            var myProps = await _context.Properties.Where(e => e.NumberOfRooms == num).ToListAsync();
            return myProps;
        }

        public async Task<IEnumerable<Property>> GetPropertiesByPrice(double minPrice, double maxPrice)
        {
            var myProps = await _context.Properties.Where(e => e.Price>=minPrice&&e.Price<=maxPrice).ToListAsync();
            return myProps;
        }

        public async Task<IEnumerable<Property>> GetPropertiesByType(string type)
        {
            var myProps = await _context.Properties.Where(e => e.PropertyType==type).ToListAsync();
            return myProps;
        }

    
    }
}
