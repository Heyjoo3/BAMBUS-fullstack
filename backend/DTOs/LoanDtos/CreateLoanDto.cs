using Bambus.Enums;

namespace Bambus.DTOs.LoanDtos
{
    public class CreateLoanDTO
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public ItemType ItemType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
