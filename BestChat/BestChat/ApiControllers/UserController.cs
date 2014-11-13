using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using User.Entities;

namespace BestChat.Controllers
{
    public class UserController : ApiController
    {
        public IEnumerable<UserInfo> Get()
        {
           using( var context = new UserContext()){
               return context.UserSet.ToList();   
            }
        }
    }
}
