using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SONRCoffee.Models
{
    /// <summary>
    /// options for a coffee: soy milk, extra shot, etc.
    /// </summary>
    public class option
    {
        public int OptionId { get; set; }
        public string Name { get; set; }
    }
}