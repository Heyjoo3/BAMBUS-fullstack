using Bambus.DTOs.LoanDtos;
using Bambus.Services.Loan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bambus.Controllers
{
    [ApiController]
	[Authorize]
    public class LoanController : ControllerBase
	{
		private readonly ILoanService _loanService;

		public LoanController(ILoanService loanService)
		{
            _loanService = loanService;
        }

		[HttpPost("GetAllLoansFromUser/{userId}")]
		public async Task<IActionResult> GetAllLoansFromUserId(int userId)
		{
			try
			{
				return Ok(await _loanService.GetAllLoansFromUserId(userId));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost("GetAllLoans")]
		[AllowAnonymous]
		public async Task<IActionResult> GetAllLoans()
		{
			try
			{
                return Ok(await _loanService.GetAllLoans());
            } catch (Exception e)
			{
                return BadRequest(e.Message);
            }
		}

		[HttpPost("CreateLoan")]
		public async Task<IActionResult> CreateLoan(CreateLoanDTO newLoan)
		{
			try
			{
                return Ok(await _loanService.CreateLoan(newLoan));
            } catch (Exception e)
			{
                return BadRequest(e.Message);
            }
		}

		[HttpPut("ActivateExtensionRequest")]
        public async Task<IActionResult> ActivateExtensionRequest(StartExtensionDto startExtension)
        { 
            try
            {
                return Ok(await _loanService.ActivateExtensionRequest(startExtension));
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("SetReturnDate/{loanId}")]
		public async Task<IActionResult> SetReturnDate(int loanId)
		{
			try
			{
                return Ok(await _loanService.SetReturnDate(loanId));
            } catch (Exception e)
			{
                return BadRequest(e.Message);
            }
		}

		[HttpPut("ReturnItem")]
		public async Task<IActionResult> ReturnItem(ReturnItemDto returnItem)
		{
            try
			{
                return Ok(await _loanService.ReturnItem(returnItem));
            } catch (Exception e)
			{
                return BadRequest(e.Message);
            }
        }


		[HttpPut("EndExtensionRequest")]
		public async Task<IActionResult> EndExtensionRequest(EndExtensionDto endExtension)
		{
			try
			{
                return Ok(await _loanService.EndExtensionRequest(endExtension));
            } catch (Exception e)
			{
                return BadRequest(e.Message);
            }
		}
	}
}
