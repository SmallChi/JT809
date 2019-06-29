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
        }
        public abstract string ConfigId { get; }
        public virtual IJT809MsgSNDistributed MsgSNDistributed { get; set; }= new DefaultMsgSNDistributedImpl();
        public virtual Encoding Encoding { get; set; }
        public virtual bool SkipCRCCode { get; set; } = false;
        public virtual IJT809Encrypt Encrypt { get; set; } = new JT809EncryptImpl();
        public virtual JT809EncryptOptions EncryptOptions { get; set; }
        public virtual JT809HeaderOptions HeaderOptions { get; set; }
        public virtual IJT809Config Register(params Assembly[] externalAssemblies)
        {
            return this;
        }
    }
}
