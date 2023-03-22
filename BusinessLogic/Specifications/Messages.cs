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
    public class Messages
    {
        public class ById : Specification<GroupChatMessage>
        {
            public ById(int id)
            {
                Query
                    .Where(c => c.Id == id);
            }
        }
        public class BySenderId : Specification<GroupChatMessage>
        {
            public BySenderId(string id)
            {
                Query
                    .Where(c => c.SenderId == id);
            }
        }
        public class ByRecipientId : Specification<GroupChatMessage>
        {
            public ByRecipientId(string id)
            {
                Query
                    .Where(c => c.RecipientId == id);
            }
        }
    }
}
