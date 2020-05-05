using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 下发车辆报文应答消息
    /// <para>子业务类型标识:UP_CTRL_MSG_TEXT_INFO_ACK</para>
    /// <para>描述:下级平台应答上级平台下发的报文是否成功到达指定车辆</para>
    /// </summary>
    public class JT809_0x1500_0x1503:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1500_0x1503>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.下发车辆报文应答消息.ToUInt16Value();

        public override string Description => "下发车辆报文应答消息"; 
        /// <summary>
        /// 对应下发车辆报文请求消息源子业务类型标识
        /// </summary>
        public ushort SourceDataType { get; set; }
        /// <summary>
        ///  对应下发车辆报文请求消息源报文序列号
        /// </summary>
        public uint SourceMsgSn { get; set; }
        /// <summary>
        /// 消息ID
        /// 对应“下发车辆报文请求消息”中的MSG_ID
        /// </summary>
        public uint MsgID { get; set; }
        /// <summary>
        /// 应答结果
        /// </summary>
        public JT809_0x1503_Result Result { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1500_0x1503 value = new JT809_0x1500_0x1503();
            if (config.Version == JT809Version.JTT2019)
            {
                value.SourceDataType = reader.ReadUInt16();
                writer.WriteString($"[{value.SourceDataType.ReadNumber()}]对应启动车辆定位信息交换请求消息源子业务类型标识", ((JT809SubBusinessType)value.SourceDataType).ToString());
                value.SourceMsgSn = reader.ReadUInt32();
                writer.WriteNumber($"[{value.SourceMsgSn.ReadNumber()}对应启动车辆定位信息交换请求消息源报文序列号]", value.SourceMsgSn);
            }
            else
            {
                value.MsgID = reader.ReadUInt32();
                writer.WriteNumber($"[{value.MsgID.ReadNumber()}]消息ID", value.MsgID);
            }
            value.Result = (JT809_0x1503_Result)reader.ReadByte();
            writer.WriteString($"[{value.Result.ToByteValue()}]应答结果", value.Result.ToString());
        }

        public JT809_0x1500_0x1503 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1500_0x1503 value = new JT809_0x1500_0x1503();
            if (config.Version == JT809Version.JTT2019)
            {
                value.SourceDataType = reader.ReadUInt16();
                value.SourceMsgSn = reader.ReadUInt32();
            }
            else
            {
                value.MsgID = reader.ReadUInt32();
            }
            value.Result = (JT809_0x1503_Result)reader.ReadByte();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1500_0x1503 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2019)
            {
                writer.WriteUInt16(value.SourceDataType);
                writer.WriteUInt32(value.SourceMsgSn);
            }
            else
            {
                writer.WriteUInt32(value.MsgID);
            }
            writer.WriteByte((byte)value.Result);
        }
    }
}
