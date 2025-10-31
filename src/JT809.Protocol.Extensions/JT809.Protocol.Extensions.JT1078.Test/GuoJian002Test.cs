using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Internal;
using JT809.Protocol.Enums;
using JT809.Protocol.Interfaces;
using System.Text.Encodings.Web;
using System.Text.Json;
using JT808.Protocol;
using Microsoft.Extensions.DependencyInjection;

namespace JT809.Protocol.Extensions.JT1078.Test
{
    public class GuoJian002Test
    {
        private JsonWriterOptions options = new JsonWriterOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        private JT809Serializer JT809_2019_Serializer;

        private GuoJian002_GlobalConfig guoJian001_GlobalConfig;

        public GuoJian002Test()
        {
            guoJian001_GlobalConfig = new GuoJian002_GlobalConfig();
            IServiceCollection serviceDescriptors1 = new ServiceCollection();
            serviceDescriptors1.AddJT809Configure(guoJian001_GlobalConfig)
                               .AddJT1078Configure();
            var ServiceProvider1 = serviceDescriptors1.BuildServiceProvider();
            var defaultConfig = ServiceProvider1.GetRequiredService<IJT809Config>();
            JT809_2019_Serializer = defaultConfig.GetSerializer();
        }

        [Fact(DisplayName = "2019版序列化-大兄弟提供1")]
        public void GuoJian001_2019_1()
        {
            var bytes = "5B000000610000000118000000000000000000000000000000000068EA24F5D4C14138383838380000000000000000000000000001180100000023003132372E302E302E310000000000000000000000000000000000000000000000043656F35D".ToHexBytes();
            string json = JT809_2019_Serializer.Analyze(bytes, options);
        }

        class GuoJian002_GlobalConfig : JT809GlobalConfigBase
        {
            public GuoJian002_GlobalConfig()
            {
                Version = JT809Version.JTT2019;  
                EncryptOptions = new Configs.JT809EncryptOptions
                {
                    M1 = 56107078,
                    IA1 = 37382110,
                    IC1 = 50361430
                };
            }
            public override string ConfigId => "GuoJian002";
        }

    }
}
