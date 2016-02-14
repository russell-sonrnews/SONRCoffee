using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SONRCoffee.API
{
    public class RunController : ApiController
    {
        /*
        GET
        api/runs - list of runs
        api/runs/{id} - run details
        api/runs/{id}/orders - orders for this run
        api/runs/{id}/users - users on this run

        POST
        api/shops - create new shop
        
        PUT
        api/shops - update shop

        DELETE
        api/shops - delete shop
        */

            // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}