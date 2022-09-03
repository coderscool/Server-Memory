using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Catalog.Posts
{
    public class GetPagingRequest
    {
        public int _pages { get; set; }
        public int _limit { get; set; }
    }
}
