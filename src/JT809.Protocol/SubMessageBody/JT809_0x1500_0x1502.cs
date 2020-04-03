using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 车辆拍照应答
    /// <para>子业务类型标识:UP_ CTRL_ MSG _TAKE_ PHOTO_ ACK</para>
    /// <para>描述:下级平台应答上级平台发送的车辆拍照请求消息，上传图片信息到上级平台</para>
    /// </summary>
    public class JT809_0x1500_0x1502:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1500_0x1502>
    {
        public JT809_0x1500_0x1502()
        {
            VehiclePosition = new JT809VehiclePositionProperties();
        }
        /// <summary>
        /// 拍照应答标识
        /// </summary>
        public JT809_0x1502_PhotoRspFlag PhotoRspFlag { get; set; }

        /// <summary>
        /// 车辆定位信息
        /// </summary>
        public JT809VehiclePositionProperties VehiclePosition { get; set; }
        /// <summary>
        /// 镜头ID
        /// </summary>
        public byte LensID { get; set; }
        /// <summary>
        /// 图片长度
        /// </summary>
        public uint PhotoLen { get; set; }
        /// <summary>
        /// 图片大小
        /// </summary>
        public byte SizeType { get; set; }
        /// <summary>
        /// 图像格式
        /// </summary>
        public byte Type { get; set; }
        /// <summary>
        /// 图片内容
        /// </summary>
        public byte[] Photo { get; set; }
        public JT809_0x1500_0x1502 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1500_0x1502 jT809_0X1500_0X1502 = new JT809_0x1500_0x1502();
            jT809_0X1500_0X1502.PhotoRspFlag = (JT809_0x1502_PhotoRspFlag)reader.ReadByte();
            jT809_0X1500_0X1502.VehiclePosition.Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte();
            jT809_0X1500_0X1502.VehiclePosition.Day = reader.ReadByte();
            jT809_0X1500_0X1502.VehiclePosition.Month = reader.ReadByte();
            jT809_0X1500_0X1502.VehiclePosition.Year = reader.ReadUInt16();
            jT809_0X1500_0X1502.VehiclePosition.Hour = reader.ReadByte();
            jT809_0X1500_0X1502.VehiclePosition.Minute = reader.ReadByte();
            jT809_0X1500_0X1502.VehiclePosition.Second = reader.ReadByte();
            jT809_0X1500_0X1502.VehiclePosition.Lon = reader.ReadUInt32();
            jT809_0X1500_0X1502.VehiclePosition.Lat = reader.ReadUInt32();
            jT809_0X1500_0X1502.VehiclePosition.Vec1 = reader.ReadUInt16();
            jT809_0X1500_0X1502.VehiclePosition.Vec2 = reader.ReadUInt16();
            jT809_0X1500_0X1502.VehiclePosition.Vec3 = reader.ReadUInt32();
            jT809_0X1500_0X1502.VehiclePosition.Direction = reader.ReadUInt16();
            jT809_0X1500_0X1502.VehiclePosition.Altitude = reader.ReadUInt16();
            jT809_0X1500_0X1502.VehiclePosition.State = reader.ReadUInt32();
            jT809_0X1500_0X1502.VehiclePosition.Alarm = reader.ReadUInt32();
            jT809_0X1500_0X1502.LensID = reader.ReadByte();
            jT809_0X1500_0X1502.PhotoLen = reader.ReadUInt32();
            jT809_0X1500_0X1502.SizeType = reader.ReadByte();
            jT809_0X1500_0X1502.Type = reader.ReadByte();
            if (jT809_0X1500_0X1502.PhotoLen > 0)
            {
                jT809_0X1500_0X1502.Photo = reader.ReadArray((int)jT809_0X1500_0X1502.PhotoLen).ToArray();
            }
            return jT809_0X1500_0X1502;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1500_0x1502 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.PhotoRspFlag);
            writer.WriteByte((byte)value.VehiclePosition.Encrypt);
            writer.WriteByte(value.VehiclePosition.Day);
            writer.WriteByte(value.VehiclePosition.Month);
            writer.WriteUInt16(value.VehiclePosition.Year);
            writer.WriteByte(value.VehiclePosition.Hour);
            writer.WriteByte(value.VehiclePosition.Minute);
            writer.WriteByte(value.VehiclePosition.Second);
            writer.WriteUInt32(value.VehiclePosition.Lon);
            writer.WriteUInt32(value.VehiclePosition.Lat);
            writer.WriteUInt16(value.VehiclePosition.Vec1);
            writer.WriteUInt16(value.VehiclePosition.Vec2);
            writer.WriteUInt32(value.VehiclePosition.Vec3);
            writer.WriteUInt16(value.VehiclePosition.Direction);
            writer.WriteUInt16(value.VehiclePosition.Altitude);
            writer.WriteUInt32(value.VehiclePosition.State);
            writer.WriteUInt32(value.VehiclePosition.Alarm);
            writer.WriteByte(value.LensID);
            bool isPhoto = (value.Photo != null && value.Photo.Length > 0);
            writer.WriteUInt32(isPhoto ? (uint)value.Photo.Length : 0);
            writer.WriteByte(value.SizeType);
            writer.WriteByte(value.Type);
            if (isPhoto)
            {
                writer.WriteArray(value.Photo);
            }
        }
    }
}
