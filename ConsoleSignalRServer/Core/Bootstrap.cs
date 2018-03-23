using log4net;
using Microsoft.Owin.Hosting;
using System;
using Topshelf;

namespace ConsoleSignalRServer.Core
{
    /// <summary>
	/// OWIN host
	/// </summary>
    internal class Bootstrap : ServiceControl
    {
        // log4net
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Bootstrap));
        private IDisposable SignalR;
        public string Address { get; set; }

        public bool Start(HostControl hostControl)
        {
            //throw new System.NotImplementedException();
            try
            {
                SignalR = WebApp.Start<Startup>(Address);
                _logger.Info("Server started at " + Address);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error("Topshelf starting occured errors.", ex);
                return false;
            }
        }

        public bool Stop(HostControl hostControl)
        {
            //throw new System.NotImplementedException();
            try
            {
                SignalR?.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Topshelf stopping occured errors.", ex);
                return false;
            }
        }
    }
}