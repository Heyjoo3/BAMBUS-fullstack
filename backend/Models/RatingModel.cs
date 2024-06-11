using System.ComponentModel.DataAnnotations;

namespace Bambus.Models
{
    public class RatingModel
    {
        [Key]
        public int RatingId { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public bool IsRecommended { get; set; }
        public string? Comment { get; set; }
    }
}