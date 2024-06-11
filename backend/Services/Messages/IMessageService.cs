using Bambus.Models;
using Bambus.DTOs.MessageDtos;

namespace Bambus.Services.Messages
{
    public interface IMessageService
    {
        Task<ServiceResponse<List<GetMessageDTO>>> AddMessage(AddMessageDTO newMessage);
        Task<ServiceResponse<bool>> DeleteMessage(int id);
        Task<ServiceResponse<List<GetMessageDTO>>> GetMessagesFromUserId(int userId);

    }
}
