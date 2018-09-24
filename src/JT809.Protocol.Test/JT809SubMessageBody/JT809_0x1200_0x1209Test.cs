using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809MessageBody;
using JT809.Protocol.JT809Exceptions;
using JT809.Protocol.JT809SubMessageBody;

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x1200_0x1209Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x1200_0x1209 jT809_0X1200_0X1209 = new JT809_0x1200_0x1209
            {
                StartTime = DateTime.Parse("2018-09-24 14:14:14"),
                EndTime = DateTime.Parse("2018-09-24 23:23:23")
            };
            var hex = JT809Serializer.Serialize(jT809_0X1200_0X1209).ToHexString();
            //"00 00 00 00 5B A8 80 B6 00 00 00 00 5B A9 01 6B"
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00 00 00 00 5B A8 80 B6 00 00 00 00 5B A9 01 6B".ToHexBytes();
            JT809_0x1200_0x1209 jT809_0X1200_0X1209 = JT809Serializer.Deserialize<JT809_0x1200_0x1209>(bytes);
            Assert.Equal(DateTime.Parse("2018-09-24 14:14:14"), jT809_0X1200_0X1209.StartTime);
            Assert.Equal(DateTime.Parse("2018-09-24 23:23:23"), jT809_0X1200_0X1209.EndTime);
        }
    }
}
