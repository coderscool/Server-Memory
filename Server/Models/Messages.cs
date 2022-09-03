using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Messages
    {
        public int messageId { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }
    }
}
