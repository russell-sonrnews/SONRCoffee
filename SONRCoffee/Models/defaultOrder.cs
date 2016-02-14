using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SONRCoffee.Models
{
    public class defaultOrder
    {
        public int DefaultOrderId { get; set; }

        //foreign keys
        public int UserId { get; set; }
        public int CoffeeTypeId { get; set; }

        //foreign objects
        public virtual user User { get; set; }
        public virtual coffeeType CoffeeType { get; set; }
        public virtual List<option> defaultOptions { get; set; }
    }
}