using Bambus.DTOs.LoanDtos;
using Bambus.Models;

namespace Bambus.Services.Loan
{
    public interface ILoanService
    {
        Task<ServiceResponse<List<GetLoanDTO>>> GetAllLoansFromUserId(int userId);
        Task<ServiceResponse<List<GetLoanDTO>>> GetAllLoans();
        Task<ServiceResponse<List<GetLoanDTO>>> CreateLoan(CreateLoanDTO newLoan);
        Task<ServiceResponse<GetLoanDTO>> ActivateExtensionRequest(StartExtensionDto startExtension);
        Task<ServiceResponse<GetLoanDTO>> SetReturnDate(int loanId);
        Task<ServiceResponse<GetLoanDTO>> EndExtensionRequest(EndExtensionDto endExtension);
        Task<ServiceResponse<GetRatingLoanItemDto>> ReturnItem(ReturnItemDto returnItem);
    }
}
