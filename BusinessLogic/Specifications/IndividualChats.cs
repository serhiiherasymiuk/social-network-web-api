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
    public class IndividualChats
    {
        public class ById : Specification<IndividualChat>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Messages);
            }
        }
        public class ByUserId : Specification<IndividualChat>
        {
            public ByUserId(string userId)
            {
                Query
                    .Where(x => x.User1Id == userId || x.User2Id == userId)
                    .Include(x => x.Messages);
            }
        }
        public class All : Specification<IndividualChat>
        {
            public All()
            {
                Query
                    .Include(x => x.Messages);
            }
        }
    }
}
