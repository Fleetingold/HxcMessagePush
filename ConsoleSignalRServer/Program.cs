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
                x.UseLog4Net("log4net.config");
                x.RunAsLocalSystem();

                x.SetServiceName(SignalRSettings.Instance.ServiceName);
                x.SetDisplayName(SignalRSettings.Instance.ServiceDisplayName);
                x.SetDescription(SignalRSettings.Instance.ServiceDescription);
                

                x.UseOwin(baseAddress: SignalRSettings.Instance.ServiceAddress);

                x.SetStartTimeout(TimeSpan.FromMinutes(5));
                x.SetStopTimeout(TimeSpan.FromMinutes(35));

                x.EnableServiceRecovery(r => { r.RestartService(1); });
            });
        }
    }
}
