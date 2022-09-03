using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Catalog.Posts
{
    public class UpdateRequest
    {
        public int postId { get; set; }
        public string title { get; set; }
        public string leter { get; set; }
        public string image { get; set; }
        public int like { get; set; }
        public int userId { get; set; }
    }
}
