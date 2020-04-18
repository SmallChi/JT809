using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 下发平台间报文应答消息
    /// <para>子业务类型标识:UP_PLATFORM_MSG_INFO_ACK</para>
    /// <para>描述:下级平台收到上级平台发送的下发平台间报文请求消息后，发送应答消息</para>
    /// </summary>
    public class JT809_0x1300_0x1302:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1300_0x1302>, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.下发平台间报文应答消息.ToUInt16Value();

        public override string Description => "下发平台间报文应答消息";
        /// <summary>
        /// 对应下发平台间报文请求消息源子业务类型标识
        /// </summary>
        public ushort SourceDataType { get; set; }
        /// <summary>
        ///  对应下发平台间报文请求消息源报文序列号
        /// </summary>
        public uint SourceMsgSn { get; set; }
        /// <summary>
        /// 信息ID
        /// </summary>
        public uint InfoID { get; set; }
        public JT809_0x1300_0x1302 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1300_0x1302 value = new JT809_0x1300_0x1302();
            if (config.Version == JT809Version.JTT2019) {
                value.SourceDataType = reader.ReadUInt16();
                value.SourceMsgSn = reader.ReadUInt32();
            }
            else
            {
                value.InfoID = reader.ReadUInt32();
            }

            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1300_0x1302 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2019)
            {
                writer.WriteUInt16(value.SourceDataType);
                writer.WriteUInt32(value.SourceMsgSn);
            }
            else {
                writer.WriteUInt32(value.InfoID);
            }
        }
    }
}
