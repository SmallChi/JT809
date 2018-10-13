using JT809.Protocol.JT809Configs;
using JT809.Protocol.JT809Encrypt;
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
            SkipCRCCode = false;
        }

        public static JT809GlobalConfig Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public IJT809Encrypt Encrypt { get; private set; }

        public JT809EncryptOptions EncryptOptions { get; private set; }

        public IMsgSNDistributed MsgSNDistributed { get; private set; }

        public JT809HeaderOptions HeaderOptions { get; private set; }
        /// <summary>
        /// 跳过校验码
        /// 默认：false
        /// </summary>
        public bool SkipCRCCode { get; private set; }
        /// <summary>
        /// 设置加密算法选项值
        /// 不同的上下级平台之间，加密的算法是一致的，但是针对 M1, IA1, IC1 的不同。
        /// 数据先经过加密而后解密。
        /// </summary>
        /// <param name="jT809Encrypt"></param>
        /// <returns></returns>
        public JT809GlobalConfig SetEncryptOptions(JT809EncryptOptions jT809EncryptOptions)
        {
            instance.Value.Encrypt = new JT809EncryptImpl(jT809EncryptOptions);
            instance.Value.EncryptOptions = jT809EncryptOptions;
            return instance.Value;
        }
        /// <summary>
        /// 设置加密算法实现
        /// </summary>
        /// <param name="jT809Encrypt"></param>
        /// <returns></returns>
        public JT809GlobalConfig SetEncrypt(IJT809Encrypt jT809Encrypt)
        {
            instance.Value.Encrypt = jT809Encrypt;
            return instance.Value;
        }
        /// <summary>
        /// 设置消息序列号
        /// </summary>
        /// <param name="msgSNDistributed"></param>
        /// <returns></returns>
        public JT809GlobalConfig SetMsgSNDistributed(IMsgSNDistributed msgSNDistributed)
        {
            instance.Value.MsgSNDistributed = msgSNDistributed;
            return instance.Value;
        }
        /// <summary>
        /// 设置头部选项
        /// </summary>
        /// <param name="jT809HeaderOptions"></param>
        /// <returns></returns>
        public JT809GlobalConfig SetHeaderOptions(JT809HeaderOptions jT809HeaderOptions)
        {
            instance.Value.HeaderOptions = jT809HeaderOptions;
            return instance.Value;
        }
        /// <summary>
        /// 设置跳过校验码
        /// 场景：测试的时候，可能需要收到改数据，所以测试的时候有用
        /// </summary>
        /// <param name="skipCRCCode"></param>
        /// <returns></returns>
        public JT809GlobalConfig SetSkipCRCCode(bool skipCRCCode)
        {
            instance.Value.SkipCRCCode = skipCRCCode;
            return instance.Value;
        }
    }
}
