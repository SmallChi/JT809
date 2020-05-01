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
    /// 主链路注销请求消息
    /// <para>链路类型:主链路</para>
    /// <para>消息方向：下级平台往上级平台</para>
    /// <para>业务数据类型标识：UP-DISCONNECT-REQ</para>
    /// <para>描述：下级平台在中断与上级平台的主链路连接时，应向上级平台发送主链路注销请求消息。</para>
    /// </summary>
    public class JT809_0x1003 : JT809Bodies, IJT809MessagePackFormatter<JT809_0x1003>, IJT809Analyze
    {
        public override ushort MsgId => JT809BusinessType.主链路注销请求消息.ToUInt16Value();

        public override string Description => "主链路注销请求消息";

        public override JT809_LinkType LinkType => JT809_LinkType.main;
        /// <summary>
        /// 用户名
        /// </summary>
        public uint UserId { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1003 value = new JT809_0x1003();
            value.UserId = reader.ReadUInt32();
            writer.WriteNumber($"[{value.UserId.ReadNumber()}]用户名", value.UserId);
            var virtualHex = reader.ReadVirtualArray(8);
            value.Password = reader.ReadString(8);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]密码", value.Password);
        }

        public JT809_0x1003 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1003 value = new JT809_0x1003();
            value.UserId = reader.ReadUInt32();
            value.Password = reader.ReadString(8);
            return value;
        }
        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1003 value, IJT809Config config)
        {
            writer.WriteUInt32(value.UserId);
            writer.WriteStringPadLeft(value.Password, 8);
        }
    }
}
