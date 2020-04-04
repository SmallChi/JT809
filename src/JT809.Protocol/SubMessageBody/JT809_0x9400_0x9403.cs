using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using System;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 实时交换报警信息
    /// <para>子业务类型标识:DOWN_WARN_MSG_EXG_INFORM</para>
    /// <para>描述:用于上级平台向车辆跨域目的地下级平台下发相关车辆的当前报警情况</para>
    /// <para>本条消息下级平台无需应答</para>
    /// </summary>
    public class JT809_0x9400_0x9403:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9400_0x9403>
    {
        public override ushort SubMsgId => JT809SubBusinessType.实时交换报警信息.ToUInt16Value();

        public override string Description => "实时交换报警信息";
        /// <summary>
        /// 报警信息来源
        /// </summary>
        public JT809WarnSrc WarnSrc { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public JT809WarnType WarnType { get; set; }
        /// <summary>
        /// 报警时间
        /// </summary>
        public DateTime WarnTime { get; set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public uint WarnLength { get; set; }
        /// <summary>
        /// 报警描述
        /// </summary>
        public string WarnContent { get; set; }
        public JT809_0x9400_0x9403 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9400_0x9403 jT809_0X9400_0X9403 = new JT809_0x9400_0x9403();
            jT809_0X9400_0X9403.WarnSrc = (JT809WarnSrc)reader.ReadByte();
            jT809_0X9400_0X9403.WarnType = (JT809WarnType)reader.ReadUInt16();
            jT809_0X9400_0X9403.WarnTime = reader.ReadUTCDateTime();
            jT809_0X9400_0X9403.WarnLength = reader.ReadUInt32();
            jT809_0X9400_0X9403.WarnContent = reader.ReadString((int)jT809_0X9400_0X9403.WarnLength);
            return jT809_0X9400_0X9403;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9400_0x9403 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.WarnSrc);
            writer.WriteUInt16((ushort)value.WarnType);
            writer.WriteUTCDateTime(value.WarnTime);
            // 先计算内容长度（汉字为两个字节）
            writer.Skip(4, out int lengthPosition);
            writer.WriteString(value.WarnContent);
            writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);
        }
    }
}
