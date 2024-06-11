using Bambus.DTOs.ItemDtos;
using Bambus.Models;

namespace Bambus.Services.Item
{
    public interface IItemService
    {
        Task<ServiceResponse<List<GetItemDTO>>> GetAllItems();
        Task<ServiceResponse<List<GetItemDTO>>> AddItem(AddItemDTO newItem);
        Task<ServiceResponse<List<GetItemDTO>>> DeleteItem(int itemId);
        Task<ServiceResponse<List<GetItemDTO>>> UpdateItem(UpdateItemDTO updatedItem);
        Task<ServiceResponse<bool>> IsReturnLongerThanWeekAgo(int itemId);
        Task<ServiceResponse<List<GetItemDTO>>> UpdateAvgRating(int itemId);
    }
}