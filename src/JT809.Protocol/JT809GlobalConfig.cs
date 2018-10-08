using JT809.Protocol.JT809Configs;
using JT809.Protocol.JT809Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    public sealed class JT809GlobalConfig
    {
        private static readonly Lazy<JT809GlobalConfig> instance = new Lazy<JT809GlobalConfig>(() => new JT809GlobalConfig());

        private JT809GlobalConfig()
        {
            MsgSNDistributed = new DefaultMsgSNDistributedImpl();
            HeaderOptions = new JT809HeaderOptions();
        }

        public static JT809GlobalConfig Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public IJT809Encrypt Encrypt { get; private set; }

        public IMsgSNDistributed MsgSNDistributed {get;private set;}

        public JT809HeaderOptions HeaderOptions { get; private set; }

        public JT809GlobalConfig SetEncrypt(IJT809Encrypt jT809Encrypt)
        {
            instance.Value.Encrypt = jT809Encrypt;
            return instance.Value;
        }

        public JT809GlobalConfig SetMsgSNDistributed(IMsgSNDistributed msgSNDistributed)
        {
            instance.Value.MsgSNDistributed = msgSNDistributed;
            return instance.Value;
        }

        public JT809GlobalConfig SetHeaderOptions(JT809HeaderOptions jT809HeaderOptions)
        {
            instance.Value.HeaderOptions = jT809HeaderOptions;
            return instance.Value;
        }
    }
}
