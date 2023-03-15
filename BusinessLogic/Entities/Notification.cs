namespace Core.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
