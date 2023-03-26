using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class IndividualChatMessage
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
        public int IndividualChatId { get; set; }
        public IndividualChat IndividualChat { get; set; }
    }
}
