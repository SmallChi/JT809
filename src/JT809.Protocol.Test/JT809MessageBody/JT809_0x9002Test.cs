using JT809.Protocol;
using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809MessageBody;
using JT809.Protocol.JT809Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public class JT809_0x9002Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x9002 jT809_0X9002 = new JT809_0x9002();
            jT809_0X9002.Result =  JT809Enums.JT809_0x9002_Result.成功;
            var hex = JT809Serializer.Serialize(jT809_0X9002).ToHexString();
            Assert.Equal("00", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00".ToHexBytes();
            JT809_0x9002 jT809_0X9002 = JT809Serializer.Deserialize<JT809_0x9002>(bytes);
            Assert.Equal(JT809Enums.JT809_0x9002_Result.成功, jT809_0X9002.Result);
        }
    }
}
