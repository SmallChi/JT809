using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using JT809.Protocol.SubMessageBody;
using JT809.Protocol.Internal;
using JT809.Protocol.Enums;

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x1200_0x120BTest
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
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

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x1200_0x120B jT809_0X1200_0X120B = new JT809_0x1200_0x120B
            {
                EwaybillInfo = "asd123456asd",
                SourceDataType=0x02,
                SourceMsgSn=1
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0X1200_0X120B).ToHexString();
            Assert.Equal("0002000000010000000C617364313233343536617364", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "0002000000010000000C617364313233343536617364".ToHexBytes();
            JT809_0x1200_0x120B jT809_0X1200_0X120B = JT809_2019_Serializer.Deserialize<JT809_0x1200_0x120B>(bytes);
            Assert.Equal("asd123456asd", jT809_0X1200_0X120B.EwaybillInfo);
            Assert.Equal((uint)12, jT809_0X1200_0X120B.EwaybillLength);
            Assert.Equal(0x02, jT809_0X1200_0X120B.SourceDataType);
            Assert.Equal(1u, jT809_0X1200_0X120B.SourceMsgSn);
        }
    }
}
