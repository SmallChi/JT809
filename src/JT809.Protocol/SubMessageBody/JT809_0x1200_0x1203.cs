using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    ///  车辆定位信息自动补报请求消息
    ///  <para>子业务类型标识:UP_EXG_MSG_HISTORY_LOCATION</para>
    ///  <para>描述:  a: 如果平台间传输链路中断，下级平台重新登录并与上级平台建立通信链路后，下级平台应将中断期间内车载终端上传的车辆定位信息自动补报到上级平台。
    ///  b: 如果系统断线期间，该车需发送的数据包条数大于 5，则以每包五条进行补发，直到补发完毕。
    ///   多条数据以卫星定位时间先后顺序排列。
    ///  本条消息上级平台采用定量回复，即收到一定数量的数据后，即通过从链路应答数据量。
    ///  </para>
    /// </summary>
    public class JT809_0x1200_0x1203 : JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x1203>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.车辆定位信息自动补报请求消息.ToUInt16Value();

        public override string Description => "车辆定位信息自动补报请求消息";
        /// <summary>
        /// 卫星定位数据个数 1大于GNSS_CNT小于5
        /// </summary>
        public byte GNSSCount { get; set; }
        /// <summary>
        /// 卫星定位数据集合
        /// </summary>
        public List<JT809_0x1200_0x1202> GNSS { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1200_0x1203 value = new JT809_0x1200_0x1203();
            value.GNSSCount = reader.ReadByte();
            writer.WriteNumber($"[{value.GNSSCount.ReadNumber()}]卫星定位数据个数", value.GNSSCount);
            value.GNSS = new List<JT809_0x1200_0x1202>();
            writer.WriteStartArray("实时上传车辆定位信息消息");
            if (value.GNSSCount > 0)
            {
                for (int i = 0; i < value.GNSSCount; i++)
                {
                    try
                    {
                        writer.WriteStartObject();
                        config.GetMessagePackFormatter<JT809_0x1200_0x1202>().Analyze(ref reader, writer, config);
                        writer.WriteEndObject();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            writer.WriteEndArray();
        }

        public JT809_0x1200_0x1203 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x1203 value = new JT809_0x1200_0x1203();
            value.GNSSCount = reader.ReadByte();
            value.GNSS = new List<JT809_0x1200_0x1202>();
            if (value.GNSSCount > 0)
            {
                for (int i = 0; i < value.GNSSCount; i++)
                {
                    try
                    {
                        var jT809_0x1200_0x1202 = config.GetMessagePackFormatter<JT809_0x1200_0x1202>().Deserialize(ref reader, config);
                        value.GNSS.Add(jT809_0x1200_0x1202);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x1203 value, IJT809Config config)
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
