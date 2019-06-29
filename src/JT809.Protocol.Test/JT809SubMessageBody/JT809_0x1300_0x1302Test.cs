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
    public class JT809_0x1300_0x1302Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809_0x1300_0x1302 jT809_0x1300_0x1302 = new JT809_0x1300_0x1302
            {
                InfoID = 1234
            };
            var hex = JT809Serializer.Serialize(jT809_0x1300_0x1302).ToHexString();
            Assert.Equal("000004D2", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "000004D2".ToHexBytes();
            JT809_0x1300_0x1302 jT809_0x1300_0x1302 = JT809Serializer.Deserialize<JT809_0x1300_0x1302>(bytes);  
            Assert.Equal((uint)1234, jT809_0x1300_0x1302.InfoID);
        }
    }
}
