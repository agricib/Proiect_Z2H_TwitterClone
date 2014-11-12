using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using DataModels;
using User.Entities;

namespace BestChat
{
    public class Chat : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.broascastMessage(name, message);
        }

        public void RegisterMe()
        {
            var name = Context.User.Identity.Name;
            using (var db = new UserContext())
            {
                var user = db.UserSet
                    .SingleOrDefault(u => u.UserName == name);
                
                if (user == null)
                {
                    user = new UserInfo
                    {
                        UserName = name,
                    };
                    db.UserSet.Add(user);
                }

                user.Online = true;

                db.SaveChanges();
            }
             
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
         {
            var name = Context.User.Identity.Name;
            using (var db = new UserContext())
            {
                var user = db.UserSet
                    .SingleOrDefault(u => u.UserName == name);
                
                if (user == null)
                {
                    user = new UserInfo
                    {
                        UserName = name,
                    };
                    db.UserSet.Add(user);
                }

                user.Online = false;

                db.SaveChanges();
            }
            return base.OnDisconnected(stopCalled);
        }

        }
    }
