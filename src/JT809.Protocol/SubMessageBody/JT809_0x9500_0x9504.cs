using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using System;
using JT809.Protocol.Interfaces;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上报车辆行驶记录请求消息
    /// <para>子业务类型标识:DOVJN_CTRL_MSG_TAKE_TRAVEL_REQ</para>
    /// <para>描述:上级平台向下级平台下发上报车辆行驶记录请求消息</para>
    /// </summary>
    public class JT809_0x9500_0x9504:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9500_0x9504>, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.上报车辆行驶记录请求消息.ToUInt16Value();

        public override string Description => "上报车辆行驶记录请求消息";
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 命令字ID
        /// </summary>
        public JT809CommandType Command { get; set; }

        public JT809_0x9500_0x9504 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x9500_0x9504();
            value.StartTime = reader.ReadUTCDateTime();
            value.EndTime = reader.ReadUTCDateTime();
            value.Command = (JT809CommandType)reader.ReadByte();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9500_0x9504 value, IJT809Config config)
        {
            writer.WriteUTCDateTime(value.StartTime);
            writer.WriteUTCDateTime(value.EndTime);
            writer.WriteByte((byte)value.Command);
        }
    }
}
