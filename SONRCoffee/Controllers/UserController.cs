using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SONRCoffee.Controllers
{
    public class UserController
    {
        public static List<Models.user> GetUsers()
        {
            try
            {
                using (var db = new SONRCoffee.Data.SONRCoffeeDbContext())
                {
                    return db.users.ToList();
                }
            }   
            catch(Exception ex)
            {
                throw new Exception("Error retrieving user list", ex);
            }
        }
          
        public static Models.user GetUser(int userId)
        {
            Models.user thisUser;
            try {
                using (var db = new SONRCoffee.Data.SONRCoffeeDbContext())
                {
                    thisUser = db.users.SingleOrDefault(s => s.UserId == userId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error finding user", ex);
            }
            return thisUser;
        }
    }
}