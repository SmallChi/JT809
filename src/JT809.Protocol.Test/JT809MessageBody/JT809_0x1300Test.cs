using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol.SubMessageBody;
using JT809.Protocol.Enums;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public  class JT809_0x1300Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x1300 jT809Bodies = new JT809_0x1300();
            jT809Bodies.SubBusinessType = JT809SubBusinessType.平台查岗应答;
            jT809Bodies.SubBodies = new JT809_0x1300_0x1301
            {
                  ObjectID="111",
                  InfoContent= "22ha22",
                  InfoID= 1234,
                  ObjectType= JT809_0x1301_ObjectType.当前连接的下级平台
            };
            var hex = JT809Serializer.Serialize(jT809Bodies).ToHexString();
            //"13 01 00 00 00 1B 01 31 31 31 00 00 00 00 00 00 00 00 00 00 00 04 D2 00 00 00 06 32 32 68 61 32 32"
            Assert.Equal("13010000001B01313131000000000000000000000004D200000006323268613232", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "13 01 00 00 00 1B 01 31 31 31 00 00 00 00 00 00 00 00 00 00 00 04 D2 00 00 00 06 32 32 68 61 32 32".ToHexBytes();
            JT809_0x1300 jT809Bodies = JT809Serializer.Deserialize<JT809_0x1300>(bytes);
            Assert.Equal(JT809SubBusinessType.平台查岗应答, jT809Bodies.SubBusinessType);
            JT809_0x1300_0x1301 jT809SubBodies = (JT809_0x1300_0x1301)jT809Bodies.SubBodies;
            Assert.Equal("111", jT809SubBodies.ObjectID);
            Assert.Equal("22ha22", jT809SubBodies.InfoContent);
            Assert.Equal((uint)1234, jT809SubBodies.InfoID);
            Assert.Equal(JT809_0x1301_ObjectType.当前连接的下级平台, jT809SubBodies.ObjectType);
        }
    }
}
