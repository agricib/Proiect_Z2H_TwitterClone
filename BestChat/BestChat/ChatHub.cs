﻿using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;

namespace BestChat
{
    [Authorize]
    public class ChatHub : Hub
    {
        public void Send(string names, string message)
        {
            string name = Context.User.Identity.Name;
            Clients.Group(names).addNewMessageToPage(name + ": " + message);
        }

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;

            Groups.Add(Context.ConnectionId, name);

            return base.OnConnected();
        }
    }
}