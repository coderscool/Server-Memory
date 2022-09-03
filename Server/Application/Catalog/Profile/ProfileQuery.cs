using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Catalog.Profile
{
    public class ProfileQuery
    {
        public int userId { get; set; }
        public string Name { get; set; }
        public string Home { get; set; }
        public string Word { get; set; }
        public string Relation { get; set; }
        public string Image { get; set; }
        public string Date { get; set; }
        public int friendId { get; set; }
        public int FriendId1 { get; set; }
        public int FriendId2 { get; set; }
        public bool IsFriend { get; set; }
    }
}
