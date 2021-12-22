using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 车辆拍照请求消息
    /// <para>子业务类型标识:DOWN_CTRL_MSG_TAKE_PHOTO_REQ</para>
    /// <para>描述:上级平台向下级平台下发对某指定车辆的拍照请求消息</para>
    /// </summary>
    public class JT809_0x9500_0x9502:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9500_0x9502>, IJT809Analyze
    {
        public override ushort SubMsgId => JT809SubBusinessType.车辆拍照请求消息.ToUInt16Value();

        public override string Description => "车辆拍照请求消息";
        /// <summary>
        /// 镜头ID
        /// </summary>
        public byte LensID { get; set; }
        /// <summary>
        /// 图片大小
        /// Ox01:320x240:
        /// Ox02:640x480:
        /// Ox03;:800x600:
        /// Ox04:1024x768:
        /// Ox05:176x 144[QCIF];
        /// 0x06:704x288[CIF];
        /// 0x07:704x288[HALF D];
        /// Ox08:704x576[DI]
        /// </summary>
        public JT809_0x9502_SizeType SizeType { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x9500_0x9502 value = new JT809_0x9500_0x9502();
            value.LensID = reader.ReadByte();
            writer.WriteNumber($"[{value.LensID.ReadNumber() }]镜头ID", value.LensID);
            value.SizeType = (JT809_0x9502_SizeType)reader.ReadByte();
            writer.WriteString($"[{value.SizeType.ToByteValue()}]图片大小", value.SizeType.ToString());
        }

        public JT809_0x9500_0x9502 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9500_0x9502 value = new JT809_0x9500_0x9502();
            value.LensID = reader.ReadByte();
            value.SizeType = (JT809_0x9502_SizeType)reader.ReadByte();
            return value;
        }
        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9500_0x9502 value, IJT809Config config)
        {
            writer.WriteByte(value.LensID);
            writer.WriteByte(value.SizeType.ToByteValue());
        }
    }
}
