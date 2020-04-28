using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 补报车辆静态信息应答
    /// <para>子业务类型标识:UP_BASE_MSG_VEHICLE_ADDED_ACK</para>
    /// <para>描述:上级平台应答下级平台发送的"补报车辆静态信息清求"消息</para>
    /// </summary>
    public class JT809_0x1600_0x1601:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1600_0x1601>, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.补报车辆静态信息应答.ToUInt16Value();

        public override string Description => "补报车辆静态信息应答";
        /// <summary>
        /// 对应补报车辆静态信息请求消息源子业务类型标识
        /// </summary>
        public ushort SourceDataType { get; set; }
        /// <summary>
        ///  对应补报车辆静态信息请求消息源报文序列号
        /// </summary>
        public uint SourceMsgSn { get; set; }
        /// <summary>
        /// 车辆信息
        /// </summary>
        public string CarInfo { get; set; }
        public JT809_0x1600_0x1601 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1600_0x1601 value = new JT809_0x1600_0x1601();
            if (config.Version == JT809Version.JTT2019)
            {
                value.SourceDataType = reader.ReadUInt16();
                value.SourceMsgSn = reader.ReadUInt32();
            }
            value.CarInfo = reader.ReadRemainStringContent();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1600_0x1601 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2019)
            {
                writer.WriteUInt16(value.SourceDataType);
                writer.WriteUInt32(value.SourceMsgSn);
            }
            writer.WriteString(value.CarInfo);
        }
    }
}
