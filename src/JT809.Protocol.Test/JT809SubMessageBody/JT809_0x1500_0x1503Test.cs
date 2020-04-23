using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using JT809.Protocol.SubMessageBody;
using JT809.Protocol.Enums;
using JT809.Protocol.Internal;

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public  class JT809_0x1500_0x1503Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });

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

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x1500_0x1503 jT809_0X1500_0X1503 = new JT809_0x1500_0x1503
            {
                 SourceDataType=99,
                 SourceMsgSn=11,
                 Result= JT809_0x1503_Result.下发成功      
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0X1500_0X1503).ToHexString();
            Assert.Equal("00630000000B00", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "00630000000B00".ToHexBytes();
            JT809_0x1500_0x1503 jT809_0X1500_0X1503 = JT809_2019_Serializer.Deserialize<JT809_0x1500_0x1503>(bytes);
            Assert.Equal(99, jT809_0X1500_0X1503.SourceDataType);
            Assert.Equal(11u, jT809_0X1500_0X1503.SourceMsgSn);
            Assert.Equal(JT809_0x1503_Result.下发成功, jT809_0X1500_0X1503.Result);
        }
    }
}
