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
    public class SearchController : ApiController
    {
        //at cand se face o cere de post catre server cauta in baza de date si returneaza toti utilizatorii care incep cu acel cuvant
        // POST api/<controller>
        public IEnumerable<UserInfo> Post([FromBody]string username)
        {
            using (var context = new UserContext())
            {
                var users = context.UserSet
                 .Where(b => b.UserName.StartsWith(username));
                return users;
            }
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}