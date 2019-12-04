using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PlantRMVC2.Hubs
{
    public class ConnectionHub : Hub
    {
        public void NotifyRefresh()
        {
            Clients.All.clientRefresh();
        }
    }
}