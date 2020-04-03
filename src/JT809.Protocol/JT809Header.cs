using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol
{
    public class JT809Header: IJT809MessagePackFormatter<JT809Header>
    {
        /// <summary>
        /// 固定为22个字节长度
        /// <para>MSG LENGTH + MSG_SN + MSG_ID + MSG_GNSSCENTERID + VERSION_FLAG + ENCRYPT_FLAG + ENCRYPT_KEY</para>
        /// <para>4 + 4 + 2 + 4 + 3 + 1 + 4 = 22</para>
        /// </summary>
        public const int FixedByteLength = 22;
        /// <summary>
        /// 数据长度(包括头标识、数据头、数据体和尾标识)
        /// <para>头标识 + 数据头 + 数据体 + 尾标识</para>
        /// <para>1 + 22 + n + 1</para>
        /// </summary>
        public uint MsgLength { get; set; }
        /// <summary>
        /// 报文序列号 a
        /// </summary>
        public uint MsgSN { get; set; }
        /// <summary>
        /// 业务数据类型
        /// </summary>
        public ushort BusinessType { get; set; }
        /// <summary>
        /// 下级平台接入码，上级平台给下级平台分配唯一标识码。
        /// </summary>
        public uint MsgGNSSCENTERID { get; set; }
        /// <summary>
        /// 协议版本号标识，上下级平台之间采用的标准协议版
        /// 编号；长度为 3 个字节来表示，0x01 0x02 0x0F 标识
        /// 的版本号是 v1.2.15，以此类推。
        /// Hex编码
        /// </summary>
        public JT809Header_Version Version { get; set; } = new JT809Header_Version();
        /// <summary>
        /// 报文加密标识位 b: 0 表示报文不加密，1 表示报文加密。
        /// </summary>
        public JT809Header_Encrypt EncryptFlag { get; set; } = JT809Header_Encrypt.None;
        /// <summary>
        /// 数据加密的密匙，长度为 4 个字节
        /// </summary>
        public uint EncryptKey { get; set; }

        public JT809Header Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809Header jT809Header = new JT809Header();
            jT809Header.MsgLength = reader.ReadUInt32();
            jT809Header.MsgSN = reader.ReadUInt32();
            jT809Header.BusinessType = reader.ReadUInt16();
            jT809Header.MsgGNSSCENTERID = reader.ReadUInt32();
            jT809Header.Version = new JT809Header_Version(reader.ReadArray(JT809Header_Version.FixedByteLength));
            jT809Header.EncryptFlag = (JT809Header_Encrypt)reader.ReadByte();
            jT809Header.EncryptKey = reader.ReadUInt32();
            return jT809Header;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809Header value, IJT809Config config)
        {
            writer.WriteUInt32(value.MsgLength);
            writer.WriteUInt32(value.MsgSN);
            writer.WriteUInt16(value.BusinessType);
            writer.WriteUInt32(value.MsgGNSSCENTERID);
            writer.WriteArray(value.Version.Buffer);
            writer.WriteByte((byte)value.EncryptFlag);
            writer.WriteUInt32(value.EncryptKey);
        }
    }
}
