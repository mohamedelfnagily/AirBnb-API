using AirBnb.DAL.Data.Context;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Repository.Non_Generic.ReviewRepo
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Review> AddReview(Review review)
        {
            await _context.AddAsync(review);
            await _context.SaveChangesAsync();
            var reservation = await _context.Reservations.Where(e => e.Id == review.ReservationId).FirstOrDefaultAsync();
            if (reservation == null)
            {
                return null;
            }
            var propertyId = reservation.PropertyId;
            var hosterId = _context.Properties.Where(e=>e.Id==propertyId).Select(e=>e.HosterId).FirstOrDefault();
            await UpdatePropertyRating(propertyId);
            await UpdateHosterRating(hosterId);
            return review;

        }

        public async Task<List<Review>> GetHostPropertiesReviews(string HosterId)
        {
            var HosterPropertiesId = await _context.Properties.Where(e => e.HosterId == HosterId).Select(e=>e.Id).ToListAsync();
            var reservations =  await _context.Reservations.Where(e => HosterPropertiesId.Contains(e.PropertyId) && e.Review!=null).Select(e=>e.Id).ToListAsync();
            return await _context.Reviews.Include(e => e.Reservation).ThenInclude(e=>e.User).Where(e => reservations.Contains(e.ReservationId)).ToListAsync();
        }

        public async Task<List<Review>> GetPropertyReviews(Guid propertyId)
        {
            var reservations = await _context.Reservations.Where(e=>e.PropertyId==propertyId && e.Review != null).Select(e=>e.Id).ToListAsync();
            return await _context.Reviews.Include(e => e.Reservation).ThenInclude(e => e.User).Where(e => reservations.Contains(e.ReservationId)).ToListAsync();



        }

        public async Task<Review> GetReviewById(Guid ReviewId)
        {
            return await _context.Reviews.Include(e => e.Reservation).ThenInclude(e=>e.User).FirstOrDefaultAsync(e => e.Id == ReviewId);
        }

        public async Task<User> UpdateHosterRating(string HosterId)
        {           
 
            var properties = await _context.Properties.Where(e => e.HosterId == HosterId).Select(e=>e.Id).ToListAsync();
            var reviews = await _context.Reservations.Where(e => properties.Contains(e.PropertyId) && e.Review != null).Select(e=>e.Review).ToListAsync();
            var hoster = await _context.Users.FirstOrDefaultAsync(e => e.Id == HosterId);
            if (reviews == null)
            {
                return hoster;
            }
            var totalRating = reviews.Average(e => e.Rating);
            hoster.Rating = totalRating;
            return hoster;
        }

        public async Task<Property> UpdatePropertyRating(Guid propertyId)
        {
            var reviews = await _context.Reservations.Include(e=>e.Review).Where(e=>e.PropertyId==propertyId && e.Review!=null).Select(e=>e.Review).ToListAsync();
            double rating = 0;
            var property = await _context.Properties.FirstOrDefaultAsync(e => e.Id == propertyId);

            if (reviews == null)
            {
                return property;
            }
            rating = reviews.Sum(e => e.Rating);

            property.Rating = rating / reviews.Count;
            return property;
            
        }

        public async Task<Review> UpdateReview(Review review)
        {
            var reservation = await _context.Reservations.Where(e => e.Id == review.ReservationId).FirstOrDefaultAsync();
            if (reservation == null)
            {
                return null;
            }
            var propertyId = reservation.PropertyId;
            var hosterId = await _context.Properties.Where(e => e.Id == propertyId).Select(e => e.HosterId).FirstOrDefaultAsync();
            await UpdatePropertyRating(propertyId);
            await UpdateHosterRating(hosterId);
            return review;
        }
    }
}
