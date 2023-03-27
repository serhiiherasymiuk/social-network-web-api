namespace Core.DTOs
{
    public class IndividualChatDTO
    {
        public int Id { get; set; }
        public string User1Id { get; set; }
        public string User2Id { get; set; }
        public ICollection<IndividualChatMessageDTO> Messages { get; set; }
    }
}
