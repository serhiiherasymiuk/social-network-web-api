﻿namespace Core.DTOs
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
    }
}
