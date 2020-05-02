using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上报车辆电子运单应答消息
    /// <para>子业务类型标识:UP_EXG_MSG_TAKE_EWAYBILL_ACK</para>
    /// <para>描述:下级平台应答上级平台发送的上报车辆电子运单请求消息，向上级平台上传车辆当前电子运单</para>
    /// </summary>
    public class JT809_0x1200_0x120B:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x120B>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.上报车辆电子运单应答消息.ToUInt16Value();

        public override string Description => "上报车辆电子运单应答消息";
        /// <summary>
        /// 对应上报车辆电子运单源子业务类型标识
        /// </summary>
        public ushort SourceDataType { get; set; }
        /// <summary>
        ///  对应上报车辆电子运单源报文序列号
        /// </summary>
        public uint SourceMsgSn { get; set; }
        /// <summary>
        /// 电子运单数据体长度
        /// </summary>
        public uint EwaybillLength { get; set; }
        /// <summary>
        /// 电子运单数据内容
        /// </summary>
        public string EwaybillInfo { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            var value = new JT809_0x1200_0x120B();
            if (config.Version == JT809Version.JTT2019)
            {
                value.SourceDataType = reader.ReadUInt16();
                writer.WriteString($"[{value.SourceDataType.ReadNumber()}]对应启动车辆定位信息交换请求消息源子业务类型标识", ((JT809SubBusinessType)value.SourceDataType).ToString());
                value.SourceMsgSn = reader.ReadUInt32();
                writer.WriteNumber($"[{value.SourceMsgSn.ReadNumber()}对应启动车辆定位信息交换请求消息源报文序列号]", value.SourceMsgSn);

            }
            value.EwaybillLength = reader.ReadUInt32();
            writer.WriteNumber($"[{value.EwaybillLength.ReadNumber()}]电子运单数据体长度", value.EwaybillLength);
            var virtualHex = reader.ReadVirtualArray((int)value.EwaybillLength);
            value.EwaybillInfo = reader.ReadString((int)value.EwaybillLength);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}电子运单数据内容]", value.EwaybillInfo);
        }

        public JT809_0x1200_0x120B Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x1200_0x120B();
            if (config.Version == JT809Version.JTT2019)
            {
                value.SourceDataType = reader.ReadUInt16();
                value.SourceMsgSn = reader.ReadUInt32();
            }
            value.EwaybillLength = reader.ReadUInt32();
            value.EwaybillInfo = reader.ReadString((int)value.EwaybillLength);
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x120B value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2019)
            {
                writer.WriteUInt16(value.SourceDataType);
                writer.WriteUInt32(value.SourceMsgSn);
            }
            writer.WriteUInt32((uint)value.EwaybillInfo.Length);
            writer.WriteString(value.EwaybillInfo);
        }
    }
}
