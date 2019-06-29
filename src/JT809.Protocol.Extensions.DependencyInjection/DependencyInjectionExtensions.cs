using Microsoft.Extensions.DependencyInjection;
using JT809.Protocol.Interfaces;

namespace JT809.Protocol.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddJT809Configure(this IServiceCollection services, IJT809Config jT809Config)
        {
            services.AddSingleton(jT809Config.GetType(), jT809Config);
            services.AddSingleton(jT809Config);
            return services;
        }

        public static IServiceCollection AddJT809Configure(this IServiceCollection services)
        {
            services.AddSingleton<IJT809Config>(new DefaultGlobalConfig());
            return services;
        }

        class DefaultGlobalConfig : GlobalConfigBase
        {
            public override string ConfigId => "default";
        }
    }
}
