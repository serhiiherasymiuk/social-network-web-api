using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class IndividualChat
    {
        public int Id { get; set; }
        public string User1Id { get; set; }
        public User User1 { get; set; }
        public string User2Id { get; set; }
        public User User2 { get; set; }
        public ICollection<IndividualChatMessage> Messages { get; set; }
    }
}
