using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Metadata;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
#warning   8.3.3.2.5 交换车辆行驶路线信息消息  无指定消息子类型，暂未对接
    /// <summary>
    /// 交换车辆定位信息消息
    /// <para>子业务类型标识:DOWN_EXG_MSG_CAR_LOCATION</para>
    /// <para>2011 描述:上级平台通过该消息不间断地向车辆驶入区域所属的下级平台发送车辆定位信息，直到该车驶离该区域</para>
    /// <para>2019 描述：上级平台在以下四种情况下通过该消息不间断地向车辆进入区域所属的下级平台发送车辆定位信息，直到该车辆离开该区域
    /// 1.车辆跨域时，上级平台通过该消息不间断地向车辆进入区域所属的下级平台发送车辆定位信息，直到该车辆离开该区域
    /// 2.人工指定车辆定位信息交换时，上级平台通过该消息不间断地向指定交换对象下级平台发送车辆定位信息，直到人工指定“交换车辆定位信息”结束
    /// 3.下级平台向上级平台“申请交换指定车辆定位信息”成功后，上级平台通过该消息不间断地向交换对象下级平台发送车辆定位信息，直到“申请交换指定车辆定位信息”结束
    /// 4.应急状态监控车辆时，上级平台向车辆归属下级平台通过该消息不间断地发送车辆定位信息，实现车辆定位信息回传
    /// </para>
    /// </summary>
    public class JT809_0x9200_0x9202:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9200_0x9202>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.交换车辆定位信息消息.ToUInt16Value();

        public override string Description => "交换车辆定位信息消息";
        /// <summary>
        /// 车辆定位信息
        /// </summary>
        public JT809VehiclePositionProperties VehiclePosition { get; set; }

        public JT809VehiclePositionProperties_2019 GNSSData { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x9200_0x9202 value = new JT809_0x9200_0x9202();
            if (config.Version == JT809Version.JTT2011)
            {
                value.VehiclePosition = new JT809VehiclePositionProperties();
                writer.WriteStartObject("车辆定位信息");
                value.VehiclePosition.Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte();
                writer.WriteString($"[{value.VehiclePosition.Encrypt.ToByteValue()}]是否使用国家测绘局批准的地图保密插件进行加密", value.VehiclePosition.Encrypt.ToString());
                value.VehiclePosition.Day = reader.ReadByte();
                writer.WriteNumber($"[{value.VehiclePosition.Day.ReadNumber()}]日", value.VehiclePosition.Day);
                value.VehiclePosition.Month = reader.ReadByte();
                writer.WriteNumber($"[{value.VehiclePosition.Month.ReadNumber()}]月", value.VehiclePosition.Month);
                value.VehiclePosition.Year = reader.ReadUInt16();
                writer.WriteNumber($"[{value.VehiclePosition.Year.ReadNumber()}]年", value.VehiclePosition.Year);
                value.VehiclePosition.Hour = reader.ReadByte();
                writer.WriteNumber($"[{value.VehiclePosition.Hour.ReadNumber()}]时", value.VehiclePosition.Hour);
                value.VehiclePosition.Minute = reader.ReadByte();
                writer.WriteNumber($"[{value.VehiclePosition.Minute.ReadNumber()}]分", value.VehiclePosition.Minute);
                value.VehiclePosition.Second = reader.ReadByte();
                writer.WriteNumber($"[{value.VehiclePosition.Second.ReadNumber()}]秒", value.VehiclePosition.Second);
                value.VehiclePosition.Lon = reader.ReadUInt32();
                writer.WriteNumber($"[{value.VehiclePosition.Lon.ReadNumber()}]经度", value.VehiclePosition.Lon);
                value.VehiclePosition.Lat = reader.ReadUInt32();
                writer.WriteNumber($"[{value.VehiclePosition.Lat.ReadNumber()}]纬度", value.VehiclePosition.Lat);
                value.VehiclePosition.Vec1 = reader.ReadUInt16();
                writer.WriteNumber($"[{value.VehiclePosition.Vec1.ReadNumber()}]速度", value.VehiclePosition.Vec1);
                value.VehiclePosition.Vec2 = reader.ReadUInt16();
                writer.WriteNumber($"[{value.VehiclePosition.Vec2.ReadNumber()}]行驶记录速度", value.VehiclePosition.Vec2);
                value.VehiclePosition.Vec3 = reader.ReadUInt32();
                writer.WriteNumber($"[{value.VehiclePosition.Vec3.ReadNumber()}]车辆当前总里程数", value.VehiclePosition.Vec3);
                value.VehiclePosition.Direction = reader.ReadUInt16();
                writer.WriteNumber($"[{value.VehiclePosition.Direction.ReadNumber()}]方向", value.VehiclePosition.Direction);
                value.VehiclePosition.Altitude = reader.ReadUInt16();
                writer.WriteNumber($"[{value.VehiclePosition.Altitude.ReadNumber()}]海拔高度", value.VehiclePosition.Altitude);
                value.VehiclePosition.State = reader.ReadUInt32();
                writer.WriteNumber($"[{value.VehiclePosition.State.ReadNumber()}]车辆状态", value.VehiclePosition.State);
                value.VehiclePosition.Alarm = reader.ReadUInt32();
                writer.WriteNumber($"[{value.VehiclePosition.Alarm.ReadNumber()}]报警状态", value.VehiclePosition.Alarm);
                writer.WriteEndObject();
            }
            else
            {
                value.GNSSData = new JT809VehiclePositionProperties_2019();
                writer.WriteStartObject("车辆定位信息");
                value.GNSSData.Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte();
                writer.WriteString($"[{value.GNSSData.Encrypt.ToByteValue()}]是否使用国测局批准的地图保密插件进行加密", value.GNSSData.Encrypt.ToString());
                value.GNSSData.DataLength = reader.ReadUInt32();
                writer.WriteNumber($"[{value.GNSSData.DataLength.ReadNumber()}]车辆定位信息数据长度", value.GNSSData.DataLength);
                value.GNSSData.GnssData = reader.ReadArray((int)value.GNSSData.DataLength).ToArray();
                writer.WriteString($"[{value.GNSSData.GnssData.ToHexString()}]车辆定位信息内容",value.GNSSData.GnssData.ToHexString());
                var virtualHex = reader.ReadVirtualArray(11);
                value.GNSSData.PlatformId1 = reader.ReadBigNumber(11);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]监控平台唯一编码", value.GNSSData.PlatformId1);
                value.GNSSData.Alarm1 = reader.ReadUInt32();
                writer.WriteNumber($"[{value.GNSSData.Alarm1.ReadNumber()}]报警状态", value.GNSSData.Alarm1);
                virtualHex = reader.ReadVirtualArray(11);
                value.GNSSData.PlatformId2 = reader.ReadBigNumber(11);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]市级监控平台唯一编码", value.GNSSData.PlatformId2);
                value.GNSSData.Alarm2 = reader.ReadUInt32();
                writer.WriteNumber($"[{value.GNSSData.Alarm2.ReadNumber()}]报警状态", value.GNSSData.Alarm2);
                virtualHex = reader.ReadVirtualArray(11);
                value.GNSSData.PlatformId3 = reader.ReadBigNumber(11);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]省级监控平台唯一编码", value.GNSSData.PlatformId3);
                value.GNSSData.Alarm3 = reader.ReadUInt32();
                writer.WriteNumber($"[{value.GNSSData.Alarm3.ReadNumber()}]报警状态", value.GNSSData.Alarm3);
                writer.WriteEndObject();
            }
        }

        public JT809_0x9200_0x9202 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9200_0x9202 value = new JT809_0x9200_0x9202();
            if (config.Version == JT809Version.JTT2011)
            {
                value.VehiclePosition = new JT809VehiclePositionProperties();
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
            }
            else
            {
                value.GNSSData = new JT809VehiclePositionProperties_2019();
                value.GNSSData.Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte();
                value.GNSSData.DataLength = reader.ReadUInt32();
                value.GNSSData.GnssData = reader.ReadArray((int)value.GNSSData.DataLength).ToArray();
                value.GNSSData.PlatformId1 = reader.ReadBigNumber(11);
                value.GNSSData.Alarm1 = reader.ReadUInt32();
                value.GNSSData.PlatformId2 = reader.ReadBigNumber(11);
                value.GNSSData.Alarm2 = reader.ReadUInt32();
                value.GNSSData.PlatformId3 = reader.ReadBigNumber(11);
                value.GNSSData.Alarm3 = reader.ReadUInt32();
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200_0x9202 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2011)
            {
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
            }
            else {
                writer.WriteByte((byte)value.GNSSData.Encrypt);
                writer.Skip(4, out int position);
                writer.WriteArray(value.GNSSData.GnssData);
                writer.WriteBigNumber(value.GNSSData.PlatformId1,11);
                writer.WriteUInt32(value.GNSSData.Alarm1);
                writer.WriteBigNumber(value.GNSSData.PlatformId2,11);
                writer.WriteUInt32(value.GNSSData.Alarm2);
                writer.WriteBigNumber(value.GNSSData.PlatformId3,11);
                writer.WriteUInt32(value.GNSSData.Alarm3);
                writer.WriteUInt32Return((uint)(writer.GetCurrentPosition() - position-4), position);
            }
        }
    }
}
