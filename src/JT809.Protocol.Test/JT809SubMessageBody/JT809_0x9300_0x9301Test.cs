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
    public class JT809_0x9300_0x9301Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x9300_0x9301 jT809_0x9300_0x9301 = new JT809_0x9300_0x9301
            {
                ObjectID="smallchi",
                ObjectType= JT809_0x9301_ObjectType.下级平台所属单一业户,
                InfoContent="reply",
                InfoID = 3344,
            };
            var hex = JT809Serializer.Serialize(jT809_0x9300_0x9301).ToHexString();
            // "02 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 0D 10 00 00 00 05 72 65 70 6C 79"
            Assert.Equal("02736D616C6C6368690000000000000D10000000057265706C79", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "02 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 0D 10 00 00 00 05 72 65 70 6C 79".ToHexBytes();
            JT809_0x9300_0x9301 jT809_0x9300_0x9301 = JT809Serializer.Deserialize<JT809_0x9300_0x9301>(bytes);
            Assert.Equal(JT809_0x9301_ObjectType.下级平台所属单一业户, jT809_0x9300_0x9301.ObjectType);
            Assert.Equal((uint)3344, jT809_0x9300_0x9301.InfoID);
            Assert.Equal("reply", jT809_0x9300_0x9301.InfoContent);
            Assert.Equal("smallchi", jT809_0x9300_0x9301.ObjectID);
        }

    }
}
