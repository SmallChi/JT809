using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using System;
using System.Collections.Generic;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    ///  车辆定位信息交换补发消息
    ///  <para>子业务类型标识:DOWN_EXG_MSG_HISTORY_ARCOSSAREA</para>
    ///  <para>描述:本业务在 DOWN_EXG_MSG_APPLY_HISGNSSDATA_ACK 应答成功后，立即开始交换。如果申请失败，则不进行数据转发</para>
    /// </summary>
    public class JT809_0x9200_0x9203:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9200_0x9203>
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

        public JT809_0x9200_0x9203 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9200_0x9203 jT809_0X1200_0x9203 = new JT809_0x9200_0x9203();
            jT809_0X1200_0x9203.GNSSCount = reader.ReadByte();
            jT809_0X1200_0x9203.GNSS = new List<JT809_0x9200_0x9202>();
            if (jT809_0X1200_0x9203.GNSSCount > 0)
            {
                for (int i = 0; i < jT809_0X1200_0x9203.GNSSCount; i++)
                {
                    try
                    {
                        JT809MessagePackReader jT809_0x9200_0x9202Reader = new JT809MessagePackReader(reader.ReadArray(36));
                        JT809_0x9200_0x9202 jT809_0x1200_0x1202 = config.GetMessagePackFormatter<JT809_0x9200_0x9202>().Deserialize(ref jT809_0x9200_0x9202Reader, config);
                        jT809_0X1200_0x9203.GNSS.Add(jT809_0x1200_0x1202);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return jT809_0X1200_0x9203;
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
                catch (Exception ex)
                {

                }
            }
        }
    }
}
