using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Metadata;
using JT809.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 车辆拍照应答
    /// <para>子业务类型标识:UP_ CTRL_ MSG _TAKE_ PHOTO_ ACK</para>
    /// <para>描述:下级平台应答上级平台发送的车辆拍照请求消息，上传图片信息到上级平台</para>
    /// </summary>
    public class JT809_0x1500_0x1502:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1500_0x1502>, IJT809Analyze
    {
        public override ushort SubMsgId => JT809SubBusinessType.车辆拍照应答.ToUInt16Value();

        public override string Description => "车辆拍照应答";
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

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1500_0x1502 value = new JT809_0x1500_0x1502();
            value.PhotoRspFlag = (JT809_0x1502_PhotoRspFlag)reader.ReadByte();
            writer.WriteString($"[{value.PhotoRspFlag.ToByteValue()}]拍照应答标识", value.PhotoRspFlag.ToString());
            writer.WriteStartObject("车辆定位信息");
            value.VehiclePosition.Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte();
            writer.WriteString($"[{value.VehiclePosition.Encrypt.ToByteValue()}]是否使用国家测绘局批准的地图保密插件进行加密", value.VehiclePosition.Encrypt.ToString());
            value.VehiclePosition.Day = reader.ReadByte();
            writer.WriteNumber($"[{value.VehiclePosition.Day}]日", value.VehiclePosition.Day);
            value.VehiclePosition.Month = reader.ReadByte();
            writer.WriteNumber($"[{value.VehiclePosition.Month}]月", value.VehiclePosition.Month);
            value.VehiclePosition.Year = reader.ReadUInt16();
            writer.WriteNumber($"[{value.VehiclePosition.Year}]年", value.VehiclePosition.Year);
            value.VehiclePosition.Hour = reader.ReadByte();
            writer.WriteNumber($"[{value.VehiclePosition.Hour}]时", value.VehiclePosition.Hour);
            value.VehiclePosition.Minute = reader.ReadByte();
            writer.WriteNumber($"[{value.VehiclePosition.Minute}]分", value.VehiclePosition.Minute);
            value.VehiclePosition.Second = reader.ReadByte();
            writer.WriteNumber($"[{value.VehiclePosition.Second}]秒", value.VehiclePosition.Second);
            value.VehiclePosition.Lon = reader.ReadUInt32();
            writer.WriteNumber($"[{value.VehiclePosition.Lon}]经度", value.VehiclePosition.Lon);
            value.VehiclePosition.Lat = reader.ReadUInt32();
            writer.WriteNumber($"[{value.VehiclePosition.Lat}]纬度", value.VehiclePosition.Lat);
            value.VehiclePosition.Vec1 = reader.ReadUInt16();
            writer.WriteNumber($"[{value.VehiclePosition.Vec1}]速度", value.VehiclePosition.Vec1);
            value.VehiclePosition.Vec2 = reader.ReadUInt16();
            writer.WriteNumber($"[{value.VehiclePosition.Vec2}]行驶记录速度", value.VehiclePosition.Vec2);
            value.VehiclePosition.Vec3 = reader.ReadUInt32();
            writer.WriteNumber($"[{value.VehiclePosition.Vec3}]车辆当前总里程数", value.VehiclePosition.Vec3);
            value.VehiclePosition.Direction = reader.ReadUInt16();
            writer.WriteNumber($"[{value.VehiclePosition.Direction}]方向", value.VehiclePosition.Direction);
            value.VehiclePosition.Altitude = reader.ReadUInt16();
            writer.WriteNumber($"[{value.VehiclePosition.Altitude}]海拔高度", value.VehiclePosition.Altitude);
            value.VehiclePosition.State = reader.ReadUInt32();
            writer.WriteNumber($"[{value.VehiclePosition.State}]车辆状态", value.VehiclePosition.State);
            value.VehiclePosition.Alarm = reader.ReadUInt32();
            writer.WriteNumber($"[{value.VehiclePosition.Alarm}]报警状态", value.VehiclePosition.Alarm);
            writer.WriteEndObject();
            value.LensID = reader.ReadByte();
            writer.WriteNumber($"[{value.LensID}]镜头ID", value.LensID);
            value.PhotoLen = reader.ReadUInt32();
            writer.WriteNumber($"[{value.PhotoLen}]图片长度", value.PhotoLen);
            value.SizeType = reader.ReadByte();
            writer.WriteNumber($"[{value.SizeType}]图片大小", value.SizeType);
            value.Type = reader.ReadByte();
            writer.WriteNumber($"[{value.Type}]图像格式", value.Type);
            if (value.PhotoLen > 0)
            {
                var virtualHex = reader.ReadVirtualArray((int)value.PhotoLen);
                value.Photo = reader.ReadArray((int)value.PhotoLen).ToArray();
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]图片内容", value.Photo);
            }
        }
        public JT809_0x1500_0x1502 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1500_0x1502 value = new JT809_0x1500_0x1502();
            value.PhotoRspFlag = (JT809_0x1502_PhotoRspFlag)reader.ReadByte();
            value.VehiclePosition.Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte();
            value.VehiclePosition.Day = reader.ReadByte();
            value.VehiclePosition.Month = reader.ReadByte();
            value.VehiclePosition.Year = reader.ReadUInt16();
            value.VehiclePosition.Hour = reader.ReadByte();
            value.VehiclePosition.Minute = reader.ReadByte();
            value.VehiclePosition.Second = reader.ReadByte();
            value.VehiclePosition.Lon = reader.ReadUInt32();
            value.VehiclePosition.Lat = reader.ReadUInt32();
            value.VehiclePosition.Vec1 = reader.ReadUInt16();
            value.VehiclePosition.Vec2 = reader.ReadUInt16();
            value.VehiclePosition.Vec3 = reader.ReadUInt32();
            value.VehiclePosition.Direction = reader.ReadUInt16();
            value.VehiclePosition.Altitude = reader.ReadUInt16();
            value.VehiclePosition.State = reader.ReadUInt32();
            value.VehiclePosition.Alarm = reader.ReadUInt32();
            value.LensID = reader.ReadByte();
            value.PhotoLen = reader.ReadUInt32();
            value.SizeType = reader.ReadByte();
            value.Type = reader.ReadByte();
            if (value.PhotoLen > 0)
            {
                value.Photo = reader.ReadArray((int)value.PhotoLen).ToArray();
            }
            return value;
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
