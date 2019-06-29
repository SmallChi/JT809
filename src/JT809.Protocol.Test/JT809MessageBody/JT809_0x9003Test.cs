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
    public class JT809_0x9003Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809_0x9003 jT809_0X9003 = new JT809_0x9003();
            jT809_0X9003.VerifyCode = 45454;
            var hex = JT809Serializer.Serialize(jT809_0X9003).ToHexString();
            Assert.Equal("0000B18E",hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00 00 B1 8E".ToHexBytes();
            JT809_0x9003 jT809_0X9003 = JT809Serializer.Deserialize<JT809_0x9003>(bytes);
            Assert.Equal((uint)45454, jT809_0X9003.VerifyCode);
        }
    }
}
