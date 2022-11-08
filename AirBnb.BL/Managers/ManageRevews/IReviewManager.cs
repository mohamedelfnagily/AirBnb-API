using AirBnb.BL.DTOs.PropertyDTOs;
using AirBnb.BL.DTOs.ReviewDTOs;
using AirBnb.BL.DTOs.UserDTOs;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Non_Generic.ReviewRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageRevews
{
    public interface IReviewManager 
    {
        Task<ReviewReadDTO> GetReviewById(Guid ReviewId);
        Task<IEnumerable<ReviewReadDTO>> GetPropertyReviews(Guid propertyId);
        Task<IEnumerable<ReviewReadDTO>> GetHostPropertiesReviews(string HosterId);
        Task<ReviewReadDTO> AddReview(ReviewAddDTO model);
        ReviewReadDTO DeleteReviewById(Guid reviewId);
        Task<ReviewReadDTO> UpdateReview(ReviewUpdateDTO model);
        
    }
}
