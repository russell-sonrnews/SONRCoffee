using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SONRCoffee.Models
{
    public class order
    {
        public int id { get; set; }
        public int runId { get; set; }
        public int userId { get; set; }
        public string coffeeType { get; set; }
        public string options { get; set; }
    }
}