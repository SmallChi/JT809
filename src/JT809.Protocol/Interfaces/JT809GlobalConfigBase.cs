using JT808.Protocol.Formatters;
using JT808.Protocol.Internal;
using JT809.Protocol.Configs;
using JT809.Protocol.Encrypt;
using JT809.Protocol.Internal;
using System;
using System.Reflection;
using System.Text;

namespace JT809.Protocol.Interfaces
{
    public abstract class GlobalConfigBase : IJT809Config
    {
        protected GlobalConfigBase()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding = Encoding.GetEncoding("GBK");
            BusinessTypeFactory = new JT809BusinessTypeFactory();
            SubBusinessTypeFactory = new JT809SubBusinessTypeFactory();
            FormatterFactory = new JT809FormatterFactory();
        }
        public abstract string ConfigId { get; }
        public virtual IJT809MsgSNDistributed MsgSNDistributed { get; set; }= new DefaultMsgSNDistributedImpl();
        public virtual Encoding Encoding { get; set; }
        public virtual bool SkipCRCCode { get; set; } = false;
        public virtual IJT809Encrypt Encrypt { get; set; } = new JT809EncryptImpl();
        public virtual JT809EncryptOptions EncryptOptions { get; set; }
        public virtual JT809HeaderOptions HeaderOptions { get; set; }
        public IJT809BusinessTypeFactory BusinessTypeFactory { get ; set ; }
        public IJT809SubBusinessTypeFactory SubBusinessTypeFactory { get; set ; }
        public IJT809FormatterFactory FormatterFactory { get; set; }
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
