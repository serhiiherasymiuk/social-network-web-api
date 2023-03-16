using Ardalis.Specification;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public static class Comments
    {
        public class ById : Specification<Comment>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id);
            }
        }
        public class ByUserId : Specification<Comment>
        {
            public ByUserId(string userId)
            {
                Query
                    .Where(x => x.UserId == userId);
            }
        }
        public class ByPostId : Specification<Comment>
        {
            public ByPostId(int postId)
            {
                Query
                    .Where(x => x.PostId == postId);
            }
        }
    }
}
