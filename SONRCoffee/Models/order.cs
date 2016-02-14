using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using Newtonsoft.Json;

namespace SONRCoffee.Models
{
    public class order
    {
        public int OrderId { get; set; }
        public string OrderOrigin { get; set; }
        public DateTime OrderTime { get; set; }

        public order()
        {
            OrderOrigin = "default";
            OrderTime = DateTime.Now;
        }

        //foreign keys
        public int RunId { get; set; }
        public int UserId { get; set; }
        public int CoffeeTypeId { get; set; }

        //foreign objects
        public virtual run Run { get; set; }
        public virtual user User { get; set; }
        public virtual coffeeType CoffeeType { get; set; }
        public virtual List<option> Options { get; set; }
    }
}