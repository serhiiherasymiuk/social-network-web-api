namespace Core.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
        public string RecipientId { get; set; }
        public User Recipient { get; set; }
    }
}
