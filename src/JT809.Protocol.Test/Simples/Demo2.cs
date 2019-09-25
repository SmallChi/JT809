using JT809.Protocol.Configs;
using JT809.Protocol.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Test.Simples
{
    public class Demo2
    {
        class JT809GlobalConfig : JT809GlobalConfigBase
        {
            public override JT809EncryptOptions EncryptOptions { get; set; } = new JT809EncryptOptions()
            {
                IA1 = 20000000,
                IC1 = 20000000,
                M1 = 30000000
            };
            public override string ConfigId => "JT809GlobalConfig";
        }

        JT809Serializer JT809Serializer = new JT809Serializer(new JT809GlobalConfig());
    }
}
