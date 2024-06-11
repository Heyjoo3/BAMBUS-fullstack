using Bambus.Enums;

namespace Bambus.DTOs.ItemDtos
{
    public class GetItemDTO
    {
        public int ItemId { get; set; }
        public List<int>? Reservations { get; set; } = new List<int>();
        public Condition Condition { get; set; }
        public int? CurrentLoanId { get; set; } = null;
        public string Title { get; set; }
        public double AvgRating { get; set; }
        public ItemType? Type { get; set; } 
        public string? Author { get; set; } = string.Empty;
        public string? Category { get; set; } = string.Empty;
        public string? ISBN { get; set; } = string.Empty;
        public string? ISSN { get; set; } = string.Empty;

    }
}
