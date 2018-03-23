using log4net;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSignalRServer.Hubs
{
    public class MyHub : Hub
    {
        readonly ILog _log = LogManager.GetLogger(typeof(MyHub));
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }

        public override Task OnConnected()
        {
            _log.Info("Client connected: " + Context.ConnectionId);

            return base.OnConnected();
        }
        public override Task OnDisconnected(bool ss)
        {
            _log.Info("Client disconnected: " + Context.ConnectionId);

            return base.OnDisconnected(ss);
        }
    }
}
