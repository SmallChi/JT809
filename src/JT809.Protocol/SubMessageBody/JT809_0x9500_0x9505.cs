using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using System;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 车辆应急接入监管平台请求消息
    /// <para>子业务类型标识:UP_CTRL_MSG_EMERGENCY_MONITORING_REQ</para>
    /// <para>描述:发生应急情况时，政府监管平台需要及时监控该车辆时，就向该车辆归属的下级平台发送该命令</para>
    /// </summary>
    public class JT809_0x9500_0x9505:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9500_0x9505>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.车辆应急接入监管平台请求消息.ToUInt16Value();

        public override string Description => "车辆应急接入监管平台请求消息";
        /// <summary>
        /// 监管平台下发的鉴权码
        /// </summary>
        public string AuthenticationCode { get; set; }
        /// <summary>
        /// 拨号点名称
        /// </summary>
        public string AccessPointName { get; set; }
        /// <summary>
        /// 拨号用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 拨号密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string ServerIP { get; set; }
        /// <summary>
        /// 服务器TCP端口
        /// </summary>
        public ushort TcpPort { get; set; }
        /// <summary>
        /// 服务器UDP端口
        /// </summary>
        public ushort UdpPort { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x9500_0x9505 value = new JT809_0x9500_0x9505();
            var virtualHex = reader.ReadVirtualArray(10);
            value.AuthenticationCode = reader.ReadBCD(20);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]监管平台下发的鉴权码", value.AuthenticationCode);
            virtualHex = reader.ReadVirtualArray(20);
            value.AccessPointName = reader.ReadString(20);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]拨号点名称", value.AccessPointName);
            virtualHex = reader.ReadVirtualArray(49);
            value.UserName = reader.ReadString(49);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]拨号用户名", value.UserName);
            virtualHex = reader.ReadVirtualArray(49);
            value.Password = reader.ReadString(22);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]拨号密码", value.Password);
            virtualHex = reader.ReadVirtualArray(32);
            value.ServerIP = reader.ReadString(32);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]地址", value.ServerIP);
            value.TcpPort = reader.ReadUInt16();
            writer.WriteNumber($"[{value.TcpPort.ReadNumber()}]", value.TcpPort);
            value.UdpPort = reader.ReadUInt16();
            writer.WriteNumber($"[{value.UdpPort.ReadNumber()}]", value.UdpPort);
            virtualHex = reader.ReadVirtualArray(8);
            value.EndTime = reader.ReadUTCDateTime();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]结束时间", value.EndTime);
        }

        public JT809_0x9500_0x9505 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9500_0x9505 value = new JT809_0x9500_0x9505();
            value.AuthenticationCode = reader.ReadBCD(20);
            value.AccessPointName = reader.ReadString(20);
            value.UserName = reader.ReadString(49);
            value.Password = reader.ReadString(22);
            value.ServerIP = reader.ReadString(32);
            value.TcpPort = reader.ReadUInt16();
            value.UdpPort = reader.ReadUInt16();
            value.EndTime = reader.ReadUTCDateTime();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9500_0x9505 value, IJT809Config config)
        {
            writer.WriteBCD(value.AuthenticationCode, 20);
            writer.WriteStringPadRight(value.AccessPointName, 20);
            writer.WriteStringPadRight(value.UserName, 49);
            writer.WriteStringPadRight(value.Password, 22);
            writer.WriteStringPadRight(value.ServerIP, 32);
            writer.WriteUInt16(value.TcpPort);
            writer.WriteUInt16(value.UdpPort);
            writer.WriteUTCDateTime(value.EndTime);
        }
    }
}
