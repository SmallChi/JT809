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
    public  class JT809_0x1500_0x1505Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
        [Fact]
        public void Test1()
        {
            JT809_0x1500_0x1505 jT809_0X1500_0X1505 = new JT809_0x1500_0x1505
            {
                 Result= JT809_0x1505_Result.无该车辆
            };
            var hex = JT809Serializer.Serialize(jT809_0X1500_0X1505).ToHexString();
            Assert.Equal("01",hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "01".ToHexBytes();
            JT809_0x1500_0x1505 jT809_0X1500_0X1505 = JT809Serializer.Deserialize<JT809_0x1500_0x1505>(bytes);
            Assert.Equal(JT809_0x1505_Result.无该车辆, jT809_0X1500_0X1505.Result);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x1500_0x1505 jT809_0X1500_0X1505 = new JT809_0x1500_0x1505
            {
                Result = JT809_0x1505_Result.无该车辆,
                SourceDataType=5,
                SourceMsgSn=1
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0X1500_0X1505).ToHexString();
            Assert.Equal("00050000000101", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "00050000000101".ToHexBytes();
            JT809_0x1500_0x1505 jT809_0X1500_0X1505 = JT809_2019_Serializer.Deserialize<JT809_0x1500_0x1505>(bytes);
            Assert.Equal(JT809_0x1505_Result.无该车辆, jT809_0X1500_0X1505.Result);
            Assert.Equal(5, jT809_0X1500_0X1505.SourceDataType);
            Assert.Equal(1u, jT809_0X1500_0X1505.SourceMsgSn);
        }
    }
}
