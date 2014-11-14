using DataModels;
using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;
using System.Linq;
using User.Entities;

namespace BestChat
{
    [Authorize]
    public class ChatHub : Hub
    {
        public void Send(string names, string message)
        {
            string name = Context.User.Identity.Name;
            Clients.Group(names).addNewMessageToPage(name + ": " + message);
            //using (var context = new UserContext())
            //{
            //    context.MessageSet.Add(new Message()
            //    {
            //        Sender=name.ToString(),
            //        Receiver=names.ToString(),
            //        TextMessage=message,
            //        Time = DateTime.Now
            //    });
            //    context.SaveChanges();
            //}
        }

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;

            Groups.Add(Context.ConnectionId, name);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var name = Context.User.Identity.Name;
            using (var context = new UserContext())
            {
                var user  = context.UserSet
                     .SingleOrDefault(b => b.UserName == name);
                user.Online = false;
                context.SaveChanges(); 
            }
            

            Groups.Remove(Context.ConnectionId, name);
            
            return base.OnDisconnected(stopCalled);
        }
        public override Task OnReconnected()
        {
            var name = Context.User.Identity.Name;
            using (var context = new UserContext())
            {
                var user = context.UserSet
                     .SingleOrDefault(b => b.UserName == name);
                user.Online = true;
                context.SaveChanges();

            }
            Groups.Add(Context.ConnectionId, name);
            return base.OnReconnected();
           
        }

    }
}