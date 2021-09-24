using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using System;
using System.Collections.Generic;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    ///  车辆定位信息交换补发消息
    ///  <para>子业务类型标识:DOWN_EXG_MSG_HISTORY_ARCOSSAREA</para>
    ///  <para>描述:本业务在 DOWN_EXG_MSG_APPLY_HISGNSSDATA_ACK 应答成功后，立即开始交换。如果申请失败，则不进行数据转发</para>
    /// </summary>
    public class JT809_0x9200_0x9203:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9200_0x9203>, IJT809Analyze
    {
        public override ushort SubMsgId => JT809SubBusinessType.车辆定位信息交换补发消息.ToUInt16Value();

        public override string Description => "车辆定位信息交换补发消息";
        /// <summary>
        /// 卫星定位数据个数 1大于GNSS_CNT小于5
        /// </summary>
        public byte GNSSCount { get; set; }
        /// <summary>
        /// 卫星定位数据集合
        /// </summary>
        public List<JT809_0x9200_0x9202> GNSS { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x9200_0x9203 value = new JT809_0x9200_0x9203();
            value.GNSSCount = reader.ReadByte();
            writer.WriteNumber($"[{value.GNSSCount.ReadNumber()}]卫星定位数据个数", value.GNSSCount);
            value.GNSS = new List<JT809_0x9200_0x9202>();
            if (value.GNSSCount > 0)
            {
                writer.WriteStartArray("卫星定位数据集合");
                for (int i = 0; i < value.GNSSCount; i++)
                {
                    try
                    {
                        writer.WriteStartObject();
                        JT809MessagePackReader jT809_0x9200_0x9202Reader = new JT809MessagePackReader(reader.ReadArray(36));
                        config.GetMessagePackFormatter<JT809_0x9200_0x9202>().Analyze(ref jT809_0x9200_0x9202Reader, writer, config);
                        writer.WriteEndObject();
                    }
                    catch (Exception)
                    {
                    }
                }
                writer.WriteEndArray();
            }
        }

        public JT809_0x9200_0x9203 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9200_0x9203 value = new JT809_0x9200_0x9203();
            value.GNSSCount = reader.ReadByte();
            value.GNSS = new List<JT809_0x9200_0x9202>();
            if (value.GNSSCount > 0)
            {
                for (int i = 0; i < value.GNSSCount; i++)
                {
                    try
                    {
                        JT809MessagePackReader jT809_0x9200_0x9202Reader = new JT809MessagePackReader(reader.ReadArray(36));
                        JT809_0x9200_0x9202 jT809_0x1200_0x1202 = config.GetMessagePackFormatter<JT809_0x9200_0x9202>().Deserialize(ref jT809_0x9200_0x9202Reader, config);
                        value.GNSS.Add(jT809_0x1200_0x1202);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200_0x9203 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.GNSS.Count);
            foreach (var item in value.GNSS)
            {
                try
                {
                    item.Serialize(ref writer, item, config);
                }
                catch
                {

                }
            }
        }
    }
}
