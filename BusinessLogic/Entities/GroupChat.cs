using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class GroupChat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Members { get; set; }
        public ICollection<GroupChatMessage> Messages { get; set; }
    }
}
