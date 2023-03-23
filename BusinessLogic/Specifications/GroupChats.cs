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
    public class GroupChats
    {
        public class ById : Specification<GroupChat>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Messages)
                    .Include(x => x.Members);
            }
        }
        public class All : Specification<GroupChat>
        {
            public All()
            {
                Query
                    .Include(x => x.Messages)
                    .Include(x => x.Members);
            }
        }
    }
}
