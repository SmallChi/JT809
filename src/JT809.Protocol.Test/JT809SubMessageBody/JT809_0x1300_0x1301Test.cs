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
    public class JT809_0x1300_0x1301Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x1300_0x1301 jT809_0x1300_0x1301 = new JT809_0x1300_0x1301
            {
                ObjectID = "111",
                InfoContent = "22ha22",
                InfoID = 1234,
                ObjectType = JT809Enums.JT809_0x1301_ObjectType.当前连接的下级平台
            };
            var hex = JT809Serializer.Serialize(jT809_0x1300_0x1301).ToHexString();
            //"01 31 31 31 00 00 00 00 00 00 00 00 00 00 00 04 D2 00 00 00 06 32 32 68 61 32 32"
            Assert.Equal("01313131000000000000000000000004D200000006323268613232", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "01 31 31 31 00 00 00 00 00 00 00 00 00 00 00 04 D2 00 00 00 06 32 32 68 61 32 32".ToHexBytes();
            JT809_0x1300_0x1301 jT809_0x1300_0x1301 = JT809Serializer.Deserialize<JT809_0x1300_0x1301>(bytes);
            Assert.Equal("111", jT809_0x1300_0x1301.ObjectID);
            Assert.Equal("22ha22", jT809_0x1300_0x1301.InfoContent);
            Assert.Equal((uint)1234, jT809_0x1300_0x1301.InfoID);
            Assert.Equal(JT809Enums.JT809_0x1301_ObjectType.当前连接的下级平台, jT809_0x1300_0x1301.ObjectType);
        }
    }
}
