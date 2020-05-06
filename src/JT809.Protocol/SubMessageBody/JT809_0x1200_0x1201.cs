using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上传车辆注册信息消息
    /// <para>子业务类型标识:UP_EXG_MSG_REGISTER</para>
    /// <para>描述:监控平台收到车载终端鉴权信息后，启动本命令向上级监管平台上传该车辆注册信息.各级监管平台再逐级向上级平台上传该信息</para>
    /// <para>本条消息服务端无需应答</para>
    /// </summary>
    public class JT809_0x1200_0x1201:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x1201>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.上传车辆注册信息.ToUInt16Value();

        public override string Description => "上传车辆注册信息";

        /// <summary>
        /// 平台唯一编码
        /// </summary>
        public string PlateformId { get; set; }
        /// <summary>
        /// 车载终端厂商唯一编码
        /// </summary>
        public string ProducerId { get; set; }
        /// <summary>
        /// 车载终端型号，不是 8 位时以“\0”终结
        /// </summary>
        public string TerminalModelType { get; set; }
        /// <summary>
        /// 车载终端通讯模块IMEI码
        /// 2019版本
        /// </summary>
        public string IMIEId { get; set; }
        /// <summary>
        /// 车载终端编号，大写字母和数字组成
        /// </summary>
        public string TerminalId { get; set; }
        /// <summary>
        /// 车载终端 SIM 卡电话号码。号码不是12 位，则在前补充数字 0.
        /// </summary>
        public string TerminalSimCode { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1200_0x1201 value = new JT809_0x1200_0x1201();            
            if (config.Version == JT809Version.JTT2011)
            {
                var virtualHex = reader.ReadVirtualArray(11);
                value.PlateformId = reader.ReadString(11);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]平台唯一编码", value.PlateformId);
                virtualHex = reader.ReadVirtualArray(11);
                value.ProducerId = reader.ReadString(11);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]车载终端厂商唯一编码", value.ProducerId);
                virtualHex = reader.ReadVirtualArray(20);
                value.TerminalModelType = reader.ReadString(20);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]车载终端型号", value.TerminalModelType);
                virtualHex = reader.ReadVirtualArray(7);
                value.TerminalId = reader.ReadString(7);
                value.TerminalId = value.TerminalId.ToUpper();
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]车载终端编号", value.TerminalId);
                virtualHex = reader.ReadVirtualArray(12);
                value.TerminalSimCode = reader.ReadString(12);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]车载终端", value.TerminalSimCode);
            }
            else
            {
                var virtualHex = reader.ReadVirtualArray(11);
                value.PlateformId = reader.ReadString(11);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]平台唯一编码", value.PlateformId);
                virtualHex = reader.ReadVirtualArray(11);
                value.ProducerId = reader.ReadString(11);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]车载终端厂商唯一编码", value.ProducerId);
                virtualHex = reader.ReadVirtualArray(30);
                value.TerminalModelType = reader.ReadString(30);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]车载终端型号", value.TerminalModelType);
                virtualHex = reader.ReadVirtualArray(15);
                value.IMIEId = reader.ReadString(15);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]车载终端通讯模块IMEI码", value.IMIEId);
                virtualHex = reader.ReadVirtualArray(30);
                value.TerminalId = reader.ReadString(30);
                value.TerminalId = value.TerminalId.ToUpper();
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]车载终端编号", value.TerminalId);
                virtualHex = reader.ReadVirtualArray(13);
                value.TerminalSimCode = reader.ReadString(13);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]车载终端", value.TerminalSimCode);
            }
        }

        public JT809_0x1200_0x1201 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x1201 value = new JT809_0x1200_0x1201();
            if(config.Version== JT809Version.JTT2011)
            {
                value.PlateformId = reader.ReadString(11);
                value.ProducerId = reader.ReadString(11);
                value.TerminalModelType = reader.ReadString(20);
                value.TerminalId = reader.ReadString(7);
                value.TerminalId = value.TerminalId.ToUpper();
                value.TerminalSimCode = reader.ReadString(12);
            }
            else
            {
                value.PlateformId = reader.ReadString(11);
                value.ProducerId = reader.ReadString(11);
                value.TerminalModelType = reader.ReadString(30);
                value.IMIEId = reader.ReadString(15);
                value.TerminalId = reader.ReadString(30);
                value.TerminalId = value.TerminalId.ToUpper();
                value.TerminalSimCode = reader.ReadString(13);
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x1201 value, IJT809Config config)
        {
            if(config.Version== JT809Version.JTT2011)
            {
                writer.WriteStringPadRight(value.PlateformId, 11);
                writer.WriteStringPadRight(value.ProducerId, 11);
                writer.WriteStringPadRight(value.TerminalModelType, 20);
                writer.WriteStringPadRight(value.TerminalId.ToUpper(), 7);
                writer.WriteStringPadLeft(value.TerminalSimCode, 12);
            }
            else
            {
                writer.WriteStringPadRight(value.PlateformId, 11);
                writer.WriteStringPadRight(value.ProducerId, 11);
                writer.WriteStringPadRight(value.TerminalModelType, 30);
                writer.WriteStringPadRight(value.IMIEId, 15);
                writer.WriteStringPadRight(value.TerminalId.ToUpper(), 30);
                writer.WriteStringPadRight(value.TerminalSimCode, 13);
            }
        }
    }
}
