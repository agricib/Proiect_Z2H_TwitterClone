using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using DataModels;
using User.Entities;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace BestChat
{
    [Authorize]
    public class Chat : Hub
    {
        

        public void RegisterMe()
        {
            var name = Context.User.Identity.Name;
            using (var db = new UserContext())
            {
                var user = db.UserSet
                    .SingleOrDefault(u => u.UserName == name);

                if (user == null)
                {
                    db.UserSet.Add(new UserInfo()
                    {
                        Latitude = 0,
                        Longitude = 0,
                        PositionDate = DateTime.Now,
                        Online = true,
                        UserName = name,
                        
                    });
                }
                db.SaveChanges();
            }

        }

    }
}
