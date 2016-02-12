using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SONRCoffee.Models
{
    public class run
    {
        public int id { get; set; }
        public int runnerId { get; set; }
        public DateTime createdTime { get; set; }
        public DateTime deadline { get; set; }
        public int shopID { get; set; }
    }
}