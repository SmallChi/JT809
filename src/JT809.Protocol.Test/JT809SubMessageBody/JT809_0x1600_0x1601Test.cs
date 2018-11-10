using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809MessageBody;
using JT809.Protocol.JT809Exceptions;
using JT809.Protocol.JT809SubMessageBody;
using JT809.Protocol.JT809Enums;

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x1600_0x1601Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x1600_0x1601 jT809_0x1600_0x1601 = new JT809_0x1600_0x1601
            {
                 CarInfo = "smallchi",
            };
            var hex = JT809Serializer.Serialize(jT809_0x1600_0x1601).ToHexString();
            Assert.Equal("736D616C6C636869", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "736D616C6C636869".ToHexBytes();
            JT809_0x1600_0x1601 jT809_0x1600_0x1601 = JT809Serializer.Deserialize<JT809_0x1600_0x1601>(bytes);
            Assert.Equal("smallchi", jT809_0x1600_0x1601.CarInfo);
        }
    }
}
