using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JT809.Protocol.Metadata
{
    public class JT809VehiclePositionProperties_2019:IJT809MessagePackFormatter<JT809VehiclePositionProperties_2019>, IJT809Analyze, IJT809_2019_Version
    {
        /// <summary>
        /// 是否使用国测局批准的地图保密插件进行加密 1 已加密 0未加密
        /// </summary>
        public JT809_VehiclePositionEncrypt Encrypt { get; set; }
        /// <summary>
        /// 车辆定位信息数据长度
        /// </summary>
        public uint DataLength { get; set; }
        /// <summary>
        /// 车辆定位信息内容，包括车辆位置基本信息和位置附加信息
        /// 其数据格式安装 808-2019中8.12要求
        /// </summary>
        public byte[] GnssData { get; set; }
        /// <summary>
        /// 监控平台唯一编码，由平台所在地行政区域代码和平台编码组成  11位
        /// </summary>
        public string PlatformId1 { get; set; }
        /// <summary>
        /// 报警状态，二进制标识 0 正常 1表示报警
        /// 具体定义按照808-2019中表18的规定
        /// </summary>
        public uint Alarm1 { get; set; }
        /// <summary>
        /// 市级监控平台唯一编码，由平台所在地行政区域代码和平台编码组成
        /// 未填写时，全填0，无市级平台应由省级平台全填1  11位
        /// </summary>
        public string PlatformId2 { get; set; }
        /// <summary>
        /// 报警状态，二进制标识 0 正常 1表示报警
        /// 具体定义按照808-2019中表18的规定
        /// </summary>
        public uint Alarm2 { get; set; }
        /// <summary>
        /// 省级监控平台唯一编码，由平台所在地行政区域代码和平台编码组成
        ///  未填写时，全填0  11位
        /// </summary>
        public string PlatformId3 { get; set; }
        /// <summary>
        /// 报警状态，二进制标识 0 正常 1表示报警
        /// 具体定义按照808-2019中表18的规定
        /// </summary>
        public uint Alarm3 { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            writer.WriteStartObject("车辆定位信息_2019");
            var GNSSData = new JT809VehiclePositionProperties_2019();
            GNSSData.Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte();
            writer.WriteString($"[{GNSSData.Encrypt.ToByteValue()}]是否使用国家测绘局批准的地图保密插件进行加密", GNSSData.Encrypt.ToString());
            var gnssDataLength = reader.ReadUInt32();
            writer.WriteNumber($"[{gnssDataLength.ReadNumber()}]车辆定位信息数据长度", gnssDataLength);
            if(config.AnalyzeCallbacks.TryGetValue(0x0200,out JT808AnalyzeCallback jT808AnalyzeCallback))
            {
                jT808AnalyzeCallback(reader.ReadArray((int)gnssDataLength).ToArray(), writer, config);
            }
            else
            {
                GNSSData.GnssData = reader.ReadArray((int)gnssDataLength).ToArray();
                writer.WriteString($"[{GNSSData.GnssData.ToHexString()}]车辆定位信息内容", GNSSData.GnssData.ToHexString());
            }
            var virtualHex = reader.ReadVirtualArray(11);
            GNSSData.PlatformId1 = reader.ReadString(11);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]监控平台唯一编码", GNSSData.PlatformId1);
            GNSSData.Alarm1 = reader.ReadUInt32();
            writer.WriteNumber($"[{GNSSData.Alarm1.ReadNumber()}]报警状态1", GNSSData.Alarm1);
            virtualHex = reader.ReadVirtualArray(11);
            GNSSData.PlatformId2 = reader.ReadString(11);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]市级监控平台唯一编码", GNSSData.PlatformId2);
            GNSSData.Alarm2 = reader.ReadUInt32();
            writer.WriteNumber($"[{GNSSData.Alarm1.ReadNumber()}]报警状态2", GNSSData.Alarm2);
            virtualHex = reader.ReadVirtualArray(11);
            GNSSData.PlatformId3 = reader.ReadString(11);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]省级监控平台唯一编码", GNSSData.PlatformId3);
            GNSSData.Alarm3 = reader.ReadUInt32();
            writer.WriteNumber($"[{GNSSData.Alarm1.ReadNumber()}]报警状态3", GNSSData.Alarm3);
            writer.WriteEndObject();
        }
        public JT809VehiclePositionProperties_2019 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809VehiclePositionProperties_2019 value = new JT809VehiclePositionProperties_2019
            {
                Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte(),
                GnssData = reader.ReadArray((int)reader.ReadUInt32()).ToArray(),
                PlatformId1 = reader.ReadString(11),
                Alarm1 = reader.ReadUInt32(),
                PlatformId2 = reader.ReadString(11),
                Alarm2 = reader.ReadUInt32(),
                PlatformId3 = reader.ReadString(11),
                Alarm3 = reader.ReadUInt32(),
            };
            return value;
        }
        public void Serialize(ref JT809MessagePackWriter writer, JT809VehiclePositionProperties_2019 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.Encrypt);
            writer.Skip(4, out int position);
            writer.WriteArray(value.GnssData);
            writer.WriteUInt32Return((uint)(writer.GetCurrentPosition() - position - 4), position);
            writer.WriteStringPadRight(value.PlatformId1, 11);
            writer.WriteUInt32(value.Alarm1);
            writer.WriteStringPadRight(value.PlatformId2, 11);
            writer.WriteUInt32(value.Alarm2);
            writer.WriteStringPadRight(value.PlatformId3, 11);
            writer.WriteUInt32(value.Alarm3);
        }
    }
}
