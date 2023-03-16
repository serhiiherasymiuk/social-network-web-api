namespace Core.DTOs
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
    }
}
