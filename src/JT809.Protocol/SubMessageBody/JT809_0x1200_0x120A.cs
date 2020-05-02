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
    /// 上报驾驶员身份识别信息应答消息
    /// <para>子业务类型标识:UP_EXG_MSG_REPORT_DRIVER_INFO_ACK</para>
    /// <para>描述:下级平台应答上级平台发送的上报驾驶员身份识别信息请求消息，上传指定车辆的驾驶员身份识别信息数据</para>
    /// </summary>
    public class JT809_0x1200_0x120A:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x120A>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.上报驾驶员身份识别信息应答消息.ToUInt16Value();

        public override string Description => "上报驾驶员身份识别信息应答消息";
        /// <summary>
        /// 对应上报驾驶员身份请求信息源子业务类型标识
        /// </summary>
        public ushort SourceDataType { get; set; }
        /// <summary>
        /// 对应上报驾驶员身份请求消息源报文序列号
        /// </summary>
        public uint SourceMsgSn { get; set; }
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
            JT809_0x1200_0x120A value = new JT809_0x1200_0x120A();
            if (config.Version == JT809Version.JTT2019)
            {
                value.SourceDataType = reader.ReadUInt16();
                writer.WriteString($"[{value.SourceDataType.ReadNumber()}]对应启动车辆定位信息交换请求消息源子业务类型标识", ((JT809SubBusinessType)value.SourceDataType).ToString());
                value.SourceMsgSn = reader.ReadUInt32();
                writer.WriteNumber($"[{value.SourceMsgSn.ReadNumber()}对应启动车辆定位信息交换请求消息源报文序列号]", value.SourceMsgSn);
            }
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

        public JT809_0x1200_0x120A Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x120A value = new JT809_0x1200_0x120A();
            if (config.Version == JT809Version.JTT2019) {
                value.SourceDataType = reader.ReadUInt16();
                value.SourceMsgSn = reader.ReadUInt32();
            }
            value.DriverName = reader.ReadString(16);
            value.DriverID = reader.ReadString(20);
            value.Licence = reader.ReadString(40);
            value.OrgName = reader.ReadString(200);
            if (config.Version == JT809Version.JTT2019) {
                value.ValidDate = reader.ReadUTCDateTime();
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x120A value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2019)
            {
                writer.WriteUInt16(value.SourceDataType);
                writer.WriteUInt32(value.SourceMsgSn);
            }
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
