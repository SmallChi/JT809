using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 下发平台间报文请求
    /// <para>子业务类型标识:DOWN_PLATFORM_MSG_INFO_REQ</para>
    /// <para>描述:上级平台不定期向下级平台下发平台间报文</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9300_0x9302Formatter))]
    public class JT809_0x9300_0x9302:JT809SubBodies
    {
        /// <summary>
        /// 查岗对象的类型
        /// </summary>
        public JT809_0x9302_ObjectType ObjectType { get; set; }
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
