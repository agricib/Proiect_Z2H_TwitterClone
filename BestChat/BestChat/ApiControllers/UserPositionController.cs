using BestChat.Models;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using User.Entities;

namespace BestChat.ApiControllers
{
    public class UserPositionController : ApiController
    {
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
        public void Post([FromBody]PositionModel position)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var context = new UserContext())
                {
                    var user = context.UserSet
                     .SingleOrDefault(b => b.UserName == User.Identity.Name);
                    if (user == null)
                    {

                        context.UserSet.Add(new UserInfo() { UserName = User.Identity.Name, Longitude = position.Longitude,
                            Latitude = position.Latitude,PositionDate=DateTime.Now,Online=true
                        });

                    }
                    else
                    {
                        user.Latitude = position.Latitude;
                        user.Longitude = position.Longitude;
                        user.PositionDate = DateTime.Now;
                        user.Online = true;
                    }
                    context.SaveChanges();                   
                }
            }
            else
            {
               
            }
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