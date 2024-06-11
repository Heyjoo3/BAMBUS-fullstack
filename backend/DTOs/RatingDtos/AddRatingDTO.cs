namespace Bambus.DTOs.RatingDtos
{
    public class AddRatingDTO
    {
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public bool IsRecommended { get; set; }
        public string? Comment { get; set; }
    }
}
