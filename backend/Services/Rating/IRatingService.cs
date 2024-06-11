using Bambus.Models;
using Bambus.DTOs.RatingDtos;

namespace Bambus.Services.Rating
{
    public interface IRatingService
    {
        Task <ServiceResponse<List<GetRatingDTO>>> AddRating(AddRatingDTO newRating);
        Task <ServiceResponse<List<GetRatingDTO>>> UpdateRating(UpdateRatingDTO updateRating);
        Task <ServiceResponse<List<GetRatingDTO>>> DeleteRating(int id);
        Task <ServiceResponse<List<GetRatingDTO>>> GetAllRatings();
        Task<ServiceResponse<List<GetRatingDTO>>> DeleteRatingsByItemId(int itemId);
    }
}
