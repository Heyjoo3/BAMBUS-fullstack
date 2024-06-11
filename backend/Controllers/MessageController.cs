using Bambus.DTOs.MessageDtos;
using Bambus.Services.Messages;
using Bambus.Validators.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bambus.Controllers
{
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("GetMessagesFromUserId/{userId}")]
        public async Task<IActionResult> GetMessagesFromUserId(int userId)
        {
            try
            {
                return Ok(await _messageService.GetMessagesFromUserId(userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("CreateMessage")]
        public async Task<IActionResult> AddMessage(AddMessageDTO newMessage)
        {
            try
            {
                var validator = new AddMessageValidator();
                var validationResult = validator.Validate(newMessage);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
                return Ok(await _messageService.AddMessage(newMessage));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("DeleteMessage/{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            try
            {
                return Ok(await _messageService.DeleteMessage(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("RequestPasswordReset")]
        [AllowAnonymous]
        public async Task<IActionResult> RequestPasswordReset(AddMessageDTO newMessage)
        {
            try
            {
                var validator = new AddMessageValidator();
                var validationResult = validator.Validate(newMessage);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
                return Ok(await _messageService.AddMessage(newMessage));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}