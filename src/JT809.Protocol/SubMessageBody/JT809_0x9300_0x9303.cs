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
    /// 下发平台间消息补传请求消息
    /// <para>子业务类型标识:DOWN_PLATFORM_MSG_RETRAN_REQ</para>
    /// <para>描述:上级平台接收方在接受消息时，如发现消息报文序列号不连接，则立即发送消息补传请求。下级平台收到消息补传请求后，根据请求的消息报文序列号。重传相应的消息</para>
    /// </summary>
    public class JT809_0x9300_0x9303:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9300_0x9303>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.下发平台间消息补传请求消息.ToUInt16Value();

        public override string Description => "下发平台间消息补传请求消息";
        /// <summary>
        /// 需要重传消息的起始报文序列号和结束的报文序列号。如只请求重传一个消息，则起始消息报文序列号和结束消息报文序列号相同 
        /// 8位
        /// </summary>
        public byte[] SerialList { get; set; }
        /// <summary>
        /// 重传起始系统utc时间
        /// 8位
        /// </summary>
        public DateTime Time { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            var value = new JT809_0x9300_0x9303();
            value.SerialList = reader.ReadArray(8).ToArray();
            writer.WriteString($"[{value.SerialList.ToHexString()}]需要重传消息的起始报文序列号和结束的报文序列号", value.SerialList.ToHexString());
            var virtualHex = reader.ReadVirtualArray(8);
            value.Time = reader.ReadUTCDateTime();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]", value.Time);
        }

        public JT809_0x9300_0x9303 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x9300_0x9303();
            value.SerialList = reader.ReadArray(8).ToArray();
            value.Time = reader.ReadUTCDateTime();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9300_0x9303 value, IJT809Config config)
        {
            writer.WriteArray(value.SerialList);
            writer.WriteUTCDateTime(value.Time);
        }
    }
}
