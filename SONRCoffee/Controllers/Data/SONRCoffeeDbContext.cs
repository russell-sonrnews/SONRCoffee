using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace SONRCoffee.Data
{
    public class SONRCoffeeDbContext : DbContext
    {
        public SONRCoffeeDbContext() : base("name=SONRCoffeeDbContext") {}

        public DbSet<Models.shop> shops { get; set; }
        public DbSet<Models.coffeeType> coffeeTypes { get; set; }
        public DbSet<Models.run> runs { get; set; }
        public DbSet<Models.user> users { get; set; }
        public DbSet<Models.option> options { get; set; }
        public DbSet<Models.defaultOrder> defaultOrders { get; set; }
        public DbSet<Models.order> orders { get; set; }
        public DbSet<Models.standingOrder> standingOrders { get; set; }
    }
}