namespace Core.DTOs
{
    public class GroupChatDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserDTO>? Members { get; set; }
        public ICollection<GroupChatMessageDTO>? Messages { get; set; }
    }
}