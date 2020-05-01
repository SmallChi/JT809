using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 主链路登录应答消息
    /// <para>链路类型:主链路</para>
    /// <para>消息方向:上级平台往下级平台</para>
    /// <para>业务数据类型标识:UP_CONNCCT_RSP</para>
    /// <para>描述:上级平台对下级平台登录请求信息、进行安全验证后，返回相应的验证结果。</para>
    /// </summary>
    public class JT809_0x1002 : JT809Bodies, IJT809MessagePackFormatter<JT809_0x1002>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort MsgId => JT809BusinessType.主链路登录应答消息.ToUInt16Value();

        public override string Description => "主链路登录应答消息";

        public override JT809_LinkType LinkType => JT809_LinkType.main;
        /// <summary>
        /// 验证结果，定义如下：
        /// 0x00:成功;
        /// 0x01:IP 地址不正确;
        /// 0x02:接入码不正确;
        /// 0x03:用户没用注册;
        /// 0x04:密码错误;
        /// 0x05:资源紧张，稍后再连接(已经占用;
        /// 0x06:其他。
        /// </summary>
        public JT809_0x1002_Result Result { get; set; }
        /// <summary>
        /// 校验码
        /// </summary>
        public uint VerifyCode { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1002 value = new JT809_0x1002();
            value.Result = (JT809_0x1002_Result)reader.ReadByte();
            writer.WriteString($"[{value.Result.ToByteValue()}]验证结果", value.Result.ToString());
            value.VerifyCode = reader.ReadUInt32();
            writer.WriteNumber($"[{value.VerifyCode.ReadNumber()}]校验码",value.VerifyCode);
        }

        public JT809_0x1002 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1002 value = new JT809_0x1002();
            value.Result = (JT809_0x1002_Result)reader.ReadByte();
            value.VerifyCode = reader.ReadUInt32();
            return value;
        }
        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1002 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.Result);
            writer.WriteUInt32(value.VerifyCode);
        }
    }
}
