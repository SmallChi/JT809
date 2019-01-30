using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using JT809.Protocol.JT809Configs;
using Microsoft.Extensions.Configuration;
using JT809.Protocol.JT809Encrypt;
using JT809.Protocol.Extensions.DependencyInjection.Options;
using Microsoft.Extensions.Options;

namespace JT809.Protocol.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddJT809Configure(this IServiceCollection services, IConfiguration  configuration)
        {
            services.Configure<JT809Options>(configuration);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            JT809Options options = serviceProvider.GetRequiredService<IOptions<JT809Options>>().Value;
            JT809GlobalConfig.Instance.SetHeaderOptions(options.HeaderOptions);
            JT809GlobalConfig.Instance.SetSkipCRCCode(options.SkipCRCCode);
            if (options.HeaderOptions.EncryptFlag == JT809Header_Encrypt.Common)
            {
                JT809GlobalConfig.Instance.SetEncryptOptions(options.EncryptOptions);
            }
            try
            {
                var msgSNDistributedImpl = services.BuildServiceProvider().GetRequiredService<IMsgSNDistributed>();
                JT809GlobalConfig.Instance.SetMsgSNDistributed(msgSNDistributedImpl);
            }
            catch
            {
                
            }
            return services;
        }

        public static IServiceCollection AddJT809Configure(this IServiceCollection services, IOptions<JT809Options>  jT809Options)
        {
            JT809GlobalConfig.Instance.SetHeaderOptions(jT809Options.Value.HeaderOptions);
            JT809GlobalConfig.Instance.SetSkipCRCCode(jT809Options.Value.SkipCRCCode);
            if (jT809Options.Value.HeaderOptions.EncryptFlag == JT809Header_Encrypt.Common)
            {
                JT809GlobalConfig.Instance.SetEncryptOptions(jT809Options.Value.EncryptOptions);
            }
            try
            {
                var msgSNDistributedImpl = services.BuildServiceProvider().GetRequiredService<IMsgSNDistributed>();
                JT809GlobalConfig.Instance.SetMsgSNDistributed(msgSNDistributedImpl);
            }
            catch
            {

            }
            return services;
        }
    }
}
