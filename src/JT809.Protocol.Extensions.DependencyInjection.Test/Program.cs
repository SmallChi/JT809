using JT809.Protocol.Extensions.DependencyInjection.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace JT809.Protocol.Extensions.DependencyInjection.Test
{
    class Program
    {
        static async Task  Main(string[] args)
        {
            var serverHostBuilder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddJT809Configure(hostContext.Configuration.GetSection("JT809Options"));
                });
            await serverHostBuilder.RunConsoleAsync();
        }
    }
}
