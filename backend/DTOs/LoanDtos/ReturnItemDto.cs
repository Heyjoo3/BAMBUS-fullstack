using Bambus.Enums;

namespace Bambus.DTOs.LoanDtos
{
    public class ReturnItemDto
    {
        public int LoanId { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int RatingId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public bool? IsRecommended { get; set; }
        public Condition Condition { get; set; }
        public string? DamageDescription { get; set; }
        public ItemType ItemType { get; set; }
        public bool NeedsRating { get; set; }
    }
}
