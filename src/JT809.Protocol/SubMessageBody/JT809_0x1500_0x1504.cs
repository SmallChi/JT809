using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上报车辆行驶记录应答消息
    /// <para>子业务类型标识:UP_CTRL_MSG_TAKE_T'RAVEL_ACK</para>
    /// <para>描述:下级平台应答上级平台下发的上报车辆行驶记录请求消息，将车辆行驶记录数据上传至上级平台</para>
    /// </summary>
    public class JT809_0x1500_0x1504:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1500_0x1504>
    {
        public override ushort SubMsgId => JT809SubBusinessType.上报车辆行驶记录应答消息.ToUInt16Value();

        public override string Description => "上报车辆行驶记录应答消息";
        /// <summary>
        /// 命令字
        /// </summary>
        public JT809CommandType CommandType { get; set; }
        /// <summary>
        /// 车辆行驶记录数据体长度
        /// </summary>
        public uint TraveldataLength { get; set; }
        /// <summary>
        /// 车辆行驶记录信息
        /// </summary>
        public string TraveldataInfo { get; set; }
        public JT809_0x1500_0x1504 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1500_0x1504 jT809_0X1500_0X1504 = new JT809_0x1500_0x1504();
            jT809_0X1500_0X1504.CommandType = (JT809CommandType)reader.ReadByte();
            jT809_0X1500_0X1504.TraveldataLength = reader.ReadUInt32();
            jT809_0X1500_0X1504.TraveldataInfo = reader.ReadString((int)jT809_0X1500_0X1504.TraveldataLength);
            return jT809_0X1500_0X1504;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1500_0x1504 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.CommandType);
            // 先计算内容长度（汉字为两个字节）
            writer.Skip(4, out int lengthPosition);
            writer.WriteString(value.TraveldataInfo);
            writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);
        }
    }
}
