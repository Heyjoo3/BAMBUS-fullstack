using System.ComponentModel.DataAnnotations;
using Bambus.Enums;

namespace Bambus.Models

{
    public abstract class ItemModel
    {
        [Key]
        public int ItemId { get; set; }
        public List<int>? Reservations { get; set; }
        public Condition Condition { get; set; } = 0;
        public int? CurrentLoanId { get; set; }
        public string Title { get; set; }
        public double AvgRating { get; set; } = 0;
    }
}