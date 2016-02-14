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

namespace SONRCoffee.API
{
    public class UserController : ApiController
    {
        /// <summary>
        /// Gets list of registered users
        /// </summary>
        /// <returns>Array of JSON objects</returns>
        [Route("api/users")]
        public HttpResponseMessage GetUsers()
        {
            JArray users = new JArray();

            try
            {
                using (var db = new SONRCoffee.Data.SONRCoffeeDbContext())
                {
                    foreach (Models.user u in db.users)
                    {
                        users.Add(JObject.FromObject(u));
                    }
                } 
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        /// <summary>
        /// Gets information about a user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>JSON object of user data</returns>
        [Route("api/users/{id}")]
        public HttpResponseMessage GetUser(int id)
        {
            Models.user thisUser;

            try
            {
                using (var db = new SONRCoffee.Data.SONRCoffeeDbContext())
                {
                    thisUser = db.users.SingleOrDefault(s => s.UserId == id);

                    if(thisUser == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "user id " + id.ToString() + " not found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(thisUser));
        }

        /// <summary>
        /// Creates new user
        /// </summary>
        /// <param name="newUser">JSON object of user data, user ID will be ignored</param>
        /// <returns>JSON object of user data</returns>
        [Route("api/users")]
        public HttpResponseMessage Post([FromBody]Models.user newUser)
        {
            try
            {
                newUser.UserId = 0;

                using (var db = new SONRCoffee.Data.SONRCoffeeDbContext())
                {
                    db.users.Add(newUser);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(newUser));
        }

        /// <summary>
        /// Update existing user
        /// </summary>
        /// <param name="updatedUser">JSON object of user data</param>
        /// <returns>JSON object of user data</returns>
        [Route("api/users")]
        public HttpResponseMessage Put([FromBody]Models.user updatedUser)
        {
            try
            {
                using (var db = new SONRCoffee.Data.SONRCoffeeDbContext())
                {
                    var originalUser = db.users.Find(updatedUser.UserId);
                    if(originalUser != null)
                    {
                        db.Entry(originalUser).CurrentValues.SetValues(updatedUser);
                        db.SaveChanges();
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "user id not recognized");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(updatedUser));
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>HTTP status code</returns>
        [Route("api/users/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (var db = new SONRCoffee.Data.SONRCoffeeDbContext())
                {
                    var originalUser = db.users.Find(id);
                    if (originalUser != null)
                    {
                        db.users.Remove(originalUser);
                        db.SaveChanges();
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "user id not recognized");
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