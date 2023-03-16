namespace Core.DTOs
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        public string SenderId { get; set; }
        public string RecipientId { get; set; }
    }
}
