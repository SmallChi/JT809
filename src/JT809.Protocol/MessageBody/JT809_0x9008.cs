using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 上级平台主动关闭链路通知消息
    /// <para>业务数据类型标识:DOWN_CLOSELINK_INFORM</para>
    /// </summary>
    public class JT809_0x9008:JT809Bodies, IJT809MessagePackFormatter<JT809_0x9008>
    {
        public override ushort MsgId => JT809BusinessType.上级平台主动关闭链路通知消息.ToUInt16Value();
        public override string Description => "上级平台主动关闭链路通知消息";
#warning 待验证主从链路
        public override JT809_LinkType LinkType => JT809_LinkType.subordinate;
        /// <summary>
        /// 错误代码
        /// </summary>
        public JT809_0x9008_ReasonCode ReasonCode { get; set; }
        public JT809_0x9008 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9008 jT809_0X9008 = new JT809_0x9008();
            jT809_0X9008.ReasonCode = (JT809_0x9008_ReasonCode)reader.ReadByte();
            return jT809_0X9008;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9008 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.ReasonCode);
        }
    }
}
