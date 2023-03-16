using Ardalis.Specification;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Core.Specifications
{
    public static class Users
    {
        public class ById : Specification<User>
        {
            public ById(int id)
            {
                Query
                    //.Where(x => x.Id == id)
                    .Include(x => x.Posts)
                    .Include(x => x.Comments)
                    .Include(x => x.Likes)
                    .Include(x => x.Followers)
                    .Include(x => x.FollowedUsers)
                    .Include(x => x.SentMessages)
                    .Include(x => x.ReceivedMessages)
                    .Include(x => x.Notifications);
            }
        }
        public class OrderedAll : Specification<User>
        {
            public OrderedAll()
            {
                Query
                    //.OrderBy(x => x.Username)
                    .Include(x => x.Posts)
                    .Include(x => x.Comments)
                    .Include(x => x.Likes)
                    .Include(x => x.Followers)
                    .Include(x => x.FollowedUsers)
                    .Include(x => x.SentMessages)
                    .Include(x => x.ReceivedMessages)
                    .Include(x => x.Notifications);
            }
        }
    }
}
