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
    public class JT809_0x1500_0x1502 : JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1500_0x1502>, IJT809Analyze
    {
        public override ushort SubMsgId => JT809SubBusinessType.车辆拍照应答.ToUInt16Value();

        public override string Description => "车辆拍照应答";
        /// <summary>
        /// 拍照应答标识
        /// </summary>
        public JT809_0x1502_PhotoRspFlag PhotoRspFlag { get; set; }

        /// <summary>
        /// 车辆定位信息 2011版本
        /// </summary>
        public JT809VehiclePositionProperties VehiclePosition { get; set; }
        /// <summary>
        /// 车辆定位信息 2019版本
        /// </summary>
        public JT809VehiclePositionProperties_2019 VehiclePosition_2019 { get; set; }
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
        public JT809_0x9502_SizeType SizeType { get; set; }
        /// <summary>
        /// 图像格式
        /// </summary>
        public JT809_0x9502_ImageType Type { get; set; }
        /// <summary>
        /// 图片内容
        /// </summary>
        public byte[] Photo { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1500_0x1502 value = new JT809_0x1500_0x1502();
            value.PhotoRspFlag = (JT809_0x1502_PhotoRspFlag)reader.ReadByte();
            writer.WriteString($"[{value.PhotoRspFlag.ToByteValue()}]拍照应答标识", value.PhotoRspFlag.ToString());
            if (config.Version == JT809Version.JTT2011)
            {
                config.GetMessagePackFormatter<JT809VehiclePositionProperties>().Analyze(ref reader, writer, config);
            }
            else if (config.Version == JT809Version.JTT2019)
            {
                config.GetMessagePackFormatter<JT809VehiclePositionProperties_2019>().Analyze(ref reader, writer, config);
            }
            value.LensID = reader.ReadByte();
            writer.WriteNumber($"[{value.LensID}]镜头ID", value.LensID);
            value.PhotoLen = reader.ReadUInt32();
            writer.WriteNumber($"[{value.PhotoLen}]图片长度", value.PhotoLen);
            value.SizeType = (JT809_0x9502_SizeType)reader.ReadByte();
            writer.WriteString($"[{value.SizeType.ToByteValue()}]图片大小", value.SizeType.ToString());
            value.Type = (JT809_0x9502_ImageType)reader.ReadByte();
            writer.WriteString($"[{value.Type.ToByteValue()}]图像格式", value.Type.ToString());
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
            if (config.Version == JT809Version.JTT2011)
            {
                value.VehiclePosition = config.GetMessagePackFormatter<JT809VehiclePositionProperties>().Deserialize(ref reader, config);
            }
            else if (config.Version == JT809Version.JTT2019)
            {
                value.VehiclePosition_2019 = config.GetMessagePackFormatter<JT809VehiclePositionProperties_2019>().Deserialize(ref reader, config);
            }
            value.LensID = reader.ReadByte();
            value.PhotoLen = reader.ReadUInt32();
            value.SizeType = (JT809_0x9502_SizeType)reader.ReadByte();
            value.Type = (JT809_0x9502_ImageType)reader.ReadByte();
            if (value.PhotoLen > 0)
            {
                value.Photo = reader.ReadArray((int)value.PhotoLen).ToArray();
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1500_0x1502 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.PhotoRspFlag);
            if (config.Version == JT809Version.JTT2011)
            {
                if (value.VehiclePosition != null)
                {
                    config.GetMessagePackFormatter<JT809VehiclePositionProperties>().Serialize(ref writer, value.VehiclePosition, config);
                }
            }
            else if (config.Version == JT809Version.JTT2019)
            {
                if (value.VehiclePosition_2019 != null)
                {
                    config.GetMessagePackFormatter<JT809VehiclePositionProperties_2019>().Serialize(ref writer, value.VehiclePosition_2019, config);
                }
            }
            writer.WriteByte(value.LensID);
            bool isPhoto = (value.Photo != null && value.Photo.Length > 0);
            writer.WriteUInt32(isPhoto ? (uint)value.Photo.Length : 0);
            writer.WriteByte(value.SizeType.ToByteValue());
            writer.WriteByte(value.Type.ToByteValue());
            if (isPhoto)
            {
                writer.WriteArray(value.Photo);
            }
        }

    }
}
