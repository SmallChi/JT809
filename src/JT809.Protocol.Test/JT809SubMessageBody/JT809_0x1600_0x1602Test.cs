using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using JT809.Protocol.SubMessageBody;
using JT809.Protocol.Enums;
using JT809.Protocol.Internal;
using JT808.Protocol.MessageBody;
using JT808.Protocol.Interfaces;
using JT808.Protocol;
using JT808.Protocol.Metadata;

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x1600_0x1602Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
        private JT808Serializer JT808Serializer_2019;

        public JT809_0x1600_0x1602Test()
        {
            IJT808Config jT808Config = new DefaultGlobal808_2019Config();
            JT808Serializer_2019 = new JT808Serializer(jT808Config);
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
            var jt808_hex = JT808Serializer_2019.Serialize(jT808_0X8606);

            JT809_0x1600_0x1602 jT809_0x1600_0x1602 = new JT809_0x1600_0x1602
            {
                DRVLine= jt808_hex
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0x1600_0x1602).ToHexString();
            Assert.Equal("0000270F04F40002000003E800000507075BCD15075BCD1438590032007B000003E900002EE7075BCD0C075BCD0D4B32002A1A", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "0000270F04F40002000003E800000507075BCD15075BCD1438590032007B000003E900002EE7075BCD0C075BCD0D4B32002A1A".ToHexBytes();
            JT809_0x1600_0x1602 jT809_0x1600_0x1602 = JT809_2019_Serializer.Deserialize<JT809_0x1600_0x1602>(bytes);

            JT808_0x8606 jT808_0X8606 = JT808Serializer_2019.Deserialize<JT808_0x8606>(bytes);

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
    }
}
