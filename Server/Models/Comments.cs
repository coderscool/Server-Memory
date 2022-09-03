using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Comments
    {
        public int commentId { get; set; }
        public int replyId { get; set; }
        public int postId { get; set; }
        public string Comment { get; set; }
        public int userId { get; set; }
        public int Count { get; set; }
    }
}
