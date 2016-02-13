using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace SONRCoffee.Models
{
    public class order
    {
        public int OrderId { get; set; }

        //foreign keys
        public int RunId { get; set; }
        public int UserId { get; set; }
        public int CoffeeTypeId { get; set; }

        //foreign objects
        public run Run { get; set; }
        public user User { get; set; }
        public coffeeType CoffeeType { get; set; }
        public List<option> Options { get; set; }
    }
}