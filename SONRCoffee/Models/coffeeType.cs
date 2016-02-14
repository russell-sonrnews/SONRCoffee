using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SONRCoffee.Models
{
    /// <summary>
    /// basic coffee type: latte, cappucino, etc.
    /// </summary>
    public class coffeeType
    {
        public int CoffeeTypeId { get; set; }
        public int Name { get; set; }
    }
}