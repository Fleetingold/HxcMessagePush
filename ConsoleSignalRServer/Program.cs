using ConsoleSignalRServer.Core;
using System;
using Topshelf;

namespace ConsoleSignalRServer
{
    class Program
    {
        static int Main(string[] args)
        {
            //var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            //XmlConfigurator.ConfigureAndWatch(logCfg);

            //HostFactory.New(x => );

            return (int)HostFactory.Run(x =>
            {
                //x.UseLog4Net("log4net.config");
                x.RunAsLocalSystem();

                x.SetServiceName("SignalRServer");
                x.SetDisplayName("SignalR Topshelf Server");
                x.SetDescription("using topshelf to host SignalR server,processing SignalR Client Connection etc.");
                

                x.UseOwin(baseAddress: "http://localhost:8080/");

                x.SetStartTimeout(TimeSpan.FromMinutes(5));
                x.SetStopTimeout(TimeSpan.FromMinutes(35));

                x.EnableServiceRecovery(r => { r.RestartService(1); });
            });
        }
    }
}
