using Server.Application.Catalog.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Catalog.Profile
{
    public class ProfileModel<T> : GetPagingRequest
    {
        public List<T> Data { get; set; }
        public int TotalRecord { get; set; }
    }
}
