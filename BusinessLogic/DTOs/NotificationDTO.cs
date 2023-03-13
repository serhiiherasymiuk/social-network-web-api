using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }
    }
}
