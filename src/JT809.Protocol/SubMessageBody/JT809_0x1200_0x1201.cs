using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上传车辆注册信息消息
    /// <para>子业务类型标识:UP_ EXG_ MSG_ REGISTER</para>
    /// <para>描述:监控平台收到车载终端鉴权信息后，启动本命令向上级监管平台上传该车辆注册信息.各级监管平台再逐级向上级平台上传该信息</para>
    /// <para>本条消息服务端无需应答</para>
    /// </summary>
    public class JT809_0x1200_0x1201:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x1201>
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
        /// 车载终端编号，大写字母和数字组成
        /// </summary>
        public string TerminalId { get; set; }
        /// <summary>
        /// 车载终端 SIM 卡电话号码。号码不是12 位，则在前补充数字 0.
        /// </summary>
        public string TerminalSimCode { get; set; }

        public JT809_0x1200_0x1201 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x1201 jT809_0X1200_0X1201 = new JT809_0x1200_0x1201();
            jT809_0X1200_0X1201.PlateformId = reader.ReadBigNumber(11);
            jT809_0X1200_0X1201.ProducerId = reader.ReadBigNumber(11);
            jT809_0X1200_0X1201.TerminalModelType = reader.ReadString(20);
            jT809_0X1200_0X1201.TerminalId = reader.ReadString(7);
            jT809_0X1200_0X1201.TerminalId = jT809_0X1200_0X1201.TerminalId.ToUpper();
            jT809_0X1200_0X1201.TerminalSimCode = reader.ReadString(12);
            return jT809_0X1200_0X1201;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x1201 value, IJT809Config config)
        {
            writer.WriteBigNumber(value.PlateformId, 11);
            writer.WriteBigNumber(value.ProducerId, 11);
            writer.WriteStringPadRight(value.TerminalModelType, 20);
            writer.WriteStringPadRight(value.TerminalId.ToUpper(), 7);
            writer.WriteStringPadRight(value.TerminalSimCode, 12);
        }
    }
}
