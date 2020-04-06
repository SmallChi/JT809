using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;


namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 主链路登录请求消息
    /// <para>链路类型:主链路</para>
    /// <para>消息方向:下级平台往上级平台</para>
    /// <para>业务数据类型标识: UP-CONNECT-REQ</para>
    /// <para>描述:下级平台向上级平台发送用户名和密码等登录信息</para>
    /// </summary>
    public class JT809_0x1001: JT809Bodies,IJT809MessagePackFormatter<JT809_0x1001>, IJT809_2019_Version
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public uint UserId { get; set; }
        /// <summary>
        /// 密码
        /// 8位
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 下级平台接入码
        /// </summary>
        public uint MsgGNSSCENTERID { get; set; }
        /// <summary>
        /// 下级平台提供对应的从链路服务端 IP 地址
        /// 32位
        /// </summary>
        public string DownLinkIP { get; set; }
        /// <summary>
        /// 下级平台提供对应的从链路服务器端口号
        /// </summary>
        public ushort DownLinkPort { get; set; }

        public override ushort MsgId => JT809BusinessType.主链路登录请求消息.ToUInt16Value();

        public override string Description => "主链路登录请求消息";

        public override JT809_LinkType LinkType =>  JT809_LinkType.main;

        public JT809_0x1001 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1001 jT809_0X1001 = new JT809_0x1001();
            jT809_0X1001.UserId = reader.ReadUInt32();
            jT809_0X1001.Password = reader.ReadString(8);
            if(config.Version== JT809Version.JTT2019)
            {
                jT809_0X1001.MsgGNSSCENTERID = reader.ReadUInt32();
            }
            jT809_0X1001.DownLinkIP = reader.ReadString(32);
            jT809_0X1001.DownLinkPort = reader.ReadUInt16();
            return jT809_0X1001;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1001 value, IJT809Config config)
        {
            writer.WriteUInt32(value.UserId);
            writer.WriteStringPadRight(value.Password, 8);
            if (config.Version == JT809Version.JTT2019)
            {
                writer.WriteUInt32(value.MsgGNSSCENTERID);
            }
            writer.WriteStringPadRight(value.DownLinkIP, 32);
            writer.WriteUInt16(value.DownLinkPort);
        }
    }
}
