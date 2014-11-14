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
        private readonly static ConnectionMapping<string> _connections = new ConnectionMapping<string>();
       
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
        //public void SendChatMessage(string who, string message)
        //{
        //    string name = Context.User.Identity.Name;

        //    foreach (var connectionId in _connections.GetConnections(who))
        //    {
        //        Clients.Client(connectionId).addChatMessage(name + ": " + message);
        //    }
        //}

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;

            _connections.Add(name, Context.ConnectionId);

            return base.OnConnected();
        }

        //public override Task OnDisconnected(bool stopCalled)
        //{
        //    string name = Context.User.Identity.Name;

        //    _connections.Remove(name, Context.ConnectionId);

        //    return base.OnDisconnected(stopCalled);
        //}

        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;

            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }

            return base.OnReconnected();
        }

    }
}
