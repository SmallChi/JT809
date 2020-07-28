using JT809.Protocol.Interfaces;

namespace JT809.Protocol
{
    /// <summary>
    /// 子业务数据体
    /// </summary>
    public abstract class JT809SubBodies : IJT809Description
    {
        /// <summary>
        /// 跳过数据体序列化
        /// 默认不跳过
        /// 当数据体为空的时候，使用null作为空包感觉不适合，所以就算使用空包也需要new一下来表达意思。
        /// </summary>
        public virtual bool SkipSerialization { get; set; } = false;
        /// <summary>
        /// 2019文档导致需要兼容
        /// 是否跳过后续的长度
        /// </summary>
        public virtual bool SkipDataLength { get; set; } = false;

        public abstract ushort SubMsgId { get; }

        public abstract string Description { get; }
        /// <summary>
        /// 当外部注册的扩展809的消息Id跟国标的消息Id冲突时可以使用该字段替换国标的消息Id
        /// 默认是false,不替换
        /// </summary>
        public virtual bool ReplaceInternalSubMsgId { get; } = false;
    }
}
