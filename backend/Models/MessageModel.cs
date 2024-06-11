using System.ComponentModel.DataAnnotations;
using Bambus.Enums;

namespace Bambus.Models
{
    public class MessageModel
    {
        [Key]
        public int MessageId { get; set; }
        public int SenderId { get; set; } = 0;
        public int ReceiverId { get; set; } = 0;
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public MessageType Type { get; set; }
        public string? Payload { get; set; }
    }
}