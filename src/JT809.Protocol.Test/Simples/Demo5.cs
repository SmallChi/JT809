using Microsoft.Extensions.DependencyInjection;
using System;
using JT809.Protocol.Test.JT1078;
using JT809.Protocol.Extensions;
using Xunit;
using JT809.Protocol.Enums;
using JT809.Protocol.Interfaces;
using JT808.Protocol.Interfaces;
using JT808.Protocol;
using JT808.Protocol.MessageBody;
using System.Collections.Generic;
using JT809.Protocol.SubMessageBody;
using JT808.Protocol.Metadata;

namespace JT809.Protocol.Test.Simples
{
    /// <summary>
    /// 1.此处结合808协议包解析 808中的定位信息
    /// 2.此处结合808协议包解析 808中的路线信息
    /// </summary>
    public class Demo5
    {
        IServiceProvider ServiceProvider;
        JT809Serializer JT809_2019_Serializer;
        JT809Serializer JT809_Serializer;
        JT808Serializer JT808_2019_Serializer;

        public Demo5()
        {
            IServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddJT808Configure(new JT808_2019_Config());
            serviceDescriptors.AddJT809Configure(new JT809_2011_Config())
                              .AddJT1078Configure();
            serviceDescriptors.AddJT809Configure(new JT809_2019_Config())
                                  .AddJT1078Configure();
            ServiceProvider = serviceDescriptors.BuildServiceProvider();
            var jT809_2011_Config = ServiceProvider.GetRequiredService<JT809_2011_Config>();
            var jT809_2019_Config = ServiceProvider.GetRequiredService<JT809_2019_Config>();
            var jT808_Config = ServiceProvider.GetRequiredService<JT808_2019_Config>();

            JT809_2019_Serializer = jT809_2019_Config.GetSerializer();
            JT809_Serializer = jT809_2011_Config.GetSerializer();
            JT808_2019_Serializer = jT808_Config.GetSerializer();
        }
        [Fact]
        public void Test_2019_1()
        {
            JT808_0x8606 jT808_0X8606 = new JT808_0x8606
            {
                RouteId = 9999,
                RouteProperty = 1268,
                StartTime = DateTime.Parse("2018-11-20 00:00:12"),
                EndTime = DateTime.Parse("2018-11-21 00:00:12"),
                InflectionPointItems = new List<JT808InflectionPointProperty>()
            };
            jT808_0X8606.InflectionPointItems.Add(new JT808InflectionPointProperty()
            {
                InflectionPointId = 1000,
                InflectionPointLat = 123456789,
                InflectionPointLng = 123456788,
                SectionDrivingUnderThreshold = 123,
                SectionHighestSpeed = 69,
                SectionId = 1287,
                SectionLongDrivingThreshold = 50,
                SectionOverspeedDuration = 23,
                SectionProperty = 89,
                SectionWidth = 56
            });
            jT808_0X8606.InflectionPointItems.Add(new JT808InflectionPointProperty()
            {
                InflectionPointId = 1001,
                InflectionPointLat = 123456780,
                InflectionPointLng = 123456781,
                SectionDrivingUnderThreshold = 124,
                SectionHighestSpeed = 42,
                SectionId = 12007,
                SectionLongDrivingThreshold = 58,
                SectionOverspeedDuration = 26,
                SectionProperty = 50,
                SectionWidth = 75
            });
            var jt808_hex = JT808_2019_Serializer.Serialize(jT808_0X8606);

            JT809_0x1600_0x1602 jT809_0x1600_0x1602 = new JT809_0x1600_0x1602
            {
                DRVLine = jt808_hex
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0x1600_0x1602).ToHexString();
            Assert.Equal("0000270F04F40002000003E800000507075BCD15075BCD1438590032007B000003E900002EE7075BCD0C075BCD0D4B32002A1A", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "0000270F04F40002000003E800000507075BCD15075BCD1438590032007B000003E900002EE7075BCD0C075BCD0D4B32002A1A".ToHexBytes();
            JT809_0x1600_0x1602 jT809_0x1600_0x1602 = JT809_2019_Serializer.Deserialize<JT809_0x1600_0x1602>(bytes);

            JT808_0x8606 jT808_0X8606 = JT808_2019_Serializer.Deserialize<JT808_0x8606>(bytes);

            Assert.Equal((uint)9999, jT808_0X8606.RouteId);
            Assert.Equal((uint)1268, jT808_0X8606.RouteProperty);
            //Assert.Equal(DateTime.Parse("2018-11-20 00:00:12"), jT808_0X8606.StartTime);
            //Assert.Equal(DateTime.Parse("2018-11-21 00:00:12"), jT808_0X8606.EndTime);
            Assert.Null(jT808_0X8606.StartTime);
            Assert.Null(jT808_0X8606.EndTime);

            Assert.Equal(2, jT808_0X8606.InflectionPointItems.Count);

            Assert.Equal((uint)1000, jT808_0X8606.InflectionPointItems[0].InflectionPointId);
            Assert.Equal((uint)123456789, jT808_0X8606.InflectionPointItems[0].InflectionPointLat);
            Assert.Equal((uint)123456788, jT808_0X8606.InflectionPointItems[0].InflectionPointLng);

            Assert.Equal((ushort)123, jT808_0X8606.InflectionPointItems[0].SectionDrivingUnderThreshold);
            //Assert.Equal((ushort)69, jT808_0X8606.InflectionPointItems[0].SectionHighestSpeed);
            Assert.Null(jT808_0X8606.InflectionPointItems[0].SectionHighestSpeed);
            Assert.Equal((uint)1287, jT808_0X8606.InflectionPointItems[0].SectionId);
            Assert.Equal((ushort)50, jT808_0X8606.InflectionPointItems[0].SectionLongDrivingThreshold);
            //Assert.Equal((byte)23, jT808_0X8606.InflectionPointItems[0].SectionOverspeedDuration);
            Assert.Equal(89, jT808_0X8606.InflectionPointItems[0].SectionProperty);
            Assert.Equal(56, jT808_0X8606.InflectionPointItems[0].SectionWidth);

            Assert.Equal((uint)1001, jT808_0X8606.InflectionPointItems[1].InflectionPointId);
            Assert.Equal((uint)123456780, jT808_0X8606.InflectionPointItems[1].InflectionPointLat);
            Assert.Equal((uint)123456781, jT808_0X8606.InflectionPointItems[1].InflectionPointLng);
            //Assert.Equal((ushort)124, jT808_0X8606.InflectionPointItems[1].SectionDrivingUnderThreshold);
            Assert.Null(jT808_0X8606.InflectionPointItems[1].SectionDrivingUnderThreshold);
            Assert.Equal((ushort)42, jT808_0X8606.InflectionPointItems[1].SectionHighestSpeed);
            Assert.Equal((uint)12007, jT808_0X8606.InflectionPointItems[1].SectionId);
            //Assert.Equal((ushort)58, jT808_0X8606.InflectionPointItems[1].SectionLongDrivingThreshold);
            Assert.Null(jT808_0X8606.InflectionPointItems[1].SectionLongDrivingThreshold);

            Assert.Equal((byte)26, jT808_0X8606.InflectionPointItems[1].SectionOverspeedDuration);
            Assert.Equal(50, jT808_0X8606.InflectionPointItems[1].SectionProperty);
            Assert.Equal(75, jT808_0X8606.InflectionPointItems[1].SectionWidth);
        }


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
            var jt808_0x0200Hex = JT808_2019_Serializer.Serialize(jT808UploadLocationRequest, JT808.Protocol.Enums.JT808Version.JTT2019);

            JT809_0x1200_0x1202 jT809_0X1200_0X1202 = new JT809_0x1200_0x1202();
            jT809_0X1200_0X1202.VehiclePosition_2019 = new Metadata.JT809VehiclePositionProperties_2019
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
            var GNSSData = jT809_0X1200_0X1202.VehiclePosition_2019;
            Assert.Equal(JT809_VehiclePositionEncrypt.已加密, GNSSData.Encrypt);
            Assert.Equal("11111111111", GNSSData.PlatformId1);
            Assert.Equal(1u, GNSSData.Alarm1);
            Assert.Equal("22222222222", GNSSData.PlatformId2);
            Assert.Equal(2u, GNSSData.Alarm2);
            Assert.Equal("33333333333", GNSSData.PlatformId3);
            Assert.Equal(3u, GNSSData.Alarm3);

            var jt808_0x0200Hex = GNSSData.GnssData;
            var jt808_0x0200 = JT808_2019_Serializer.Deserialize<JT808_0x0200>(jt808_0x0200Hex, JT808.Protocol.Enums.JT808Version.JTT2019);
            Assert.Equal((uint)1, jt808_0x0200.AlarmFlag);
            Assert.Equal(DateTime.Parse("2018-07-15 10:10:10"), jt808_0x0200.GPSTime);
            Assert.Equal(12222222, jt808_0x0200.Lat);
            Assert.Equal(132444444, jt808_0x0200.Lng);
            Assert.Equal(60, jt808_0x0200.Speed);
            Assert.Equal((uint)2, jt808_0x0200.StatusFlag);
            Assert.Equal(100, ((JT808_0x0200_0x01)jt808_0x0200.BasicLocationAttachData[JT808Constants.JT808_0x0200_0x01]).Mileage);
            Assert.Equal(55, ((JT808_0x0200_0x02)jt808_0x0200.BasicLocationAttachData[JT808Constants.JT808_0x0200_0x02]).Oil);

        }

        public class JT809_2011_Config : JT809GlobalConfigBase
        {
            public override string ConfigId => "JT809_2011";
        }

        public class JT809_2019_Config : JT809GlobalConfigBase
        {
            public override string ConfigId => "JT809_2019";

            public JT809_2019_Config()
            {
                Version = JT809Version.JTT2019;
            }
        }

        public class JT808_2019_Config : GlobalConfigBase
        {
            public override string ConfigId { get; protected set; }
            public JT808_2019_Config(string configId = "jt808_2019")
            {
                ConfigId = configId;
            }
        }
    }
}
