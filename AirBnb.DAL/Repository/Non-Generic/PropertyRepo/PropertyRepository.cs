using AirBnb.DAL.Data.Context;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Repository.Non_Generic.PropertyRepo
{
    public class PropertyRepository:BaseRepository<Property>,IPropertyRepository
    {
        private readonly ApplicationDbContext _context;
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
        public async Task<IEnumerable<Property>> GetPropertiesByEssentials(params bool[] Essentials)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<Property>> GetPropertiesByLanguage(params string[] language)
        {
            throw new NotImplementedException();

        }

        public Task<IEnumerable<Property>> GetPropertiesByNumberOfRooms(int num)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> GetPropertiesByPrice(double num)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> GetPropertiesByType(string type)
        {
            throw new NotImplementedException();
        }
    }
}
