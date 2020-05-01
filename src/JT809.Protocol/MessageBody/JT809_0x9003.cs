using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System.Text.Json;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    ///从链路注销请求消息
    ///<para>链路类型:从链路</para>
    ///<para>消息方向:上级平台往下级平台</para>
    ///<para>业务数据类型标识:DOWN_DISCONNIrCT_REQ</para>
    ///<para>描述:从链路建立后，上级平台在取消该链路时，应向下级平台发送从链路注销请求消息</para>
    /// </summary>
    public class JT809_0x9003: JT809Bodies, IJT809MessagePackFormatter<JT809_0x9003>, IJT809Analyze
    {
        public override ushort MsgId => JT809BusinessType.从链路注销请求消息.ToUInt16Value();
        public override string Description => "从链路注销请求消息";
        public override JT809_LinkType LinkType => JT809_LinkType.subordinate;
        /// <summary>
        /// 校验码
        /// </summary>
        public uint VerifyCode { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x9003 value = new JT809_0x9003();
            value.VerifyCode = reader.ReadUInt32();
            writer.WriteNumber($"[{value.VerifyCode.ReadNumber()}校验码]", value.VerifyCode);
        }

        public JT809_0x9003 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9003 value = new JT809_0x9003();
            value.VerifyCode = reader.ReadUInt32();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9003 value, IJT809Config config)
        {
            writer.WriteUInt32(value.VerifyCode);
        }
    }
}
