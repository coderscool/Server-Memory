using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Users
    {
        public int userId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Home { get; set; }
        public string Word { get; set; }
        public string Relation { get; set; }
        public string Image { get; set; }
        public string Date { get; set; }
    }
}
