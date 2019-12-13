using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PlantRMVC2.Hubs
{
    public class ConnectionHub : Hub
    {

        //calls to all in the same group to refresh
        public void NotifyRefresh(string room)
        {
            Clients.Group(room).clientRefresh();
        }

        //allows joining of a group
        public Task JoinRoom(string room)
        {
            return Groups.Add(Context.ConnectionId, room);
        }

        //allows leaving of a group
        public Task LeaveRoom(string room)
        {
            return Groups.Remove(Context.ConnectionId, room);
        }

    }
}