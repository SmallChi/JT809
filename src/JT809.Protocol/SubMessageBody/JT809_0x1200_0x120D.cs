using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 主动上报车辆电子运单信息
    /// <para>子业务类型标识:UP_EXG_MSG_REPORT_EWAYBILL_INFO</para>
    /// <para>描述：下级平台“主动上报车辆电子运单信息”，向上级平台上报车辆当前电子运单</para>
    /// </summary>
    public class JT809_0x1200_0x120D:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x120D>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.主动上报车辆电子运单信息.ToUInt16Value();

        public override string Description => "主动上报车辆电子运单信息";
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
            JT809_0x1200_0x120D value = new JT809_0x1200_0x120D();
            value.EwaybillLength = reader.ReadUInt32();
            writer.WriteNumber($"[{value.EwaybillLength.ReadNumber()}]电子运单数据体长度", value.EwaybillLength);
            var virtualHex = reader.ReadVirtualArray((int)value.EwaybillLength);
            value.EwaybillInfo = reader.ReadString((int)value.EwaybillLength);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]电子运单数据内容", value.EwaybillInfo);
        }

        public JT809_0x1200_0x120D Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x120D value = new JT809_0x1200_0x120D();
            value.EwaybillLength = reader.ReadUInt32();
            value.EwaybillInfo = reader.ReadString((int)value.EwaybillLength);
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x120D value, IJT809Config config)
        {
            writer.WriteUInt32((uint)value.EwaybillInfo.Length);
            writer.WriteString(value.EwaybillInfo);
        }
    }
}
