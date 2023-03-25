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
    public class GroupChatMessages
    {
        public class ById : Specification<GroupChatMessage>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id);
            }
        }
        public class ByGroupChatId : Specification<GroupChatMessage>
        {
            public ByGroupChatId(int groupChatId)
            {
                Query
                    .Where(x => x.GroupChatId == groupChatId);
            }
        }
        public class BySenderId : Specification<GroupChatMessage>
        {
            public BySenderId(string senderId)
            {
                Query
                    .Where(x => x.SenderId == senderId);
            }
        }
    }
}
