using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace BestChat
{
    public class Chat : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.broascastMessage(name, message);
        }
    }
}