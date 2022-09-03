using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Catalog.Comments
{
    public class ListComments
    {
        public int commentId { get; set; }
        public int replyId { get; set; }
        public int postId { get; set; }
        public string Comment { get; set; }
        public int userId { get; set; }
        public int Count { get; set; }
        public bool Open { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
