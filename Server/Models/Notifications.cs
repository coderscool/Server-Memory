using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Notifications
    {
        public int notificationId { get; set; }
        public int userId1 { get; set; }
        public int userId2 { get; set; }
        public int postId { get; set; }
        public bool Watch { get; set; }
    }
}
