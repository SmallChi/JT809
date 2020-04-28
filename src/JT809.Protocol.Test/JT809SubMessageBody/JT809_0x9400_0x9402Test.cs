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

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x9400_0x9402Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
        [Fact]
        public void Test1()
        {
            JT809_0x9400_0x9402 jT809_0x9400_0x9402 = new JT809_0x9400_0x9402
            {
                  WarnSrc= JT809WarnSrc.车载终端,
                  WarnType= JT809WarnType.劫警,
                  WarnTime=DateTime.Parse("2018-11-11 10:24:00"),
                  WarnContent= "劫警",
            };
            var hex = JT809Serializer.Serialize(jT809_0x9400_0x9402).ToHexString();
            Assert.Equal("01000A000000005BE792C000000004BDD9BEAF", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "01000A000000005BE792C000000004BDD9BEAF".ToHexBytes();
            JT809_0x9400_0x9402 jT809_0x9400_0x9402 = JT809Serializer.Deserialize<JT809_0x9400_0x9402>(bytes);
            Assert.Equal(JT809WarnSrc.车载终端, jT809_0x9400_0x9402.WarnSrc);
            Assert.Equal(JT809WarnType.劫警, jT809_0x9400_0x9402.WarnType);
            Assert.Equal(DateTime.Parse("2018-11-11 10:24:00"), jT809_0x9400_0x9402.WarnTime);
            Assert.Equal("劫警", jT809_0x9400_0x9402.WarnContent);
            Assert.Equal((uint)4, jT809_0x9400_0x9402.WarnLength);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x9400_0x9402 jT809_0x9400_0x9402 = new JT809_0x9400_0x9402
            {
                SourcePlatformId = "12345678901",
                WarnType = JT809WarnType.劫警,
                WarnTime = DateTime.Parse("2020-04-26 18:23:00"),
                StartTime = DateTime.Parse("2020-04-26 18:23:00"),
                EndTime = DateTime.Parse("2020-04-26 19:23:00"),
                VehicleNo= "粤A12345",
                VehicleColor= JT809VehicleColorType.蓝色,
                DestinationPlatformId = "12345678901",
                DRVLineId=22,
                WarnContent = "劫警",
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0x9400_0x9402).ToHexString();
            Assert.Equal("00000000000002DFDC1C35000A000000005EA56104000000005EA56104000000005EA56F14D4C1413132333435000000000000000000000000000100000000000002DFDC1C350000001600000004BDD9BEAF", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "00000000000002DFDC1C35000A000000005EA56104000000005EA56104000000005EA56F14D4C1413132333435000000000000000000000000000100000000000002DFDC1C350000001600000004BDD9BEAF".ToHexBytes();
            JT809_0x9400_0x9402 jT809_0x9400_0x9402 = JT809_2019_Serializer.Deserialize<JT809_0x9400_0x9402>(bytes);
            Assert.Equal(JT809WarnType.劫警, jT809_0x9400_0x9402.WarnType);
            Assert.Equal(DateTime.Parse("2020-04-26 18:23:00"), jT809_0x9400_0x9402.WarnTime);
            Assert.Equal(DateTime.Parse("2020-04-26 18:23:00"), jT809_0x9400_0x9402.StartTime);
            Assert.Equal(DateTime.Parse("2020-04-26 19:23:00"), jT809_0x9400_0x9402.EndTime);
            Assert.Equal(DateTime.Parse("2020-04-26 19:23:00"), jT809_0x9400_0x9402.EndTime);
            Assert.Equal("粤A12345", jT809_0x9400_0x9402.VehicleNo);
            Assert.Equal(JT809VehicleColorType.蓝色, jT809_0x9400_0x9402.VehicleColor);
            Assert.Equal("12345678901", jT809_0x9400_0x9402.DestinationPlatformId);
            Assert.Equal("12345678901", jT809_0x9400_0x9402.SourcePlatformId);
            Assert.Equal(22u, jT809_0x9400_0x9402.DRVLineId);
            Assert.Equal(4u, jT809_0x9400_0x9402.WarnLength);
        }
    }
}
