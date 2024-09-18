using AutoMapper;
using Bambus.Data;
using Bambus.DTOs.MessageDtos;
using Bambus.Enums;
using Bambus.Models;
using Microsoft.EntityFrameworkCore;

namespace Bambus.Services.Messages

{
    public class MessageService : IMessageService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MessageService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetMessageDTO>>> AddMessage(AddMessageDTO newMessage)
        {
            ServiceResponse<List<GetMessageDTO>> response = new ServiceResponse<List<GetMessageDTO>>();
            var message = _mapper.Map<MessageModel>(newMessage);

            if (newMessage.Type == MessageType.ReturnOverdue)
            {
                UserModel user = await _context.Users.FirstOrDefaultAsync(user => user.UserId == newMessage.ReceiverId);
                user.NumberMissedReturns++;
                _context.Users.Update(user);
            }
            else if (newMessage.Type == MessageType.PasswordReset)
            {
                UserModel user = await _context.Users.FirstOrDefaultAsync(user => user.Email == newMessage.Payload);
                UserModel admin = await _context.Users.FirstOrDefaultAsync(user => user.Role == Role.Admin);
                if (user != null)
                {
                   message.SenderId = user.UserId;
                   message.ReceiverId = admin.UserId;
                }
                else
                {
                    response.Success = false;
                    response.Message = "User not found";
                    return response;
                }
            }
            else if (newMessage.Type == MessageType.DamageReport 
                || newMessage.Type == MessageType.ExtensionRequest)
            {
                UserModel manager = await _context.Users.FirstOrDefaultAsync(user => user.Role == Role.Manager);
                message.ReceiverId = manager.UserId;
            }

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            response.Data = (_context.Messages
                .Where(message => message.ReceiverId == newMessage.ReceiverId || message.ReceiverId == 0)
                .OrderByDescending(message => message.Date)
                .Select(message => _mapper.Map<GetMessageDTO>(message)))
                .ToList();
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteMessage(int id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            MessageModel message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                response.Success = false;
                response.Message = "Message not found";
                return response;
            }
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            response.Data = true;
            response.Message = "Message deleted";
            response.Success = true;
            return response;
        }

        public async Task<ServiceResponse<List<GetMessageDTO>>> GetMessagesFromUserId(int userId)
        {
            ServiceResponse<List<GetMessageDTO>> messages = new ServiceResponse<List<GetMessageDTO>>();
            List<MessageModel> dbMessages = await _context.Messages.Where(message => message.ReceiverId == userId || message.ReceiverId == 0).OrderByDescending(message => message.Date).ToListAsync();
            messages.Data = dbMessages.Select(message => _mapper.Map<GetMessageDTO>(message)).ToList();
            return messages;
        }
    }
}
