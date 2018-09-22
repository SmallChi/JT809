using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 上传车辆注册信息消息
    /// <para>子业务类型标识:UP_ EXG_ MSG_ REGISTER</para>
    /// <para>描述:监控平台收到车载终端鉴权信息后，启动本命令向上级监管平台上传该车辆注册信息.各级监管平台再逐级向上级平台上传该信息</para>
    /// <para>本条消息服务端无需应答</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1200_0x1201Formatter))]
    public class JT809_0x1200_0x1201:JT809SubBodies
    {
        /// <summary>
        /// 平台唯一编码
        /// </summary>
        public string PlateformId { get; set; }
        /// <summary>
        /// 车载终端厂商唯一编码
        /// </summary>
        public string ProducerId { get; set; }
        /// <summary>
        /// 车载终端型号，不是 8 位时以“\0”终结
        /// </summary>
        public string TerminalModelType { get; set; }
        /// <summary>
        /// 车载终端编号，大写字母和数字组成
        /// </summary>
        public string TerminalId { get; set; }
        /// <summary>
        /// 车载终端 SIM 卡电话号码。号码不是12 位，则在前补充数字 0.
        /// </summary>
        public string TerminalSimCode { get; set; }
    }
}
