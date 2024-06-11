using System.ComponentModel.DataAnnotations;

namespace Bambus.Models
{
    public class LoanModel
    {
        [Key]
        public int LoanId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool ExtensionRequestRunning { get; set; }
    }
}
