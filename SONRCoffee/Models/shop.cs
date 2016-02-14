using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SONRCoffee.Models
{
    /// <summary>
    /// a particular coffee shop brand: Nero, Costa, etc.
    /// </summary>
    public class shop
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
    }
}