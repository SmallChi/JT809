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
            var versions = options.Version.Split(new string []{ "." }, StringSplitOptions.RemoveEmptyEntries);
            if (versions.Length == 3)
            {
                options.HeaderOptions.Version = new JT809Header_Version(byte.Parse(versions[0]), byte.Parse(versions[1]), byte.Parse(versions[2]));
            }
            else if(versions.Length == 2)
            {
                options.HeaderOptions.Version = new JT809Header_Version(byte.Parse(versions[0]), byte.Parse(versions[1]),0);
            }
            else if (versions.Length == 1)
            {
                options.HeaderOptions.Version = new JT809Header_Version(byte.Parse(versions[0]), 0, 0);
            }
            JT809GlobalConfig.Instance.SetHeaderOptions(options.HeaderOptions);
            JT809GlobalConfig.Instance.SetSkipCRCCode(options.SkipCRCCode);
            if (options.HeaderOptions.EncryptFlag == JT809Header_Encrypt.Common)
            {
                JT809GlobalConfig.Instance.SetEncrypt(new JT809EncryptImpl(options.EncryptOptions));
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
