using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol.Enums;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public class JT809_0x9002Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809_0x9002 jT809_0X9002 = new JT809_0x9002();
            jT809_0X9002.Result =  JT809_0x9002_Result.成功;
            var hex = JT809Serializer.Serialize(jT809_0X9002).ToHexString();
            Assert.Equal("00", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00".ToHexBytes();
            JT809_0x9002 jT809_0X9002 = JT809Serializer.Deserialize<JT809_0x9002>(bytes);
            Assert.Equal(JT809_0x9002_Result.成功, jT809_0X9002.Result);
        }
    }
}
