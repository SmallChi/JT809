using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 车辆行驶线路请求应答
    /// <para>子业务类型标识:DOWN_BASE_MSG_DRVLINE_ACK</para>
    /// <para>上级平台应答下级平台发送地车辆行驶路线信息</para>
    /// </summary>
    public class JT809_0x9200_0x920D : JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9200_0x920D>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.车辆行驶线路请求应答.ToUInt16Value();

        public override string Description => "车辆行驶线路请求应答";
        /// <summary>
        /// 线路ＩＤ，按照８０８－２０１９中0x8606规定的报文中的线路ID
        /// </summary>
        public uint DRVLineID { get; set; }
        /// <summary>
        /// 处理结果 0x00 完成记录，0x01 审核通过，完成记录 0x02信息错误，未完成记录0x03 审核未通过，未完成记录
        /// </summary>
        public JT809_0x920D_Result Result { get; set; }
        /// <summary>
        /// 未通过原因内容长度
        /// </summary>
        public ushort ReasonLength { get; set; }
        /// <summary>
        /// 经过GBK编码后的未通过原因
        /// </summary>
        public string Reason { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            var value = new JT809_0x9200_0x920D();
            value.DRVLineID = reader.ReadUInt32();
            writer.WriteNumber($"[{value.DRVLineID.ReadNumber()}]线路ID", value.DRVLineID);
            value.Result = (JT809_0x920D_Result)reader.ReadByte();
            writer.WriteString($"[{value.Result.ToByteValue()}]处理结果", value.Result.ToString());
            value.ReasonLength = reader.ReadUInt16();
            writer.WriteNumber($"[{value.ReasonLength.ReadNumber()}]未通过原因内容长度", value.ReasonLength);
            var virtualHex = reader.ReadVirtualArray(value.ReasonLength);
            value.Reason = reader.ReadString(value.ReasonLength);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]经过GBK编码后的未通过原因", value.Reason);
        }

        public JT809_0x9200_0x920D Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x9200_0x920D();
            value.DRVLineID = reader.ReadUInt32();
            value.Result = (JT809_0x920D_Result)reader.ReadByte();
            value.ReasonLength = reader.ReadUInt16();
            value.Reason = reader.ReadString(value.ReasonLength);
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200_0x920D value, IJT809Config config)
        {
            writer.WriteUInt32(value.DRVLineID);
            writer.WriteByte(value.Result.ToByteValue());
            writer.Skip(2, out int position);
            writer.WriteString(value.Reason);
            writer.WriteUInt16Return((ushort)(writer.GetCurrentPosition() - position-2), position);
        }
    }
}
