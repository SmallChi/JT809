using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JT809.Protocol.Test
{
    public class JT809DependencyInjectionExtensionsTest
    {
        [Fact]
        public void Test1()
        {
            var id = Guid.NewGuid().ToString("N");
            IServiceCollection serviceDescriptors1 = new ServiceCollection();
            serviceDescriptors1.AddJT809Configure(new DefaultConfig(id));
            var ServiceProvider1 = serviceDescriptors1.BuildServiceProvider();
            var defaultConfig = ServiceProvider1.GetRequiredService<IJT809Config>();
            Assert.Equal(id, defaultConfig.GetSerializer().SerializerId);
        }

        [Fact]
        public void Test2()
        {
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
            Assert.True(config1.GetSerializer().SerializerId == "Config1");

            var config2 = ServiceProvider2.GetRequiredService<Func<string, IJT809Config>>()("Config2");
            Assert.True(config2.GetSerializer().SerializerId == "Config2");
        }
    }

    public class DefaultConfig(string id = "default") : JT809GlobalConfigBase
    {
        public override string ConfigId => id;
    }

    public class Config1 : JT809GlobalConfigBase
    {
        public override string ConfigId => "Config1";
    }

    public class Config2 : JT809GlobalConfigBase
    {
        public override string ConfigId => "Config2";
    }
}
