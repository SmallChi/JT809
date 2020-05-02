using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 主动上报驾驶员身份信息消息
    /// <para>子业务类型标识:UP_EXG_MSG_REPORT_DRIVER_INFO</para>
    /// <para>下级平台在接收到车载终端上传的驾驶员身份信息后，主动向上级平台上报该消息</para>
    /// </summary>
    public class JT809_0x1200_0x120C:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x120C>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.主动上报驾驶员身份信息消息.ToUInt16Value();

        public override string Description => "主动上报驾驶员身份信息消息";
        /// <summary>
        /// 驾驶员姓名
        /// </summary>
        public string DriverName { get; set; }
        /// <summary>
        /// 身份证编号
        /// </summary>
        public string DriverID { get; set; }
        /// <summary>
        /// 从业资格证（备用）
        /// </summary>
        public string Licence { get; set; }
        /// <summary>
        /// 发证机构名称（备用）
        /// </summary>
        public string OrgName { get; set; }
        /// <summary>
        /// 证件有效期，时分秒均用0表示
        /// </summary>
        public DateTime ValidDate { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1200_0x120C value = new JT809_0x1200_0x120C();
            var virtualHex = reader.ReadVirtualArray(16);
            value.DriverName = reader.ReadString(16);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]驾驶员姓名", value.DriverName);
            virtualHex = reader.ReadVirtualArray(20);
            value.DriverID = reader.ReadString(20);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]身份证编号", value.DriverID);
            virtualHex = reader.ReadVirtualArray(40);
            value.Licence = reader.ReadString(40);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]从业资格证", value.Licence);
            virtualHex = reader.ReadVirtualArray(200);
            value.OrgName = reader.ReadString(200);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]发证机构名称", value.OrgName);
            if (config.Version == JT809Version.JTT2019)
            {
                virtualHex = reader.ReadVirtualArray(8);
                value.ValidDate = reader.ReadUTCDateTime();
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]证件有效期", value.ValidDate);
            }
        }

        public JT809_0x1200_0x120C Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x120C value = new JT809_0x1200_0x120C();
            value.DriverName = reader.ReadString(16);
            value.DriverID = reader.ReadString(20);
            value.Licence = reader.ReadString(40);
            value.OrgName = reader.ReadString(200);
            if (config.Version == JT809Version.JTT2019)
            {
                value.ValidDate = reader.ReadUTCDateTime();
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x120C value, IJT809Config config)
        {
            writer.WriteStringPadRight(value.DriverName, 16);
            writer.WriteStringPadRight(value.DriverID, 20);
            writer.WriteStringPadRight(value.Licence, 40);
            writer.WriteStringPadRight(value.OrgName, 200);
            if (config.Version == JT809Version.JTT2019)
            {
                writer.WriteUTCDateTime(value.ValidDate);
            }
        }
    }
}
