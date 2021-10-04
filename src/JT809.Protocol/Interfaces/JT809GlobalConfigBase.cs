using JT808.Protocol.Formatters;
using JT808.Protocol.Internal;
using JT809.Protocol.Configs;
using JT809.Protocol.Encrypt;
using JT809.Protocol.Enums;
using JT809.Protocol.Internal;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JT809.Protocol.Interfaces
{
    public abstract class JT809GlobalConfigBase : IJT809Config
    {
        protected JT809GlobalConfigBase(JT809Version version= JT809Version.JTT2011)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding = Encoding.GetEncoding("GBK");
            BusinessTypeFactory = new JT809BusinessTypeFactory();
            SubBusinessTypeFactory = new JT809SubBusinessTypeFactory();
            FormatterFactory = new JT809FormatterFactory();
            Version = version;
            AnalyzeCallbacks = new Dictionary<ushort, JT808AnalyzeCallback>();
        }
        public abstract string ConfigId { get; }
        public IJT809MsgSNDistributed MsgSNDistributed { get; set; }= new DefaultMsgSNDistributedImpl();
        public Encoding Encoding { get; set; }
        public bool SkipCRCCode { get; set; } = false;
        public IJT809Encrypt Encrypt { get; set; } = new JT809EncryptImpl();
        public JT809EncryptOptions EncryptOptions { get; set; }
        public JT809HeaderOptions HeaderOptions { get; set; }
        public IJT809BusinessTypeFactory BusinessTypeFactory { get ; set ; }
        public IJT809SubBusinessTypeFactory SubBusinessTypeFactory { get; set ; }
        public IJT809FormatterFactory FormatterFactory { get; set; }
        public JT809Version Version { get; set; }
        public Dictionary<ushort, JT808AnalyzeCallback> AnalyzeCallbacks { get; set; }
        public virtual IJT809Config Register(params Assembly[] externalAssemblies)
        {
            if (externalAssemblies != null)
            {
                foreach (var easb in externalAssemblies)
                {
                    FormatterFactory.Register(easb);
                }
            }
            return this;
        }
    }
}
