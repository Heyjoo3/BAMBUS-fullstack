using Bambus.Enums;

namespace Bambus.DTOs.ItemDtos
{
    public class AddItemDTO
    {
        public string Title { get; set; }
        public Condition Condition { get; set; }
        public ItemType Type { get; set; }
        public string? ISBN { get; set; }
        public string? Author { get; set; }
        public string? Category { get; set; }
        public string? ISSN { get; set; }

        public int? ItemId { get; set; }
        public List<int>? Reservations { get; set; }
        public int? CurrentLoanId { get; set; }
        public double? AvgRating { get; set; }
    }
}
