using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SONRCoffee.Models
{
    public class run
    {
        public int RunId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime Deadline { get; set; }

        //foreign keys
        public int ShopId { get; set; }
        public int RunnerId { get; set; }

        //foreign objects
        public virtual List<order> orders { get; set; }
        public virtual shop Shop { get; set; }
        public virtual user Runner { get; set; }
    }
}