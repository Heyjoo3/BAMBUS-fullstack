using AutoMapper;
using Bambus.Data;
using Bambus.DTOs.RatingDtos;
using Bambus.Models;
using Microsoft.EntityFrameworkCore;

namespace Bambus.Services.Rating
{
    public class RatingService : IRatingService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RatingService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetRatingDTO>>> AddRating(AddRatingDTO newRating)
        {
            ServiceResponse<List<GetRatingDTO>> serviceResponse = new ServiceResponse<List<GetRatingDTO>>();
            RatingModel rating = _mapper.Map<RatingModel>(newRating); 
            RatingModel? ratingExists = await _context.Ratings.FirstOrDefaultAsync(r => r.UserId == newRating.UserId && r.ItemId == newRating.ItemId);
            if (ratingExists != null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Rating already exists. Each user can only rate an item once.";
                return serviceResponse;
            } 
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Ratings.Select(c => _mapper.Map<GetRatingDTO>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetRatingDTO>>> DeleteRating(int id)
        {
            ServiceResponse<List<GetRatingDTO>> serviceResponse = new ServiceResponse<List<GetRatingDTO>>();
            RatingModel rating = await _context.Ratings.FirstOrDefaultAsync(c => c.RatingId == id);
            _context.Ratings.Remove(rating);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Ratings.Select(c => _mapper.Map<GetRatingDTO>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetRatingDTO>>> GetAllRatings()
        {
            ServiceResponse<List<GetRatingDTO>> serviceResponse = new ServiceResponse<List<GetRatingDTO>>();
            List<RatingModel> dbRatings = await _context.Ratings.ToListAsync();
            serviceResponse.Data = dbRatings.Select(c => _mapper.Map<GetRatingDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetRatingDTO>>> UpdateRating(UpdateRatingDTO updateRating)
        {
            ServiceResponse<List<GetRatingDTO>> serviceResponse = new ServiceResponse<List<GetRatingDTO>>();
            RatingModel? rating = await _context.Ratings.FirstAsync(c => c.RatingId == updateRating.RatingId);
            rating.Rating = updateRating.Rating;
            rating.IsRecommended = updateRating.IsRecommended;
            rating.Comment = updateRating.Comment;
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Ratings.Select(c => _mapper.Map<GetRatingDTO>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetRatingDTO>>> DeleteRatingsByItemId(int itemId)
        {
            ServiceResponse<List<GetRatingDTO>> serviceResponse = new ServiceResponse<List<GetRatingDTO>>();
            List<RatingModel> ratings = await _context.Ratings.Where(r => r.ItemId == itemId).ToListAsync();
            _context.Ratings.RemoveRange(ratings);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Ratings.Select(c => _mapper.Map<GetRatingDTO>(c)).ToListAsync();
            return serviceResponse;
        }
    }
}
