using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System.Text.Json;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 从链路断开通知消息
    /// <para>链路类型:主链路</para>
    /// <para>消息方向:上级平台往下级平台</para>
    /// <para>业务数据类型标识:DOWN_DISCONNECT_INFORM</para>
    /// <para>描述:
    /// 情景 1:上级平台与下级平台的从链路中断后，重连二次仍未成功时，上级平台通过主链路发送本消息给下级平台。
    /// 情景 2:上级平台作为客户端向下级平台登录时，根据之前收到的 IP 地址及端口无法连接到下级平台服务端时发送本消息通知下级平台。
    /// </para>
    /// <para>本条消息无需被通知方应答</para>
    /// </summary>
    public class JT809_0x9007:JT809Bodies, IJT809MessagePackFormatter<JT809_0x9007>, IJT809Analyze
    {
        public override ushort MsgId => JT809BusinessType.从链路断开通知消息.ToUInt16Value();
        public override string Description => "从链路断开通知消息";
        public override JT809_LinkType LinkType => JT809_LinkType.main;
        /// <summary>
        /// 错误代码 2019版本
        /// </summary>
        public JT809_0x1007_ErrorCode ErrorCode { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        public JT809_0x9007_ReasonCode ReasonCode { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x9007 value = new JT809_0x9007();
            if(config.Version== JT809Version.JTT2019)
            {
                value.ErrorCode = (JT809_0x1007_ErrorCode)reader.ReadByte();
                writer.WriteString($"[{value.ErrorCode.ToByteValue()}]错误代码", value.ErrorCode.ToString());
            }
            else
            {
                value.ReasonCode = (JT809_0x9007_ReasonCode)reader.ReadByte();
                writer.WriteString($"[{value.ReasonCode.ToByteValue()}]错误代码", value.ReasonCode.ToString());
            }     
        }

        public JT809_0x9007 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9007 value = new JT809_0x9007();
            if (config.Version == JT809Version.JTT2019)
            {
                value.ErrorCode = (JT809_0x1007_ErrorCode)reader.ReadByte();
            }
            else
            {
                value.ReasonCode = (JT809_0x9007_ReasonCode)reader.ReadByte();
            }        
            return value;
        }
        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9007 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2019)
            {
                writer.WriteByte((byte)value.ErrorCode);
            }
            else
            {
                writer.WriteByte((byte)value.ReasonCode);
            }
           
        }
    }
}
