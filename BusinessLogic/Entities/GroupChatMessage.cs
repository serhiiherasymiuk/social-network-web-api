namespace Core.Entities
{
    public class GroupChatMessage
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
        public int GroupChatId { get; set; }
        public GroupChat GroupChat { get; set; }
    }
}
