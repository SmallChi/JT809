using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 主动上报驾驶员身份信息消息
    /// <para>子业务类型标识:UP_EXG_MSG_REPORT_DRIVER_INFO</para>
    /// </summary>
    public class JT809_0x1200_0x120C:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x120C>, IJT809_2019_Version
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

        public JT809_0x1200_0x120C Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x120C jT809_0X1200_0X120C = new JT809_0x1200_0x120C();
            jT809_0X1200_0X120C.DriverName = reader.ReadString(16);
            jT809_0X1200_0X120C.DriverID = reader.ReadString(20);
            jT809_0X1200_0X120C.Licence = reader.ReadString(40);
            jT809_0X1200_0X120C.OrgName = reader.ReadString(200);
            return jT809_0X1200_0X120C;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x120C value, IJT809Config config)
        {
            writer.WriteStringPadRight(value.DriverName, 16);
            writer.WriteStringPadRight(value.DriverID, 20);
            writer.WriteStringPadRight(value.Licence, 40);
            writer.WriteStringPadRight(value.OrgName, 200);
        }
    }
}
