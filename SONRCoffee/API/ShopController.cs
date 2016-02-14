using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;

namespace SONRCoffee.API
{
    public class ShopController : ApiController
    {
        /*
        GET
        api/shops - list of shops
        api/shops/{id} - shop details
        api/shops/{id}/runs - runs for this shop
        api/shops/{id}/orders - orders for this shop

        POST
        api/shops - create new shop
        
        PUT
        api/shops - update shop

        DELETE
        api/shops - delete shop
        */

        /// <summary>
        /// List of shops
        /// </summary>
        /// <returns>Array of JSON objects</returns>
        [Route("api/shops")]
        public HttpResponseMessage Get()
        {
            JArray shops = new JArray();

            try
            {
                using (var db = new SONRCoffee.Data.SONRCoffeeDbContext())
                {
                    foreach (Models.shop s in db.shops)
                    {
                        shops.Add(JObject.FromObject(s));
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, shops);
        }

        /// <summary>
        /// Gets details of a shop
        /// </summary>
        /// <param name="id">shop ID</param>
        /// <returns>JSON object of shop data</returns>
        [Route("api/shops/{id}")]
        public HttpResponseMessage Get(int id)
        {
            Models.shop thisShop;

            try
            {
                using (var db = new SONRCoffee.Data.SONRCoffeeDbContext())
                {
                    thisShop = db.shops.SingleOrDefault(s => s.ShopId == id);

                    if (thisShop == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "shop id " + id.ToString() + " not found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(thisShop));
        }

        /// <summary>
        /// Get all runs for a shop
        /// </summary>
        /// <param name="id">shop ID</param>
        /// <returns>Array of JSON run objects</returns>
        [Route("api/shops/{id}/runs")]
        public HttpResponseMessage GetRuns(int id)
        {
            List<Models.run> runs = new List<Models.run>();
            JArray runArray = new JArray();

            try
            {
                using (var db = new SONRCoffee.Data.SONRCoffeeDbContext())
                {
                    runs = db.runs.Where(s => s.ShopId == id).ToList();

                    foreach(Models.run r in runs)
                    {
                        runArray.Add(JToken.FromObject(r));
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, runArray);
        }

        /// <summary>
        /// get all orders put in at a particular shop
        /// </summary>
        /// <param name="id">shop id</param>
        /// <returns>JSON array of orders</returns>
        [Route("api/shops/{id}/orders")]
        public HttpResponseMessage GetOrders(int id)
        {
            List<Models.order> orders = new List<Models.order>();
            JArray orderArray = new JArray();

            try
            {
                using (var db = new SONRCoffee.Data.SONRCoffeeDbContext())
                {
                    orders = db.orders.SqlQuery("select * from orders o join runs r on o.runid = r.runid where r.shopid = shopIdParam", new SqlParameter("shopIdParam",id)).ToList();

                    foreach (Models.order o in orders)
                    {
                        orderArray.Add(JToken.FromObject(o));
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, orderArray);
        }

        /// <summary>
        /// create a new shop
        /// </summary>
        /// <param name="newShop">JSON object of shop data</param>
        /// <returns>JSON object of shop data</returns>
        [Route("api/shops")]
        public HttpResponseMessage Post([FromBody]Models.shop newShop)
        {
            try
            {
                newShop.ShopId = 0;

                using (var db = new SONRCoffee.Data.SONRCoffeeDbContext())
                {
                    db.shops.Add(newShop);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(newShop));
        }

        /// <summary>
        /// update a shop
        /// </summary>
        /// <param name="updatedShop">JSON shop data object</param>
        /// <returns>JSON shop data object</returns>
        [Route("api/shops")]
        public HttpResponseMessage Put([FromBody]Models.shop updatedShop)
        {
            try
            {
                using (var db = new SONRCoffee.Data.SONRCoffeeDbContext())
                {
                    var originalShop = db.shops.Find(updatedShop.ShopId);
                    if (originalShop != null)
                    {
                        db.Entry(originalShop).CurrentValues.SetValues(updatedShop);
                        db.SaveChanges();
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "shop id not recognized");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(updatedShop));
        }

        /// <summary>
        /// delete a shop
        /// </summary>
        /// <param name="id">shop id</param>
        /// <returns>HTTP status code</returns>
        [Route("api/shops")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (var db = new SONRCoffee.Data.SONRCoffeeDbContext())
                {
                    var originalShop = db.shops.Find(id);
                    if (originalShop != null)
                    {
                        db.shops.Remove(originalShop);
                        db.SaveChanges();
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "shop id not recognized");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}