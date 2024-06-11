using Bambus.DTOs.ItemDtos;
using Bambus.Services.Item;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bambus.Controllers
{
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }


        [HttpPost("GetItems")]
        [AllowAnonymous]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                return Ok(await _itemService.GetAllItems());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("CreateItem")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateItem(AddItemDTO newItem)
        {
            try
            {
                return Ok(await _itemService.AddItem(newItem));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("DeleteItem")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteItem([FromQuery] int itemId)
        {
            try
            {
                return Ok(await _itemService.DeleteItem(itemId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateItem")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateItem(UpdateItemDTO updatedItem)
        {
            try
            {
                return Ok(await _itemService.UpdateItem(updatedItem));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("IsReturnLongerThanWeekAgo/{itemId}")]
        public async Task<IActionResult> isReturnLongerThanWeekAgo(int itemId)
        {
            try
            {
                return Ok(await _itemService.IsReturnLongerThanWeekAgo(itemId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateAvgRating/{itemId}")]
        public async Task<IActionResult> UpdateAvgRating(int itemId)
        {
            try
            {
                return Ok(await _itemService.UpdateAvgRating(itemId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}