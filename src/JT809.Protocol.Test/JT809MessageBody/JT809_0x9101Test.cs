using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public class JT809_0x9101Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809_0x9101 jT809_0X9101 = new JT809_0x9101();
            jT809_0X9101.DynamicInfoTotal = 10000;
            jT809_0X9101.StartTime = DateTime.Parse("2018-09-21 15:11:02");
            jT809_0X9101.EndTime = DateTime.Parse("2018-09-21 20:11:02");
            var hex = JT809Serializer.Serialize(jT809_0X9101).ToHexString();
            Assert.Equal("00002710000000005BA49986000000005BA4DFD6",hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00 00 27 10 00 00 00 00 5B A4 99 86 00 00 00 00 5B A4 DF D6".ToHexBytes();
            JT809_0x9101 jT809_0X9101 = JT809Serializer.Deserialize<JT809_0x9101>(bytes);
            Assert.Equal((uint)10000, jT809_0X9101.DynamicInfoTotal);
            Assert.Equal(DateTime.Parse("2018-09-21 15:11:02"), jT809_0X9101.StartTime);
            Assert.Equal(DateTime.Parse("2018-09-21 20:11:02"), jT809_0X9101.EndTime);
        }
    }
}
