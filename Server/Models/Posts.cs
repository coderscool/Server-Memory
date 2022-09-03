using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Posts
    {
        public int postId { get; set; }
        public string Title { get; set; }
        public string Leter { get; set; }
        public string Image { get; set; }
        public int Like { get; set; }
        public int userId { get; set; }
    }
}
