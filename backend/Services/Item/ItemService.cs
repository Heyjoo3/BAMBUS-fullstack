using Bambus.Data;
using Bambus.DTOs.ItemDtos;
using Bambus.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Bambus.DTOs.MessageDtos;
using Bambus.Enums;

namespace Bambus.Services.Item
{

    public class ItemService : IItemService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ItemService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetItemDTO>>> AddItem(AddItemDTO newItem)
        {
            ServiceResponse<List<GetItemDTO>> serviceResponse = new ServiceResponse<List<GetItemDTO>>();
            if (newItem.Type == ItemType.Magazine)
            {
                await AddItemToDb(title: newItem.Title, ISSN: newItem.ISSN, author: newItem.Author, condition: newItem.Condition, category: newItem.Category, reservations: [], currentLoanId:0);
            }
            else if (newItem.Type == ItemType.Book)
            {
                await AddItemToDb(title: newItem.Title, ISBN: newItem.ISBN, author: newItem.Author, condition: newItem.Condition, category: newItem.Category, reservations: [], currentLoanId:0);
        }
            else if (newItem.Type == ItemType.Game)
            {
                await AddItemToDb(title: newItem.Title, condition: newItem.Condition, reservations: [], currentLoanId:0);
            }
            await _context.SaveChangesAsync();
            serviceResponse.Data = GetAllItemTypes();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetItemDTO>>> DeleteItem(int itemId)
        {
            ServiceResponse<List<GetItemDTO>> serviceResponse = new ServiceResponse<List<GetItemDTO>>();
            try
            {
                var item = await FindItemInTabels(itemId);
                if (item != null)
                {
                    if (item is BookModel book)
                    {
                        _context.Books.Remove(book);
                    }
                    else if (item is MagazineModel magazine)
                    {
                        _context.Magazines.Remove(magazine);
                    }
                    else if (item is GameModel game)
                    {
                        _context.Games.Remove(game);
                    }
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = GetAllItemTypes();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Item not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetItemDTO>>> GetAllItems()
        {
            ServiceResponse<List<GetItemDTO>> serviceResponse = new ServiceResponse<List<GetItemDTO>>();
            serviceResponse.Data = GetAllItemTypes();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetItemDTO>>> UpdateItem(UpdateItemDTO updatedItem)
        {
            ServiceResponse<List<GetItemDTO>> serviceResponse = new ServiceResponse<List<GetItemDTO>>();
            try
            {
                var item = await FindItemInTabels(updatedItem.ItemId);

                if (item == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Item not found.";
                }
                else if (item is BookModel book)
                {
                    _context.Books.Remove(book);
                }
                else if (item is MagazineModel magazine)
                {
                    _context.Magazines.Remove(magazine);
                }
                else if (item is GameModel game)
                {
                    _context.Games.Remove(game);
                }
                await _context.SaveChangesAsync();
                if (updatedItem.Type == ItemType.Magazine)
                {
                    await AddItemToDb(title: updatedItem.Title, ISSN: updatedItem.ISSN, author: updatedItem.Author, condition: updatedItem.Condition, category: updatedItem.Category, 
                        itemId: updatedItem.ItemId, reservations: updatedItem.Reservations, currentLoanId: updatedItem.CurrentLoanId, avgRating: updatedItem.AvgRating);
                }
                else if (updatedItem.Type == ItemType.Book)
                {
                    await AddItemToDb(title: updatedItem.Title, ISBN: updatedItem.ISBN, author: updatedItem.Author, condition: updatedItem.Condition, category: updatedItem.Category,
                        itemId: updatedItem.ItemId, reservations: updatedItem.Reservations, currentLoanId: updatedItem.CurrentLoanId, avgRating: updatedItem.AvgRating);
                }
                else if (updatedItem.Type == ItemType.Game)
                {
                    await AddItemToDb(title: updatedItem.Title, condition: updatedItem.Condition,
                        itemId: updatedItem.ItemId, reservations: updatedItem.Reservations, currentLoanId: updatedItem.CurrentLoanId, avgRating: updatedItem.AvgRating);
                }
                await _context.SaveChangesAsync();
                serviceResponse.Data = GetAllItemTypes();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetItemDTO>>> UpdateAvgRating(int itemId)
        {
            Console.WriteLine("UpdateAvgRating");
            Console.WriteLine("itemId: " + itemId);
            ServiceResponse<List<GetItemDTO>> serviceResponse = new ServiceResponse<List<GetItemDTO>>();
            try
            {
                var itemIsInRatings = await _context.Ratings.AnyAsync(r => r.ItemId == itemId);
                double avgRating;

                if (itemIsInRatings)
                {
                    avgRating = await _context.Ratings.Where(r => r.ItemId == itemId).AverageAsync(r => r.Rating);
                    int num = await _context.Ratings.Where(r => r.ItemId == itemId).CountAsync();
                    Console.WriteLine("avgRating: " + avgRating);
                    Console.WriteLine("num: " + num);
                }
                else
                {
                    avgRating = 0;
                }

                Console.WriteLine("itemID: " + itemId);
                var item = await FindItemInTabels(itemId);
                Console.WriteLine("item: " + item);
                if (item != null)
                {
                    if (item is BookModel book)
                    {
                        Console.WriteLine("book");
                        Console.WriteLine("avgRating: " + avgRating);
                        book.AvgRating = avgRating;
                        _context.Books.Update(book);
                    }
                    else if (item is MagazineModel magazine)
                    {
                        Console.WriteLine("magazine");
                        Console.WriteLine("avgRating: " + avgRating);
                        magazine.AvgRating = avgRating;
                        _context.Magazines.Update(magazine);
                    }
                    else if (item is GameModel game)
                    {
                        Console.WriteLine("game");
                        Console.WriteLine("avgRating: " + avgRating);
                        game.AvgRating = avgRating;
                        _context.Games.Update(game);
                    }
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = GetAllItemTypes();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Item not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<bool>> IsReturnLongerThanWeekAgo(int itemId)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();
            try
            {
                DateTime date = DateTime.Now;
                MessageModel message = await _context.Messages.OrderByDescending(message => message.Date).FirstOrDefaultAsync(message => message.Type == MessageType.ReservationNotification && message.Payload == itemId.ToString());
                DateTime messageDate = message.Date;
                int receiverId = message.ReceiverId;
                TimeSpan timeSpan = date - messageDate;

                if (timeSpan.Days > 7)
                {

                    if (await RemoveReservation(itemId, receiverId))
                    {
                        serviceResponse.Data = true;
                        serviceResponse.Message = "Reservation removed";
                    }
                    else
                    {
                        serviceResponse.Data = false;
                        serviceResponse.Message = "Reservation not removed";
                    }
                    await _context.SaveChangesAsync();
                }
                else
                {
                    serviceResponse.Data = false;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        private List<GetItemDTO> GetAllItemTypes()
        {
            List<GetItemDTO> items = new List<GetItemDTO>();

            List<GetItemDTO> magazines = _context.Magazines.Select(m =>
                new GetItemDTO
                {
                    ItemId = m.ItemId,
                    Reservations = m.Reservations,
                    CurrentLoanId = m.CurrentLoanId,
                    Title = m.Title,
                    ISSN = m.ISSN,
                    Author = m.Author,
                    Condition = m.Condition,
                    Category = m.Category,
                    Type = ItemType.Magazine,
                    AvgRating = m.AvgRating
                }).ToList();
            List<GetItemDTO> books = _context.Books.Select(b =>
                new GetItemDTO
                {
                    ItemId = b.ItemId,
                    Reservations = b.Reservations,
                    CurrentLoanId = b.CurrentLoanId,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    Author = b.Author,
                    Condition = b.Condition,
                    Category = b.Category,
                    Type = ItemType.Book,
                    AvgRating = b.AvgRating
                }).ToList();
            List<GetItemDTO> games = _context.Games.Select(g =>
                new GetItemDTO
                {
                    ItemId = g.ItemId,
                    Reservations = g.Reservations,
                    CurrentLoanId = g.CurrentLoanId,
                    Title = g.Title,
                    Condition = g.Condition,
                    Type = ItemType.Game,
                    AvgRating = g.AvgRating
                }).ToList();
            items.AddRange(magazines);
            items.AddRange(books);
            items.AddRange(games);
            return items;
        }
        private async Task<object?> FindItemInTabels(int itemId)
        {
            Console.WriteLine("FindItemInTabels");
            Console.WriteLine("itemId: " + itemId);
            BookModel? book = await _context.Books.FirstOrDefaultAsync(b => b.ItemId == itemId);
            MagazineModel? magazine = await _context.Magazines.FirstOrDefaultAsync(m => m.ItemId == itemId);
            GameModel? game = await _context.Games.FirstOrDefaultAsync(g => g.ItemId == itemId);

            if (book != null)
            {
                Console.WriteLine("book: " + book);
                return book;
            }
            else if (magazine != null)
            {
                Console.WriteLine("magazine: " + magazine);
                return magazine;
            }
            else if (game != null)
            {
                Console.WriteLine("game: " + game);
                return game;
            }
            else
            {
                Console.WriteLine("nothing found");
                return null;
            }
        }
        private async Task AddItemToDb (string title, Condition condition, string? ISBN = null, string? ISSN = null, int? itemId = null, List<int>? reservations = null, 
            int? currentLoanId = null, double? avgRating = null, string? author = null, string? category = null) 
        {
            ItemModel item;
            if (!ISBN.IsNullOrEmpty())
            {
                item = new BookModel();
            }
            else if (!ISSN.IsNullOrEmpty())
            {
                item = new MagazineModel();
            }
            else 
            {
                item = new GameModel();
            }
            // If itemID is greater than 0, it means that the item already exists and we are updating it
            if (itemId != null)
            {
                item.ItemId = (int)itemId;
                item.Reservations = reservations ?? new List<int>();
                item.CurrentLoanId = currentLoanId ?? 0;
                if (avgRating != null)
                {
                    item.AvgRating = (double)avgRating;
                }
            }
            else
            {
                item.Reservations = new List<int>();
                item.CurrentLoanId = 0;
                item.AvgRating = 0;
            }
            item.Title = title;
            item.Condition = condition;
            if (item is BookModel book)
            {
                book.Author = author;
                book.Category = category;
                book.ISBN = ISBN;
                await _context.Books.AddAsync(book);
            }
            else if (item is MagazineModel magazine)
            {
                magazine.Author = author;
                magazine.Category = category;
                magazine.ISSN = ISSN;
                await _context.Magazines.AddAsync(magazine);
            }
            else if (item is GameModel game)
            {
                await _context.Games.AddAsync(game);
            }
            Task task = _context.SaveChangesAsync();
            await task;
            return;
        }

        async void AddReservationNotification(int itemId, int receiverId, string itemType)
        {
            AddMessageDTO newMessage = new AddMessageDTO
            {
                SenderId = 0,
                ReceiverId = receiverId,
                Date = DateTime.Now,
                Text = $"The {itemType} with the {itemId} you reserved is now available for loan.",
                Type = MessageType.ReservationNotification,
                Payload = itemId.ToString()
            };
            await _context.Messages.AddAsync(_mapper.Map<MessageModel>(newMessage));
        }

        private async Task<bool> RemoveReservation(int itemId, int receiverId)
        {
            BookModel? book = await _context.Books.FirstOrDefaultAsync(book => book.ItemId == itemId);
            MagazineModel? magazine = await _context.Magazines.FirstOrDefaultAsync(magazine => magazine.ItemId == itemId);
            GameModel? game = await _context.Games.FirstOrDefaultAsync(game => game.ItemId == itemId);

            if (book != null)
            {
                if ((book.Reservations != null || book.Reservations.Count > 0) && book.Reservations[0] == receiverId)
                {
                    book.Reservations.RemoveAt(0);
                    _context.Books.Update(book);
                    if (book.Reservations.Count > 0)
                    {
                        AddReservationNotification(itemId, book.Reservations[0], "book");
                    }
                    _context.SaveChanges();
                    return true;
                }
            }
            else if (magazine != null)
            {
                if ((magazine.Reservations != null || magazine.Reservations.Count > 0) && magazine.Reservations[0] == receiverId)
                {
                    magazine.Reservations.RemoveAt(0);
                    _context.Magazines.Update(magazine);
                    if (magazine.Reservations.Count > 0)
                    {
                        AddReservationNotification(itemId, magazine.Reservations[0], "magazine");
                    }
                    _context.SaveChanges();
                    return true;
                }
            }
            else if (game != null)
            {
                if ((game.Reservations != null || game.Reservations.Count > 0) && game.Reservations[0] == receiverId)
                {
                    game.Reservations.RemoveAt(0);
                    _context.Games.Update(game);
                    if (game.Reservations.Count > 0)
                    {
                        AddReservationNotification(itemId, game.Reservations[0], "game");
                    }
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}