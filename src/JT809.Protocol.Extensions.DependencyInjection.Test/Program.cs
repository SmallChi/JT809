using JT809.Protocol.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace JT809.Protocol.Extensions.DependencyInjection.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //单个
            IServiceCollection serviceDescriptors1 = new ServiceCollection();
            serviceDescriptors1.AddJT809Configure(new DefaultConfig());
            var ServiceProvider1 = serviceDescriptors1.BuildServiceProvider();
            var defaultConfig = ServiceProvider1.GetRequiredService<IJT809Config>();

            //多个
            IServiceCollection serviceDescriptors2 = new ServiceCollection();
            serviceDescriptors2.AddJT809Configure(new Config1());
            serviceDescriptors2.AddJT809Configure(new Config2());
            serviceDescriptors2.AddSingleton(factory =>
            {
                Func<string, IJT809Config> accesor = key =>
                {
                    if (key.Equals("Config1"))
                    {
                        return factory.GetService<Config1>();
                    }
                    else if (key.Equals("Config2"))
                    {
                        return factory.GetService<Config2>();
                    }
                    else
                    {
                        throw new ArgumentException($"Not Support key : {key}");
                    }
                };
                return accesor;
            });

            var ServiceProvider2 = serviceDescriptors2.BuildServiceProvider();

            var config1 = ServiceProvider2.GetRequiredService<Func<string, IJT809Config>>()("Config1");
            var flag21 = config1.GetSerializer().SerializerId == "Config1";

            var config2 = ServiceProvider2.GetRequiredService<Func<string, IJT809Config>>()("Config2");
            var flag22 = config2.GetSerializer().SerializerId == "Config2";
        }
    }

    public class DefaultConfig : GlobalConfigBase
    {
        public override string ConfigId => "test";
    }

    public class Config1 : GlobalConfigBase
    {
        public override string ConfigId => "Config1";
    }

    public class Config2 : GlobalConfigBase
    {
        public override string ConfigId => "Config2";
    }
}
