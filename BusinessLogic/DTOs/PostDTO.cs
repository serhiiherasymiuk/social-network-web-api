namespace Core.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
    }
}
