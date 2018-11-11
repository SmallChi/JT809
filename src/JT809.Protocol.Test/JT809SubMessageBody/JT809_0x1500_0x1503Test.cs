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
    public  class JT809_0x1500_0x1503Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x1500_0x1503 jT809_0X1500_0X1503 = new JT809_0x1500_0x1503
            {
                 MsgID=9999,
                 Result= JT809_0x1503_Result.下发成功
            };
            var hex = JT809Serializer.Serialize(jT809_0X1500_0X1503).ToHexString();
            Assert.Equal("0000270F00", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "0000270F00".ToHexBytes();
            JT809_0x1500_0x1503 jT809_0X1500_0X1503 = JT809Serializer.Deserialize<JT809_0x1500_0x1503>(bytes);
            Assert.Equal(JT809_0x1503_Result.下发成功, jT809_0X1500_0X1503.Result);
            Assert.Equal((uint)9999, jT809_0X1500_0X1503.MsgID);
        }
    }
}
