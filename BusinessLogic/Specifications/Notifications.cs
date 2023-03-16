using Ardalis.Specification;
using Core.Entities;

namespace Core.Specifications
{
    public static class Notifications
    {
        public class ById : Specification<Notification>
        {
            public ById(int id)
            {
                Query
                    .Where(c => c.Id == id);
            }
        }
        public class ByUserId : Specification<Notification>
        {
            public ByUserId(string userId)
            {
                Query
                    .Where(c => c.UserId == userId);
            }
        }
    }
}
