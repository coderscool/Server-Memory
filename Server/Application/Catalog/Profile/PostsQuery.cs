using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Catalog.Profile
{
    public class PostsQuery
    {
        public int userId { get; set; }
        public int _pages { get; set; }
        public int _limit { get; set; }
    }
}
