using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using JT809.Protocol.Metadata;
using System.Text.Json;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    ///  上传平台间消息序列号通知消息
    /// <para>链路类型：主链路</para>
    /// <para>消息方向:上级平台往下级平台</para>
    /// <para>业务类型标识:UP_MANAGE_MSG_SN_INFORM</para>
    /// <para>描述：链路登录成功后，平台须发送链路断开之前所有子业务数据类型对应的消息序列号，发送方根据收到的消息序列号，在发送消息时，续编链路中断之前的消息序列号</para>
    /// </summary>
    public class JT809_0x1103 : JT809ExchangeMessageBodies, IJT809MessagePackFormatter<JT809_0x1103>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort MsgId => JT809BusinessType.上传平台间消息序列号通知消息_2019.ToUInt16Value();
        public override string Description => "上传平台间消息序列号通知消息";
        public override JT809_LinkType LinkType => JT809_LinkType.main;
        public override JT809Version Version => JT809Version.JTT2019;

        public List<JT809ManageMsgSNInform> ManageMsgSNInform { get; set; } = new List<JT809ManageMsgSNInform>();
        public byte Count { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1103 value = new JT809_0x1103();
            value.SubBusinessType = reader.ReadUInt16();
            writer.WriteString($"[{value.SubBusinessType.ReadNumber()}]子业务类型标识", ((JT809SubBusinessType)value.SubBusinessType).ToString());
            value.DataLength = reader.ReadUInt32();
            writer.WriteNumber($"[{value.DataLength.ReadNumber()}]后续数据长度", value.DataLength);
            value.Count = reader.ReadByte();
            writer.WriteNumber($"[{value.Count.ReadNumber()}]个数", value.Count);
            writer.WriteStartArray("上传平台间消息序列号通知消息");
            for (int i = 0; i < value.Count; i++)
            {
                writer.WriteStartObject();
                JT809ManageMsgSNInform item = new JT809ManageMsgSNInform();
                item.SubBusinessType = reader.ReadUInt16();
                writer.WriteString($"[{item.SubBusinessType.ReadNumber()}]子业务类型标识", ((JT809SubBusinessType)item.SubBusinessType).ToString());
                item.MsgSN = reader.ReadUInt32();
                writer.WriteNumber($"[{item.MsgSN.ReadNumber()}]对应得子夜吴数据类型报文序列号", item.MsgSN);
                var virtualHex = reader.ReadVirtualArray(8);
                item.Time = reader.ReadUTCDateTime();
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]系统UTC时间", item.Time);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }

        public JT809_0x1103 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1103 value = new JT809_0x1103();
            value.SubBusinessType = reader.ReadUInt16();
            value.DataLength = reader.ReadUInt32();
            value.Count = reader.ReadByte();
            for(int i=0;i < value.Count; i++)
            {
                JT809ManageMsgSNInform item = new JT809ManageMsgSNInform();
                item.SubBusinessType = reader.ReadUInt16();
                item.MsgSN = reader.ReadUInt32();
                item.Time = reader.ReadUTCDateTime();
                value.ManageMsgSNInform.Add(item);
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1103 value, IJT809Config config)
        {
            writer.WriteUInt16(value.SubBusinessType);
            // 先写入内容，然后在根据内容反写内容长度
            writer.Skip(4, out int subContentLengthPosition);
            writer.WriteByte((byte)value.ManageMsgSNInform.Count);
            foreach(var item in value.ManageMsgSNInform)
            {
                writer.WriteUInt16(item.SubBusinessType);
                writer.WriteUInt32(item.MsgSN);
                writer.WriteUTCDateTime(item.Time);
            }
            writer.WriteInt32Return(writer.GetCurrentPosition() - subContentLengthPosition - 4, subContentLengthPosition);
        }
    }
}
