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
    public class JT809_0x9500_0x9503Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x9500_0x9503 jT809_0X9500_0X9503 = new JT809_0x9500_0x9503
            {
                   MsgSequence=333,
                   MsgPriority=2,
                   MsgContent="汉_sfdf3dfs"
            };
            var hex = JT809Serializer.Serialize(jT809_0X9500_0X9503).ToHexString();
            Assert.Equal("0000014D020000000BBABA5F7366646633646673", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "0000014D020000000BBABA5F7366646633646673".ToHexBytes();
            JT809_0x9500_0x9503 jT809_0X9500_0X9503 = JT809Serializer.Deserialize<JT809_0x9500_0x9503>(bytes);
            Assert.Equal((uint)333, jT809_0X9500_0X9503.MsgSequence);
            Assert.Equal(2, jT809_0X9500_0X9503.MsgPriority);
            Assert.Equal((uint)11, jT809_0X9500_0X9503.MsgLength);
            Assert.Equal("汉_sfdf3dfs", jT809_0X9500_0X9503.MsgContent);
        }
    }
}
