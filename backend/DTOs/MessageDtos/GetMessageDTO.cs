using Bambus.Enums;

namespace Bambus.DTOs.MessageDtos
{
    public class GetMessageDTO
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public MessageType Type { get; set; }
        public string Payload { get; set; }
    }
}
