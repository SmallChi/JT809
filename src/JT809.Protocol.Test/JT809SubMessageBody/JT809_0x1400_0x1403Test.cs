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
    public class JT809_0x1400_0x1403Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
        [Fact]
        public void Test1()
        {
            JT809_0x1400_0x1403 jT809_0x1400_0x1403 = new JT809_0x1400_0x1403
            {
                 Result= JT809_0x1403_Result.将来处理,
                 InfoID = 3344,
            };
            var hex = JT809Serializer.Serialize(jT809_0x1400_0x1403).ToHexString();
            // "00 00 0D 10 03"
            Assert.Equal("00000D1003", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00 00 0D 10 03".ToHexBytes();
            JT809_0x1400_0x1403 jT809_0x1400_0x1403 = JT809Serializer.Deserialize<JT809_0x1400_0x1403>(bytes);
            Assert.Equal(JT809_0x1403_Result.将来处理, jT809_0x1400_0x1403.Result);
            Assert.Equal((uint)3344, jT809_0x1400_0x1403.InfoID);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x1400_0x1403 jT809_0x1400_0x1403 = new JT809_0x1400_0x1403
            {
                SourcePlatformId = "12345678900",
                WarnType = JT809WarnType.偏离路线报警,
                WarnTime = DateTime.Parse("2020-04-23"),
                StartTime = DateTime.Parse("2020-04-23"),
                EndTime = DateTime.Parse("2020-04-24"),
                VehicleNo = "粤A11111",
                VehicleColor = JT809VehicleColorType.蓝色,
                DestinationPlatformId = "12345678900",
                InfoContent = "gfdf454553",
                DRVLineId=55
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0x1400_0x1403).ToHexString();
            Assert.Equal("00000000000002DFDC1C34000B000000005EA06A00000000005EA06A00000000005EA1BB80D4C1413131313131000000000000000000000000000100000000000002DFDC1C34000000370000000A67666466343534353533", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "00000000000002DFDC1C34000B000000005EA06A00000000005EA06A00000000005EA1BB80D4C1413131313131000000000000000000000000000100000000000002DFDC1C34000000370000000A67666466343534353533".ToHexBytes();
            JT809_0x1400_0x1403 jT809_0x1400_0x1403 = JT809_2019_Serializer.Deserialize<JT809_0x1400_0x1403>(bytes);
            Assert.Equal("12345678900", jT809_0x1400_0x1403.SourcePlatformId);
            Assert.Equal("gfdf454553", jT809_0x1400_0x1403.InfoContent);
            Assert.Equal(JT809WarnType.偏离路线报警, jT809_0x1400_0x1403.WarnType);
            Assert.Equal((uint)10, jT809_0x1400_0x1403.InfoLength);
            Assert.Equal(DateTime.Parse("2020-04-23"), jT809_0x1400_0x1403.WarnTime);
            Assert.Equal(DateTime.Parse("2020-04-23"), jT809_0x1400_0x1403.StartTime);
            Assert.Equal(DateTime.Parse("2020-04-24"), jT809_0x1400_0x1403.EndTime);
            Assert.Equal("粤A11111", jT809_0x1400_0x1403.VehicleNo);
            Assert.Equal(JT809VehicleColorType.蓝色, jT809_0x1400_0x1403.VehicleColor);
            Assert.Equal("12345678900", jT809_0x1400_0x1403.DestinationPlatformId);
            Assert.Equal(55u, jT809_0x1400_0x1403.DRVLineId);
        }
    }
}
