using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class FollowDTO
    {
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public int FollowedUserId { get; set; }
    }
}
