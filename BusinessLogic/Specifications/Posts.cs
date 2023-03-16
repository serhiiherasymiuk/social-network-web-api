using Ardalis.Specification;
using Core.Entities;

namespace Core.Specifications
{
    public static class Posts
    {
        public class ById : Specification<Post>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Comments)
                    .Include(x => x.PostLikes);
            }
        }
        public class OrderedByLikes : Specification<Post>
        {
            public OrderedByLikes()
            {
                Query
                    .OrderBy(x => x.PostLikes.Count)
                    .Include(x => x.Comments)
                    .Include(x => x.PostLikes);
            }
        }
        public class ByUserId : Specification<Post>
        {
            public ByUserId(string userId)
            {
                Query
                    .Where(x => x.UserId == userId)
                    .Include(x => x.Comments)
                    .Include(x => x.PostLikes);
            }
        }
    }
}
