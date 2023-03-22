namespace Core.DTOs
{
    public class GroupChatDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserDTO> Users { get; set; }
        public ICollection<GroupChatMessageDTO> Messages { get; set; }
    }
}