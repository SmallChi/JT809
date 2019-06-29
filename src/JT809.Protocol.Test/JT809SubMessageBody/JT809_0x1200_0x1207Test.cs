using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using JT809.Protocol.SubMessageBody;

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x1200_0x1207Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809_0x1200_0x1207 jT809_0X1200_0X1201 = new JT809_0x1200_0x1207
            {
                StartTime = DateTime.Parse("2018-09-24 14:14:14"),
                EndTime = DateTime.Parse("2018-09-24 23:23:23")
            };
            var hex = JT809Serializer.Serialize(jT809_0X1200_0X1201).ToHexString();
            //"00 00 00 00 5B A8 80 B6 00 00 00 00 5B A9 01 6B"
            Assert.Equal("000000005BA880B6000000005BA9016B",hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00 00 00 00 5B A8 80 B6 00 00 00 00 5B A9 01 6B".ToHexBytes();
            JT809_0x1200_0x1207 jT809_0X1200_0X1201 = JT809Serializer.Deserialize<JT809_0x1200_0x1207>(bytes);
            Assert.Equal(DateTime.Parse("2018-09-24 14:14:14"), jT809_0X1200_0X1201.StartTime);
            Assert.Equal(DateTime.Parse("2018-09-24 23:23:23"), jT809_0X1200_0X1201.EndTime);
        }
    }
}
