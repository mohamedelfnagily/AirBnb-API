using AirBnb.BL.DTOs.ReviewDTOs;
using AirBnb.BL.Managers.ManageRevews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirBnb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewManager _reviewManager;
        public ReviewController(IReviewManager reviewManager)
        {
            _reviewManager = reviewManager;
        }
        [HttpGet("GetReviewById/{id}")]
        public async Task<ActionResult<ReviewReadDTO>> GetReviewById(Guid id)
        {
            var review = await _reviewManager.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }
        [HttpGet("GetHostPropertiesReviews/{id}")]
        public async Task<ActionResult<IEnumerable<ReviewReadDTO>>> GetHostPropertiesReviews(string id)
        {
            var review = await _reviewManager.GetHostPropertiesReviews(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }
        [HttpGet("GetPropertyReviews/{id}")]
        public async Task<ActionResult<IEnumerable<ReviewReadDTO>>> GetPropertyReviews(Guid id)
        {
            var review = await _reviewManager.GetPropertyReviews(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }
        [HttpPost("AddReview")]
        public async Task<ActionResult<ReviewReadDTO>> AddReview(ReviewAddDTO model)
        {
            if (model == null)
                return BadRequest();
            var review = await _reviewManager.AddReview(model);
            return Ok(review);
        }
        [HttpPut("UpdateReview")]
        public  async Task<ActionResult<ReviewReadDTO>> UpdateReview(ReviewUpdateDTO model)
        {
            if (model == null)
                return BadRequest();
            var review =  await _reviewManager.UpdateReview(model);
            return Ok(review);
        }
        [HttpDelete("DeleteReview/{id}")]
        public ActionResult<ReviewReadDTO> UpdateReview(Guid id)
        {
            if (id == null)
                return BadRequest();
            var review = _reviewManager.DeleteReviewById(id);
            return Ok(review);
        }
    }
}
