using Microsoft.Extensions.Configuration;
using System;

namespace ConsoleSignalRServer
{
    public class SignalRSettings
    {
        private static readonly Lazy<SignalRSettings> _instance = new Lazy<SignalRSettings>(() => new SignalRSettings());

        public static SignalRSettings Instance => _instance.Value;

        public IConfigurationRoot Configuration { get; }

        private SignalRSettings()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        /// <summary>
		/// Windows ServiceName
		/// </summary>
		public string ServiceName => Configuration["signalr.server.serviceName"];
        /// <summary>
        /// Windows ServiceDisplayName
        /// </summary>
        public string ServiceDisplayName => Configuration["signalr.server.serviceDisplayName"];
        /// <summary>
        /// Windows ServiceDescription
        /// </summary>
        public string ServiceDescription => Configuration["signalr.server.serviceDescription"];
        /// <summary>
        /// Windows ServiceAddress
        /// </summary>
        public string ServiceAddress => Configuration["signalr.server.serviceAddress"];
    }
}
