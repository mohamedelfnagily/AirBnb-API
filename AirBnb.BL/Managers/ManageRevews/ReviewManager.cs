using AirBnb.BL.DTOs.PropertyDTOs;
using AirBnb.BL.DTOs.ReviewDTOs;
using AirBnb.BL.DTOs.UserDTOs;
using AirBnb.DAL.Data.Models;
using AirBnb.DAL.Repository.Non_Generic.ReviewRepo;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageRevews
{
    public class ReviewManager : IReviewManager
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public ReviewManager(IReviewRepository reviewRepository,IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
        public async Task<ReviewReadDTO> GetReviewById(Guid ReviewId)
        {
            if (ReviewId == null)
            {
                return null;
            }
           var review =  await _reviewRepository.GetReviewById(ReviewId);
            if (review == null)
                return null;
            var reviewReadDto =  _mapper.Map<ReviewReadDTO>(review);
            reviewReadDto.User = _mapper.Map<UserReadDTO>(review.Reservation.User);
            return reviewReadDto;
        }

        public async Task<IEnumerable<ReviewReadDTO>> GetHostPropertiesReviews(string HosterId)
        {
            if (HosterId == null)
                return null;
            var reviews =  await _reviewRepository.GetHostPropertiesReviews(HosterId);
             
            var reviewReadDto = _mapper.Map<List<ReviewReadDTO>>(reviews);
            int i =0;
            foreach(var review in reviews)
            {
                reviewReadDto[i].User = _mapper.Map<UserReadDTO>(review.Reservation.User);
                i++;
            }
            return reviewReadDto;
        }

    

        public async Task<IEnumerable<ReviewReadDTO>> GetPropertyReviews(Guid propertyId)
        {
            if (propertyId == null)
                return null;
            var reviews = await _reviewRepository.GetPropertyReviews(propertyId);
            var reviewReadDto = _mapper.Map<List<ReviewReadDTO>>(reviews);
            int i = 0;
            foreach (var review in reviews)
            {
                reviewReadDto[i].User = _mapper.Map<UserReadDTO>(review.Reservation.User);
                i++;
            }
            return reviewReadDto;
        }

      
        public async Task<ReviewReadDTO> AddReview(ReviewAddDTO model)
        {
            if (model == null)
                return null;
            var review = _mapper.Map<Review>(model);
            review.Id = Guid.NewGuid();
            review.ReviewDate = DateTime.Now;
            await _reviewRepository.AddReview(review);
            _reviewRepository.Save();
            var reviewReadDTO =  _mapper.Map<ReviewReadDTO>(review);
            reviewReadDTO.User= _mapper.Map<UserReadDTO>(review.Reservation.User);
            return reviewReadDTO;
            
        }

        public ReviewReadDTO DeleteReviewById(Guid reviewId)
        {
            if (reviewId == null)
                return null;
          var review =  _reviewRepository.Delete(reviewId);
            if (review == null)
                return null;
            _reviewRepository.Save();
            return _mapper.Map<ReviewReadDTO>(review);
        }

        public async Task<ReviewReadDTO> UpdateReview(ReviewUpdateDTO model)
        {
            Review review =await _reviewRepository.GetReviewById(model.Id);
            if (review == null)
                return null;

            _mapper.Map(model, review);
           // _reviewRepository.Save();
           await _reviewRepository.UpdateReview(review);
              _reviewRepository.Save();

            return _mapper.Map<ReviewReadDTO>(review);

        }

      

      
    }
}
