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
    public class IndividualChatMessages
    {
        public class ById : Specification<IndividualChatMessage>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id);
            }
        }
        public class ByIndividualChatId : Specification<IndividualChatMessage>
        {
            public ByIndividualChatId(int individualChatId)
            {
                Query
                    .Where(x => x.IndividualChatId == individualChatId);
            }
        }
        public class BySenderId : Specification<IndividualChatMessage>
        {
            public BySenderId(string senderId)
            {
                Query
                    .Where(x => x.SenderId == senderId);
            }
        }
    }
}
