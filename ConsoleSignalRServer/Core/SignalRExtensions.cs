using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.HostConfigurators;

namespace ConsoleSignalRServer.Core
{
    public static class SignalRExtensions
    {
        public static HostConfigurator UseOwin(this HostConfigurator configurator,string baseAddress)
        {
            if (string.IsNullOrEmpty(baseAddress)) throw new ArgumentNullException(nameof(baseAddress));

            configurator.Service(() => new Bootstrap { Address = baseAddress });

            return configurator;
        }
    }
}
