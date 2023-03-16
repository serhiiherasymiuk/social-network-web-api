namespace Core.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }
        public ICollection<PostDTO>? Posts { get; set; }
        public ICollection<CommentDTO>? Comments { get; set; }
        public ICollection<PostLikeDTO>? Likes { get; set; }
        public ICollection<FollowDTO>? Followers { get; set; }
        public ICollection<FollowDTO>? FollowedUsers { get; set; }
        public ICollection<MessageDTO>? SentMessages { get; set; }
        public ICollection<MessageDTO>? ReceivedMessages { get; set; }
        public ICollection<NotificationDTO>? Notifications { get; set; }
    }
}
