namespace Core.DTOs
{
    public class IndividualChatDTO
    {
        public string Id { get; set; }
        public string User1Id { get; set; }
        public string User2Id { get; set; }
        public ICollection<IndividualChatMessageDTO> Messages { get; set; }
    }
}
