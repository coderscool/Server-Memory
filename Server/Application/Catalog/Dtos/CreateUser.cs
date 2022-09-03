using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Catalog.Dtos
{
    public class CreateUser
    {
        public int userId { get; set; }
        public string Name { get; set; }
        public string Home { get; set; }
        public string Word { get; set; }
        public string Relation { get; set; }
        public string Image { get; set; }
        public string Date { get; set; }
        public bool Success { get; set; }
    }
}
