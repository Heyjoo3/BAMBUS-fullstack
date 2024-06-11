using Bambus.Models;

namespace Bambus.DTOs.LoanDtos
{
    public class GetRatingLoanItemDto
    {
        public RatingModel Rating { get; set; }
        public LoanModel Loan { get; set; }
        public BookModel? Book { get; set; }
        public MagazineModel? Magazine { get; set; }
        public GameModel? Game { get; set; }
        
    }
}
