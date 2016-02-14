using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SONRCoffee.Models
{
    /// <summary>
    /// a participant in SONR Coffee
    /// </summary>
    public class user
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string DeviceId { get; set; } // apple device ID for push
        public DateTime NotBeforeTime { get; set; } // don't alert me if the run is before this time
        public bool InTheRound { get; set; } // overall participation flag

        public user()
        {
            NotBeforeTime = DateTime.Parse("2016-01-01 09:00:00.000");
            InTheRound = true;
        }
    }
}