using System;

namespace Core.DTOs
{
    public class GroupChatMessageDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        public string SenderId { get; set; }
        public int GroupChatId { get; set; }
    }
}