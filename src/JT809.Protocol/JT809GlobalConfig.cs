using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    public sealed class JT809GlobalConfig
    {
        private static readonly Lazy<JT809GlobalConfig> instance = new Lazy<JT809GlobalConfig>(() => new JT809GlobalConfig());

        private JT809GlobalConfig(){}

        public static JT809GlobalConfig Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public IJT809Encrypt JT809Encrypt { get; private set; }

        public JT809GlobalConfig SetJT809Encrypt(IJT809Encrypt jT809Encrypt)
        {
            instance.Value.JT809Encrypt = jT809Encrypt;
            return instance.Value;
        }
    }
}
