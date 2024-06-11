using AutoMapper;
using Bambus.Data;
using Bambus.DTOs.LoanDtos;
using Bambus.Enums;
using Bambus.Models;
using Bambus.Services.Item;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bambus.Services.Loan
{
    public class LoanService : ILoanService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public LoanService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetLoanDTO>>> GetAllLoans()
        {
            ServiceResponse<List<GetLoanDTO>> serviceResponse = new  ServiceResponse<List<GetLoanDTO>>();
            List<LoanModel> dbLoans = await _context.Loans.ToListAsync();
            serviceResponse.Data = dbLoans.Select(loan => _mapper.Map<GetLoanDTO>(loan)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetLoanDTO>>> GetAllLoansFromUserId(int UserId)
        {
            ServiceResponse<List<GetLoanDTO>> serviceResponse = new ServiceResponse<List<GetLoanDTO>>();
            List<LoanModel> dbLoans = await _context.Loans.Where(loan => loan.UserId == UserId).ToListAsync();
            serviceResponse.Data = dbLoans.Select(loan => _mapper.Map<GetLoanDTO>(loan)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetLoanDTO>>> CreateLoan(CreateLoanDTO newLoan)
        {
            ServiceResponse<List<GetLoanDTO>> serviceResponse = new ServiceResponse<List<GetLoanDTO>>();
            LoanModel loan = _mapper.Map<LoanModel>(newLoan);
            LoanModel? loanExists = await _context.Loans.FirstOrDefaultAsync(loan => loan.UserId == newLoan.UserId && loan.ItemId == newLoan.ItemId && loan.ReturnDate == null);
            if (loanExists != null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Each user must return the Item before loaning it again.";
                return serviceResponse;
            }
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();

            UserModel user = await _context.Users.FirstAsync(user => user.UserId == newLoan.UserId);
            user.NumberLoans++;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            LoanModel createdLoan = await _context.Loans.FirstOrDefaultAsync(l => l.ReturnDate == null && l.ItemId == newLoan.ItemId);

            if (createdLoan == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Loan not created";
                return serviceResponse;
            }
            int loanId = createdLoan.LoanId;

            if (newLoan.ItemType == ItemType.Game)
            {
                GameModel item = await _context.Games.FirstOrDefaultAsync(game => game.ItemId == newLoan.ItemId);
                item.CurrentLoanId = loanId;
                item.Reservations = item.Reservations.Where(reservation => reservation != newLoan.UserId).ToList();
                _context.Games.Update(item);
                serviceResponse.Message = "Game loan created";
            }
            else if (newLoan.ItemType == ItemType.Magazine)
            {
                MagazineModel item = await _context.Magazines.FirstOrDefaultAsync(magazines => magazines.ItemId == newLoan.ItemId);
                item.CurrentLoanId = loanId;
                item.Reservations = item.Reservations.Where(reservation => reservation != newLoan.UserId).ToList();
                _context.Magazines.Update(item);
                serviceResponse.Message = "Magazine loan created";
            }
            else if (newLoan.ItemType == ItemType.Book)
            {
                BookModel item = await _context.Books.FirstOrDefaultAsync(book => book.ItemId == newLoan.ItemId);
                item.CurrentLoanId = loanId;
                item.Reservations = item.Reservations.Where(reservation => reservation != newLoan.UserId).ToList();
                _context.Books.Update(item);
                serviceResponse.Message = "Book loan created";
            }
            await _context.SaveChangesAsync();

            serviceResponse.Data = _context.Loans.Where(loan => loan.UserId == newLoan.UserId).Select(loan => _mapper.Map<GetLoanDTO>(loan)).ToList();
            return serviceResponse;
        }
        
        public async Task<ServiceResponse<GetLoanDTO>> EndExtensionRequest(EndExtensionDto endExtension)
        {
            ServiceResponse<GetLoanDTO> serviceResponse = new ServiceResponse<GetLoanDTO>();
            try
            {
                LoanModel loan = await _context.Loans.FirstAsync(loan => loan.LoanId == endExtension.LoanId);
                if (endExtension.Response)
                {
                    loan.DueDate = endExtension.NewDueDate;
                    UserModel user = await _context.Users.FirstAsync(user => user.UserId == loan.UserId);
                    user.NumberExtensions++;
                    _context.Users.Update(user);
                    loan.ExtensionRequestRunning = false;
                } else {
                    loan.ExtensionRequestRunning = false;
                }
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetLoanDTO>(loan);
            } catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLoanDTO>> SetReturnDate(int loanId)
        {
            ServiceResponse<GetLoanDTO> serviceResponse = new ServiceResponse<GetLoanDTO>();
            try
            {
                LoanModel loan = await _context.Loans.FirstAsync(loan => loan.LoanId == loanId);
                loan.ReturnDate = DateTime.Now;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetLoanDTO>(loan);
            } catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        private async Task<ItemModel> GetSpecificItemAsync(ReturnItemDto returnItem)
        {
            switch (returnItem.ItemType)
            {
                case ItemType.Book:
                    return await _context.Books.FirstAsync(book => book.ItemId == returnItem.ItemId);
                case ItemType.Magazine:
                    return await _context.Magazines.FirstAsync(magazine => magazine.ItemId == returnItem.ItemId);
                case ItemType.Game:
                    return await _context.Games.FirstAsync(game => game.ItemId == returnItem.ItemId);
                default:
                    throw new InvalidOperationException("Unsupported item type");
            }
        }


        public async Task<ServiceResponse<GetRatingLoanItemDto>> ReturnItem (ReturnItemDto returnItem)
        {
            Console.WriteLine("returnItem");
            var serviceResponse = new ServiceResponse<GetRatingLoanItemDto>();
            Console.WriteLine(returnItem.ItemType);
            // get Item

            try
            {
                var item = await GetSpecificItemAsync(returnItem);
                Console.WriteLine(item);

                //Check RatingID if 0 then add rating if not then update rating
                RatingModel rating = null;

                if (returnItem.NeedsRating) {

                    if (returnItem.RatingId == 0 && (returnItem.Rating != null && returnItem.Comment != null && returnItem.IsRecommended != null))
                    {
                        Console.WriteLine("RatingId == 0");
                        rating = new RatingModel();
                        rating.IsRecommended = (bool)returnItem.IsRecommended;
                        rating.Comment = returnItem.Comment;
                        rating.Rating = returnItem.Rating;
                        rating.ItemId = returnItem.ItemId;
                        rating.UserId = returnItem.UserId;
                        await _context.Ratings.AddAsync(rating);
                        await _context.SaveChangesAsync();
                    }
                    else if (returnItem.RatingId != 0 && (returnItem.Rating != null && returnItem.Comment != null && returnItem.IsRecommended != null))
                    {
                        Console.WriteLine("RatingId != 0");
                        Console.WriteLine(returnItem.RatingId);
                        rating = await _context.Ratings.FirstAsync(rating => rating.RatingId == returnItem.RatingId);
                        rating.Rating = (int)returnItem.Rating;
                        rating.Comment = returnItem.Comment;
                        rating.IsRecommended = (bool)returnItem.IsRecommended;
                        await _context.SaveChangesAsync();
                    }
                }

                //Check if Condition is not 0
                Console.WriteLine(returnItem.Condition);
                if (returnItem.Condition == Condition.NeedsCheck)
                {
                    item.Condition = Condition.NeedsCheck;
                }


                //edit item: currentLoandId set to 0, update Conditions, update avgRating
                item.CurrentLoanId = 0;
                
                if (returnItem.NeedsRating)
                {
                    // Calculate average rating (if there are any ratings
                item.AvgRating = _context.Ratings.Where(rating => rating.ItemId == returnItem.ItemId).Average(rating => rating.Rating);
                    if (item.AvgRating == null)
                    {
                        item.AvgRating = 0;
                    }
                Console.WriteLine("avg" + item.AvgRating);
                }
 
                // Update item based on its type
                if (item is BookModel book)
                {
                     Console.WriteLine("book");
                    _context.Books.Update(book);
                }
                else if (item is MagazineModel magazine)
                {
                    Console.WriteLine("magazine");
                    _context.Magazines.Update(magazine);
                }
                else if (item is GameModel game)
                {
                    Console.WriteLine("game");
                    _context.Games.Update(game);
                }
                await _context.SaveChangesAsync();

                //update Loan: setReturnDate to now
                LoanModel loan = await _context.Loans.FirstAsync(loan => loan.LoanId == returnItem.LoanId);
                Console.WriteLine("Loan: " + loan);
                loan.ReturnDate = DateTime.Now;
                await _context.SaveChangesAsync();

                var responseDto = new GetRatingLoanItemDto();

                responseDto.Rating = rating;
                responseDto.Loan = loan;
                if (item is BookModel)
                {
                   Console.WriteLine("book1");
                    responseDto.Book = (BookModel)item;
                }
                else if (item is MagazineModel)
                {
                    Console.WriteLine("magazine1");
                    responseDto.Magazine = (MagazineModel)item;
                }
                else if (item is GameModel)
                {
                    Console.WriteLine("game1");
                    responseDto.Game = (GameModel)item;
                }

                Console.WriteLine("REsponseDto. " + responseDto);

                serviceResponse.Data = responseDto;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLoanDTO>> ActivateExtensionRequest(StartExtensionDto startExtension)
        {
            ServiceResponse<GetLoanDTO> serviceResponse = new ServiceResponse<GetLoanDTO>();
            try
            {
                LoanModel loan = await _context.Loans.FirstAsync(loan => loan.LoanId == startExtension.LoanId);
                loan.ExtensionRequestRunning = true;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetLoanDTO>(loan);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }
    }
}
