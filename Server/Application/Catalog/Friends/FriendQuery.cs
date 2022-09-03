using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Catalog.Friends
{
    public class FriendQuery
    {
        public int friendId { get; set; }
        public int userId { get; set; }
        public int _local { get; set; }
    }
}
