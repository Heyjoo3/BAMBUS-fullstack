namespace Bambus.DTOs.RatingDtos
{
    public class UpdateRatingDTO
    {
        public int RatingId { get; set; }
        public int Rating { get; set; }
        public bool IsRecommended { get; set; }
        public string? Comment { get; set; }
    }
}
