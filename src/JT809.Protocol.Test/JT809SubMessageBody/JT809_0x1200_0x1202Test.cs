using System;
using System.Collections.Generic;
using Xunit;
using JT809.Protocol.Extensions;
using JT809.Protocol.SubMessageBody;
using JT809.Protocol.Internal;
using JT809.Protocol.Enums;
using JT808.Protocol;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessageBody;
using JT809.Protocol.Metadata;
using System.Text.Json;
using JT808.Protocol.MessagePack;

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class DefaultGlobal808_2019Config : GlobalConfigBase
    {
        public override string ConfigId { get; protected set; }
        public DefaultGlobal808_2019Config(string configId = "jt808_2019")
        {
            ConfigId = configId;

        }
    }
    public class JT809_0x1200_0x1202Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();

        private JT809Serializer JT809_2019_Serializer;

        private JT808Serializer JT808Serializer_2019;

        private IJT808Config jT808Config;
        public JT809_0x1200_0x1202Test()
        {
            jT808Config = new DefaultGlobal808_2019Config();
            JT808Serializer_2019 = new JT808Serializer(jT808Config);
            var config = new DefaultGlobalConfig() { Version = JT809Version.JTT2019 };
            config.AnalyzeCallbacks.Add(0x0200, new JT808AnalyzeCallback(Test_2019_5_Callback));
            JT809_2019_Serializer = new JT809Serializer(config);
        }

        [Fact]
        public void Test1()
        {
            JT809_0x1200_0x1202 jT809_0X1200_0X1202 = new JT809_0x1200_0x1202();
            jT809_0X1200_0X1202.VehiclePosition = new JT809VehiclePositionProperties
            {
                Day = 19,
                Month = 7,
                Year = 2012,
                Hour = 15,
                Minute = 15,
                Second = 15,
                Lon = 133123456,
                Lat = 24123456,
                Vec1 = 50,
                Vec2 = 51,
                Vec3 = 150,
                Direction = 45,
                Altitude = 45,
                State = 3,
                Alarm = 257,
            };
            var hex = JT809Serializer.Serialize(jT809_0X1200_0X1202).ToHexString();
            //"00 13 07 07 DC 0F 0F 0F 07 EF 4D 80 01 70 18 40 00 32 00 33 00 00 00 96 00 2D 00 2D 00 00 00 03 00 00 01 01"
            Assert.Equal("00130707DC0F0F0F07EF4D80017018400032003300000096002D002D0000000300000101", hex);
        }

        [Fact]
        public void Test2()
        {
            byte[] bytes = "00 13 07 07 DC 0F 0F 0F 07 EF 4D 80 01 70 18 40 00 32 00 33 00 00 00 96 00 2D 00 2D 00 00 00 03 00 00 01 01".ToHexBytes();
            JT809_0x1200_0x1202 jT809_0X1200_0X1202 = JT809Serializer.Deserialize<JT809_0x1200_0x1202>(bytes);
            var vehiclePosition = jT809_0X1200_0X1202.VehiclePosition;
            Assert.Equal(19, vehiclePosition.Day);
            Assert.Equal(7, vehiclePosition.Month);
            Assert.Equal(2012, vehiclePosition.Year);
            Assert.Equal(15, vehiclePosition.Hour);
            Assert.Equal(15, vehiclePosition.Minute);
            Assert.Equal(15, vehiclePosition.Second);
            Assert.Equal((uint)133123456, vehiclePosition.Lon);
            Assert.Equal((uint)24123456, vehiclePosition.Lat);
            Assert.Equal(50, vehiclePosition.Vec1);
            Assert.Equal(51, vehiclePosition.Vec2);
            Assert.Equal((ushort)45, vehiclePosition.Direction);
            Assert.Equal((ushort)45, vehiclePosition.Altitude);
            Assert.Equal((uint)3, vehiclePosition.State);
            Assert.Equal((uint)257, vehiclePosition.Alarm);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x1200_0x1202 jT809_0X1200_0X1202 = new JT809_0x1200_0x1202();
            jT809_0X1200_0X1202.VehiclePosition_2019 = new JT809VehiclePositionProperties_2019
            {
                Encrypt = JT809_VehiclePositionEncrypt.已加密,
                PlatformId1 = "11111111111",
                Alarm1 = 1,
                PlatformId2 = "22222222222",
                Alarm2 = 2,
                PlatformId3 = "33333333333",
                Alarm3 = 3,
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0X1200_0X1202).ToHexString();
            Assert.Equal("0100000000313131313131313131313100000001323232323232323232323200000002333333333333333333333300000003", hex);

        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "0100000000313131313131313131313100000001323232323232323232323200000002333333333333333333333300000003".ToHexBytes();
            JT809_0x1200_0x1202 jT809_0X1200_0X1202 = JT809_2019_Serializer.Deserialize<JT809_0x1200_0x1202>(bytes);
            var gnssData = jT809_0X1200_0X1202.VehiclePosition_2019;
            Assert.Equal(JT809_VehiclePositionEncrypt.已加密, gnssData.Encrypt);
            Assert.Equal("11111111111", gnssData.PlatformId1);
            Assert.Equal(1u, gnssData.Alarm1);
            Assert.Equal("22222222222", gnssData.PlatformId2);
            Assert.Equal(2u, gnssData.Alarm2);
            Assert.Equal("33333333333", gnssData.PlatformId3);
            Assert.Equal(3u, gnssData.Alarm3);
        }

        /// <summary>
        /// 此处结合808协议包解析
        /// </summary>
        [Fact]
        public void Test_2019_3()
        {
            JT808_0x0200 jT808UploadLocationRequest = new JT808_0x0200
            {
                AlarmFlag = 1,
                Altitude = 40,
                GPSTime = DateTime.Parse("2018-07-15 10:10:10"),
                Lat = 12222222,
                Lng = 132444444,
                Speed = 60,
                Direction = 0,
                StatusFlag = 2,
                BasicLocationAttachData = new Dictionary<byte, JT808_0x0200_BodyBase>()
            };
            jT808UploadLocationRequest.BasicLocationAttachData.Add(JT808Constants.JT808_0x0200_0x01, new JT808_0x0200_0x01
            {
                Mileage = 100
            });
            jT808UploadLocationRequest.BasicLocationAttachData.Add(JT808Constants.JT808_0x0200_0x02, new JT808_0x0200_0x02
            {
                Oil = 55
            });
            var jt808_0x0200Hex = JT808Serializer_2019.Serialize(jT808UploadLocationRequest, JT808.Protocol.Enums.JT808Version.JTT2019);

            JT809_0x1200_0x1202 jT809_0X1200_0X1202 = new JT809_0x1200_0x1202();
            jT809_0X1200_0X1202.VehiclePosition_2019 = new JT809VehiclePositionProperties_2019
            {
                Encrypt = JT809_VehiclePositionEncrypt.已加密,
                GnssData = jt808_0x0200Hex,
                PlatformId1 = "11111111111",
                Alarm1 = 1,
                PlatformId2 = "22222222222",
                Alarm2 = 2,
                PlatformId3 = "33333333333",
                Alarm3 = 3,
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0X1200_0X1202).ToHexString();
            Assert.Equal("0100000026000000010000000200BA7F0E07E4F11C0028003C000018071510101001040000006402020037313131313131313131313100000001323232323232323232323200000002333333333333333333333300000003", hex);
        }

        [Fact]
        public void Test_2019_4()
        {
            var bytes = "0100000026000000010000000200BA7F0E07E4F11C0028003C000018071510101001040000006402020037313131313131313131313100000001323232323232323232323200000002333333333333333333333300000003".ToHexBytes();
            JT809_0x1200_0x1202 jT809_0X1200_0X1202 = JT809_2019_Serializer.Deserialize<JT809_0x1200_0x1202>(bytes);
            var gnssData = jT809_0X1200_0X1202.VehiclePosition_2019;
            Assert.Equal(JT809_VehiclePositionEncrypt.已加密, gnssData.Encrypt);
            Assert.Equal("11111111111", gnssData.PlatformId1);
            Assert.Equal(1u, gnssData.Alarm1);
            Assert.Equal("22222222222", gnssData.PlatformId2);
            Assert.Equal(2u, gnssData.Alarm2);
            Assert.Equal("33333333333", gnssData.PlatformId3);
            Assert.Equal(3u, gnssData.Alarm3);

            var jt808_0x0200Hex = gnssData.GnssData;
            var jt808_0x0200 = JT808Serializer_2019.Deserialize<JT808_0x0200>(jt808_0x0200Hex, JT808.Protocol.Enums.JT808Version.JTT2019);
            Assert.Equal((uint)1, jt808_0x0200.AlarmFlag);
            Assert.Equal(DateTime.Parse("2018-07-15 10:10:10"), jt808_0x0200.GPSTime);
            Assert.Equal(12222222, jt808_0x0200.Lat);
            Assert.Equal(132444444, jt808_0x0200.Lng);
            Assert.Equal(60, jt808_0x0200.Speed);
            Assert.Equal((uint)2, jt808_0x0200.StatusFlag);
            Assert.Equal(100, ((JT808_0x0200_0x01)jt808_0x0200.BasicLocationAttachData[JT808Constants.JT808_0x0200_0x01]).Mileage);
            Assert.Equal(55, ((JT808_0x0200_0x02)jt808_0x0200.BasicLocationAttachData[JT808Constants.JT808_0x0200_0x02]).Oil);

        }

        [Fact]
        public void Test_2019_5()
        {
            var bytes = "0100000026000000010000000200BA7F0E07E4F11C0028003C000018071510101001040000006402020037313131313131313131313100000001323232323232323232323200000002333333333333333333333300000003".ToHexBytes();
            string json = JT809_2019_Serializer.Analyze<JT809_0x1200_0x1202>(bytes);
        }

        public void Test_2019_5_Callback(byte[] bytes, Utf8JsonWriter writer, IJT809Config jT809Config)
        {
            JT808MessagePackReader jT808MessagePackReader = new JT808MessagePackReader(bytes);
            JT808.Protocol.Extensions.JT808AnalyzeExtensions.Analyze(JT808.Protocol.JT808ConfigExtensions.GetMessagePackFormatter<JT808_0x0200>(jT808Config),
                ref jT808MessagePackReader, writer, jT808Config);
        }
    }
}
