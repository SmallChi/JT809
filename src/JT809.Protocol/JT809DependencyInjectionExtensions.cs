using JT809.Protocol.Interfaces;
using JT809.Protocol.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    public static class JT809DependencyInjectionExtensions
    {
        public static IJT809Builder AddJT809Configure(this IServiceCollection services, IJT809Config jT809Config)
        {
            services.AddSingleton(jT809Config.GetType(), jT809Config);
            services.AddSingleton(jT809Config);
            return new DefaultBuilder(services, jT809Config);
        }

        public static IJT809Builder AddJT809Configure(this IServiceCollection services)
        {
            DefaultGlobalConfig config = new DefaultGlobalConfig();
            services.AddSingleton<IJT809Config>(config);
            return new DefaultBuilder(services, config);
        }
    }
}
