using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Enums;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public class JT809_0x1002Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();

        [Fact]
        public void Test1()
        {
            JT809_0x1002 jT809_0X1002 = new JT809_0x1002();
            jT809_0X1002.Result = JT809_0x1002_Result.成功;
            jT809_0X1002.VerifyCode = 54456;
            var hex = JT809Serializer.Serialize(jT809_0X1002).ToHexString();
            //"00 00 00 D4 B8"
            Assert.Equal("000000D4B8", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00 00 00 D4 B8".ToHexBytes();
            JT809_0x1002 jT809_0X1002 = JT809Serializer.Deserialize<JT809_0x1002>(bytes);
            Assert.Equal(JT809_0x1002_Result.成功, jT809_0X1002.Result);
            Assert.Equal((uint)54456, jT809_0X1002.VerifyCode);
        }
    }
}
