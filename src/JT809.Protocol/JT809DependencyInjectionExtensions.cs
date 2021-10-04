using JT809.Protocol.Enums;
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

        public static IJT809Builder AddJT809Configure(this IServiceCollection services, JT809Version version= JT809Version.JTT2011)
        {
            DefaultGlobalConfig config = new DefaultGlobalConfig();
            config.Version = version;
            services.AddSingleton<IJT809Config>(config);
            return new DefaultBuilder(services, config);
        }

        /// <summary>
        /// 目前只支持0x0200定位
        /// 0704需要拆分出来
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="jt808MsgId">0x0200</param>
        /// <param name="jt808AnalyzeCallback"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static IJT809Builder AddJT809_JT808AnalyzeCallback(this IJT809Builder builder, ushort jt808MsgId, JT808AnalyzeCallback jt808AnalyzeCallback,JT809Version version = JT809Version.JTT2011)
        {
            builder.Config.AnalyzeCallbacks.Add(jt808MsgId, jt808AnalyzeCallback);
            return builder;
        }
    }
}
