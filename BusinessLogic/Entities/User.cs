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
        public ICollection<IndividualChat> IndividualChats { get; set; }
        public ICollection<GroupChat> GroupChats { get; set; }
        public ICollection<IndividualChatMessage> IndividualChatMessages { get; set; }
        public ICollection<GroupChatMessage> GroupChatMessages { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
