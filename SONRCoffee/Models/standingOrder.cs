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
    /// <summary>
    /// class to denote an order that is wanted before a run is declared
    /// </summary>
    public class standingOrder
    {
        public int StandingOrderId { get; set; }
        public DateTime StandingOrderTime { get; set; }

        public standingOrder()
        {
            StandingOrderTime = DateTime.Now;
        }

        //foreign keys
        public int UserId { get; set; }
        public int CoffeeTypeId { get; set; }

        //foreign objects
        public virtual user User { get; set; }
        public virtual coffeeType CoffeeType { get; set; }
        public virtual List<option> Options { get; set; }
    }
}