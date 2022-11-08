using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Repository.Non_Generic.ReviewRepo
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        //This repository is responsible for all Reservation Reviews operations

        Task<Review> GetReviewById(Guid ReviewId);
        Task<List<Review>> GetPropertyReviews(Guid propertyId);
        Task<List<Review>> GetHostPropertiesReviews(string HosterId);
        Task<Review> AddReview(Review review);  
        Task<Property> UpdatePropertyRating(Guid propertyId);
        Task<User> UpdateHosterRating(string HosterId);

        Task<Review> UpdateReview(Review review);
    }
}
