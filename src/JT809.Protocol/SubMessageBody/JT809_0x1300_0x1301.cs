using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 平台查岗应答消息
    /// <para>子业务类型标识:UP_PLATFORM_MSG_POST_QUERY_ACK</para>
    /// <para>描述:下级平台应答上级平台发送的不定期平台查岗消息</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1300_0x1301_Formatter))]
    public class JT809_0x1300_0x1301:JT809SubBodies
    {
        /// <summary>
        /// 查岗对象的类型
        /// </summary>
        public JT809_0x1301_ObjectType ObjectType { get; set; }
        /// <summary>
        /// 查岗对象的ID
        /// </summary>
        public string ObjectID { get; set; }
        /// <summary>
        /// 信息ID
        /// </summary>
        public uint InfoID { get; set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public uint InfoLength { get; set; }
        /// <summary>
        /// 应答内容
        /// </summary>
        public string InfoContent { get; set; }
    }
}
