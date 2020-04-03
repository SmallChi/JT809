using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using System;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 报警督办请求消息
    /// <para>子业务类型标识:DOWN_WARN_MSG_URGE_TODO_REQ</para>
    /// <para>描述:上级平台向车辆归属下级平台下发本消息，催促其及时处理相关车辆的报警信息</para>
    /// </summary>
    public class JT809_0x9400_0x9401:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9400_0x9401>
    {
        /// <summary>
        /// 报警信息来源
        /// </summary>
        public JT809WarnSrc WarnSrc { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public ushort WarnType { get; set; }
        /// <summary>
        /// 报警时间UTCDateTime
        /// </summary>
        public DateTime WarnTime { get; set; }
        /// <summary>
        /// 报警督办ID HexString
        /// </summary>
        public string SupervisionID { get; set; }
        /// <summary>
        /// 督办截止时间
        /// </summary>
        public DateTime SupervisionEndTime { get; set; }
        /// <summary>
        /// 督办级别
        /// </summary>
        public byte SupervisionLevel { get; set; }
        /// <summary>
        /// 督办人
        /// </summary>
        public string Supervisor { get; set; }
        /// <summary>
        /// 督办联系电话
        /// </summary>
        public string SupervisorTel { get; set; }
        /// <summary>
        /// 督办联系电子邮件
        /// </summary>
        public string SupervisorEmail { get; set; }
        public JT809_0x9400_0x9401 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9400_0x9401 jT809_0X9400_0X9401 = new JT809_0x9400_0x9401();
            jT809_0X9400_0X9401.WarnSrc = (JT809WarnSrc)reader.ReadByte();
            jT809_0X9400_0X9401.WarnType = reader.ReadUInt16();
            jT809_0X9400_0X9401.WarnTime = reader.ReadUTCDateTime();
            jT809_0X9400_0X9401.SupervisionID = reader.ReadHex(4);
            jT809_0X9400_0X9401.SupervisionEndTime = reader.ReadUTCDateTime();
            jT809_0X9400_0X9401.SupervisionLevel = reader.ReadByte();
            jT809_0X9400_0X9401.Supervisor = reader.ReadString(16);
            jT809_0X9400_0X9401.SupervisorTel = reader.ReadString(20);
            jT809_0X9400_0X9401.SupervisorEmail = reader.ReadString(32);
            return jT809_0X9400_0X9401;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9400_0x9401 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.WarnSrc);
            writer.WriteUInt16((ushort)value.WarnType);
            writer.WriteUTCDateTime(value.WarnTime);
            writer.WriteHex(value.SupervisionID, 4);
            writer.WriteUTCDateTime(value.SupervisionEndTime);
            writer.WriteByte(value.SupervisionLevel);
            writer.WriteStringPadRight(value.Supervisor, 16);
            writer.WriteStringPadRight(value.SupervisorTel, 20);
            writer.WriteStringPadRight(value.SupervisorEmail, 32);
        }
    }
}
