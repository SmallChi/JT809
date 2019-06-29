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

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x1600_0x1601Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
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
