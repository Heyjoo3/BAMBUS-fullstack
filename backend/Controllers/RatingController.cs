using Microsoft.AspNetCore.Mvc;
using Bambus.DTOs.RatingDtos;
using Bambus.Services.Rating;
using Bambus.Validators.Rating;
using Microsoft.AspNetCore.Authorization;


namespace Bambus.Controllers
{
    [ApiController]
    [Authorize]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost("AddRating")]
        public async Task<IActionResult> AddRating(AddRatingDTO addRatingDTO)
        {
            try
            {
                var validator = new AddRatingValidator();
                var validationResult = await validator.ValidateAsync(addRatingDTO);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
                return Ok(await _ratingService.AddRating(addRatingDTO));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateRating")]
        public async Task<IActionResult> UpdateRating(UpdateRatingDTO updateRatingDTO)
        {
            try
            {
                var validator = new UpdateRatingValidator();
                var validationResult = await validator.ValidateAsync(updateRatingDTO);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
                return Ok(await _ratingService.UpdateRating(updateRatingDTO));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("DeleteRating/{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        { 
            try            
            {
                return Ok(await _ratingService.DeleteRating(id));
                
            }
            catch (Exception e)
                       {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("GetAllRating")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllRatings()
        {
            try
            {
                return Ok(await _ratingService.GetAllRatings());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("DeleteRatingsByItemId/{itemId}")]
        public async Task<IActionResult> DeleteRatingsByItemId(int itemId)
        {
            try
            {
                return Ok(await _ratingService.DeleteRatingsByItemId(itemId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}