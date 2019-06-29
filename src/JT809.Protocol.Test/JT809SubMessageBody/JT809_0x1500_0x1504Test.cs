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
    public  class JT809_0x1500_0x1504Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809_0x1400_0x1403 jT809_0x1400_0x1403 = new JT809_0x1400_0x1403
            {
                Result = JT809_0x1403_Result.将来处理,
                InfoID = 3344,
            };
            var hex = JT809Serializer.Serialize(jT809_0x1400_0x1403).ToHexString();
            // "00 00 0D 10 03"
            Assert.Equal("00000D1003",hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00 00 0D 10 03".ToHexBytes();
            JT809_0x1400_0x1403 jT809_0x1400_0x1403 = JT809Serializer.Deserialize<JT809_0x1400_0x1403>(bytes);
            Assert.Equal(JT809_0x1403_Result.将来处理, jT809_0x1400_0x1403.Result);
            Assert.Equal((uint)3344, jT809_0x1400_0x1403.InfoID);
        }
    }
}
