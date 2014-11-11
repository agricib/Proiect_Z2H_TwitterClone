using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestChat

{
    public class PositionHub : Hub
    {
        public void SendPosition(double X_Coord, double Y_Coord)
        {
            Clients.All.addPosition(X_Coord, Y_Coord);
        }
    }
}