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
                    // 方式1：
                    //services.AddJT809Configure(hostContext.Configuration.GetSection("JT809Options"));
                    // 方式2:
                    services.AddJT809Configure(new JT809Options
                    {
                        HeaderOptions=new JT809Configs.JT809HeaderOptions {
                          MsgGNSSCENTERID=20181012,
                          EncryptFlag= JT809Header_Encrypt.Common,
                          EncryptKey= 9999,
                          Version = new  JT809Header_Version{
                            Major=2,
                            Minor=1,
                            Build= 2
                          }
                        },
                        EncryptOptions = new JT809Configs.JT809EncryptOptions {
                          M1= 10000000,
                          IA1=20000000,
                          IC1=30000000
                        }
                    });
                });
            await serverHostBuilder.RunConsoleAsync();
        }
    }
}
