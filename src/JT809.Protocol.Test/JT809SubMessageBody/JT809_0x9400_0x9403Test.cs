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
    public class JT809_0x9400_0x9403Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
        [Fact]
        public void Test1()
        {
            JT809_0x9400_0x9403 jT809_0x9400_0x9403 = new JT809_0x9400_0x9403
            {
                  WarnSrc= JT809WarnSrc.车载终端,
                  WarnType= JT809WarnType.疲劳驾驶报警,
                  WarnTime=DateTime.Parse("2018-11-11 10:24:00"),
                  WarnContent= "疲劳驾驶报警",
            };
            var hex = JT809Serializer.Serialize(jT809_0x9400_0x9403).ToHexString();
            Assert.Equal("010002000000005BE792C00000000CC6A3C0CDBCDDCABBB1A8BEAF", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "010002000000005BE792C00000000CC6A3C0CDBCDDCABBB1A8BEAF".ToHexBytes();
            JT809_0x9400_0x9403 jT809_0x9400_0x9403 = JT809Serializer.Deserialize<JT809_0x9400_0x9403>(bytes);
            Assert.Equal(JT809WarnSrc.车载终端, jT809_0x9400_0x9403.WarnSrc);
            Assert.Equal(JT809WarnType.疲劳驾驶报警, jT809_0x9400_0x9403.WarnType);
            Assert.Equal(DateTime.Parse("2018-11-11 10:24:00"), jT809_0x9400_0x9403.WarnTime);
            Assert.Equal("疲劳驾驶报警", jT809_0x9400_0x9403.WarnContent);
            Assert.Equal((uint)12, jT809_0x9400_0x9403.WarnLength);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x9400_0x9403 jT809_0x9400_0x9403 = new JT809_0x9400_0x9403
            {
                SourcePlatformId = "12345678901",
                WarnType = JT809WarnType.疲劳驾驶报警,
                WarnTime = DateTime.Parse("2020-04-26 18:24:00"),
                StartTime = DateTime.Parse("2020-04-26 18:24:00"),
                EndTime = DateTime.Parse("2020-04-26 19:24:00"),
                VehicleNo = "粤A5647",
                VehicleColor =  JT809VehicleColorType.黄色,
                DestinationPlatformId = "12345678901",
                WarnContent = "疲劳驾驶报警",
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0x9400_0x9403).ToHexString();
            Assert.Equal("00000000000002DFDC1C350002000000005EA56140000000005EA56140000000005EA56F50D4C1413536343700000000000000000000000000000200000000000002DFDC1C35000000000000000CC6A3C0CDBCDDCABBB1A8BEAF", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "00000000000002DFDC1C350002000000005EA56140000000005EA56140000000005EA56F50D4C1413536343700000000000000000000000000000200000000000002DFDC1C35000000000000000CC6A3C0CDBCDDCABBB1A8BEAF".ToHexBytes();
            JT809_0x9400_0x9403 jT809_0x9400_0x9403 = JT809_2019_Serializer.Deserialize<JT809_0x9400_0x9403>(bytes);
            Assert.Equal(JT809WarnType.疲劳驾驶报警, jT809_0x9400_0x9403.WarnType);
            Assert.Equal(DateTime.Parse("2020-04-26 18:24:00"), jT809_0x9400_0x9403.WarnTime);
            Assert.Equal(DateTime.Parse("2020-04-26 18:24:00"), jT809_0x9400_0x9403.StartTime);
            Assert.Equal(DateTime.Parse("2020-04-26 19:24:00"), jT809_0x9400_0x9403.EndTime);
            Assert.Equal("疲劳驾驶报警", jT809_0x9400_0x9403.WarnContent);
            Assert.Equal((uint)12, jT809_0x9400_0x9403.WarnLength);
            Assert.Equal("12345678901", jT809_0x9400_0x9403.DestinationPlatformId);
            Assert.Equal("12345678901", jT809_0x9400_0x9403.SourcePlatformId);
        }
    }
}
