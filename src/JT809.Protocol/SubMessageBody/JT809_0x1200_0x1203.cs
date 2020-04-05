using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    ///  车辆定位信息自动补报请求消息
    ///  <para>子业务类型标识:UP_EXG_MSG_HISTORY_LOCATION</para>
    ///  <para>描述:如果平台间传输链路中断，下级平台重新登录并与上级平台建立通信链路后，下级平台应将中断期间内车载终端上传的车辆定位信息自动补报到上级平台。
    ///  如果系统断线期间，该车需发送的数据包条数大于 5，则以每包五条进行补发，直到补发完毕。
    ///  多条数据以卫星定位时间先后顺序排列。
    ///  本条消息上级平台采用定量回复，即收到一定数量的数据后，即通过从链路应答数据量。
    ///  </para>
    /// </summary>
    public class JT809_0x1200_0x1203 : JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x1203>
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

        public JT809_0x1200_0x1203 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x1203 jT809_0X1200_0X1203 = new JT809_0x1200_0x1203();
            jT809_0X1200_0X1203.GNSSCount = reader.ReadByte();
            jT809_0X1200_0X1203.GNSS = new List<JT809_0x1200_0x1202>();
            if (jT809_0X1200_0X1203.GNSSCount > 0)
            {
                for (int i = 0; i < jT809_0X1200_0X1203.GNSSCount; i++)
                {
                    try
                    {
                        JT809MessagePackReader jT809_0x1200_0x1202Reader = new JT809MessagePackReader(reader.ReadArray(36));
                        var jT809_0x1200_0x1202 = config.GetMessagePackFormatter<JT809_0x1200_0x1202>().Deserialize(ref jT809_0x1200_0x1202Reader, config);
                        jT809_0X1200_0X1203.GNSS.Add(jT809_0x1200_0x1202);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return jT809_0X1200_0X1203;
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
                catch (Exception ex)
                {

                }
            }
        }
    }
}
