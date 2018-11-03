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
    public class JT809_0x1200_0x120BTest
    {
        [Fact]
        public void Test1()
        {
            JT809_0x1200_0x120B jT809_0X1200_0X120B = new JT809_0x1200_0x120B
            {
                 EwaybillInfo="asd123456asd"
            };
            var hex = JT809Serializer.Serialize(jT809_0X1200_0X120B).ToHexString();
            //"00 00 00 0C 61 73 64 31 32 33 34 35 36 61 73 64"
            Assert.Equal("0000000C617364313233343536617364", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00 00 00 0C 61 73 64 31 32 33 34 35 36 61 73 64".ToHexBytes();
            JT809_0x1200_0x120B jT809_0X1200_0X120B = JT809Serializer.Deserialize<JT809_0x1200_0x120B>(bytes);
            Assert.Equal("asd123456asd", jT809_0X1200_0X120B.EwaybillInfo);
            Assert.Equal((uint)12, jT809_0X1200_0X120B.EwaybillLength);
        }
    }
}
