using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上报驾驶员身份识别信息应答消息
    /// <para>子业务类型标识:UP_EXG_MSG_REPORT_DRIVER_INFO_ACK</para>
    /// <para>描述:下级平台应答上级平台发送的上报驾驶员身份识别信息请求消息，上传指定车辆的驾驶员身份识别信息数据</para>
    /// </summary>
    public class JT809_0x1200_0x120A:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x120A>
    {
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

        public JT809_0x1200_0x120A Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x120A jT809_0X1200_0X120A = new JT809_0x1200_0x120A();
            jT809_0X1200_0X120A.DriverName = reader.ReadString(16);
            jT809_0X1200_0X120A.DriverID = reader.ReadString(20);
            jT809_0X1200_0X120A.Licence = reader.ReadString(40);
            jT809_0X1200_0X120A.OrgName = reader.ReadString(200);
            return jT809_0X1200_0X120A;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x120A value, IJT809Config config)
        {
            writer.WriteStringPadRight(value.DriverName, 16);
            writer.WriteStringPadRight(value.DriverID, 20);
            writer.WriteStringPadRight(value.Licence, 40);
            writer.WriteStringPadRight(value.OrgName, 200);
        }
    }
}
