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
    public  class JT809_0x1500_0x1501Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x1500_0x1501 jT809_0X1500_0X1501 = new JT809_0x1500_0x1501
            {
                 Result=  JT809_0x1501_Result.监听成功
            };
            var hex = JT809Serializer.Serialize(jT809_0X1500_0X1501).ToHexString();
            Assert.Equal("00",hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00".ToHexBytes();
            JT809_0x1500_0x1501 jT809_0X1500_0X1501 = JT809Serializer.Deserialize<JT809_0x1500_0x1501>(bytes);
            Assert.Equal(JT809_0x1501_Result.监听成功, jT809_0X1500_0X1501.Result);
        }
    }
}
