using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Catalog.Posts
{
    public class PageModel<T> : GetPagingRequest
    {
        public List<T> Data { get; set; }
        public int TotalRecord { get; set; }

    }
}
