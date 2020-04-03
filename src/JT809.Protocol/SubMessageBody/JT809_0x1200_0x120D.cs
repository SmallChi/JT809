using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 主动上报车辆电子运单信息
    /// <para>子业务类型标识:UP_EXG_MSG_REPORT_EWAYBILL_INFO</para>
    /// </summary>
    public class JT809_0x1200_0x120D:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x120D>
    {
        /// <summary>
        /// 电子运单数据体长度
        /// </summary>
        public uint EwaybillLength { get; set; }
        /// <summary>
        /// 电子运单数据内容
        /// </summary>
        public string EwaybillInfo { get; set; }
        public JT809_0x1200_0x120D Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x120D jT809_0X1200_0X120D = new JT809_0x1200_0x120D();
            jT809_0X1200_0X120D.EwaybillLength = reader.ReadUInt32();
            jT809_0X1200_0X120D.EwaybillInfo = reader.ReadString((int)jT809_0X1200_0X120D.EwaybillLength);
            return jT809_0X1200_0X120D;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x120D value, IJT809Config config)
        {
            writer.WriteUInt32((uint)value.EwaybillInfo.Length);
            writer.WriteString(value.EwaybillInfo);
        }
    }
}
