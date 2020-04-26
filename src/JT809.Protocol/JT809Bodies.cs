using JT809.Protocol.Enums;
using JT809.Protocol.Interfaces;

namespace JT809.Protocol
{
    public abstract class JT809Bodies: IJT809Description
    {
        /// <summary>
        /// 跳过数据体序列化
        /// 默认不跳过
        /// 当数据体为空的时候，使用null作为空包感觉不适合，所以就算使用空包也需要new一下来表达意思。
        /// </summary>
        public virtual bool SkipSerialization { get; set; } = false;
        public virtual JT809Version Version => JT809Version.JTT2011;
        public abstract ushort MsgId { get; }
        public abstract JT809_LinkType LinkType { get; }
        public abstract string Description { get; }
    }
}
