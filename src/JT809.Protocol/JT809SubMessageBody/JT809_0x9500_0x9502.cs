using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 车辆拍照请求消息
    /// <para>子业务类型标识:DOWN_CTRL_MSG_TAKE_PHOTO_REQ</para>
    /// <para>描述:上级平台向下级平台下发对某指定车辆的拍照请求消息</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9500_0x9502Formatter))]
    public class JT809_0x9500_0x9502:JT809SubBodies
    {
        /// <summary>
        /// 镜头ID
        /// </summary>
        public byte LensID { get; set; }
        /// <summary>
        /// 图片大小
        /// </summary>
        public byte SizeType { get; set; }
    }
}
