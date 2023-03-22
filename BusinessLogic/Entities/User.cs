using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User : IdentityUser
    {
        public string? ProfilePictureUrl { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostLike> PostLikes { get; set; }
        public ICollection<CommentLike> CommentLikes { get; set; }
        public ICollection<Follow> Followers { get; set; }
        public ICollection<Follow> FollowedUsers { get; set; }
        public ICollection<GroupChatMessage> SentMessages { get; set; }
        public ICollection<GroupChatMessage> ReceivedMessages { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
