﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Catalog.Comments
{
    public class CommentModel<T>
    {
        public List<T> data { get; set; }
    }
}
