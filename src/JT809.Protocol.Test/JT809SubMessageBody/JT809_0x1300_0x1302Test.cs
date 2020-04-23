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
    public class JT809_0x1300_0x1302Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
        [Fact]
        public void Test1()
        {
            JT809_0x1300_0x1302 jT809_0x1300_0x1302 = new JT809_0x1300_0x1302
            {
                InfoID = 1234
            };
            var hex = JT809Serializer.Serialize(jT809_0x1300_0x1302).ToHexString();
            Assert.Equal("000004D2", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "000004D2".ToHexBytes();
            JT809_0x1300_0x1302 jT809_0x1300_0x1302 = JT809Serializer.Deserialize<JT809_0x1300_0x1302>(bytes);  
            Assert.Equal((uint)1234, jT809_0x1300_0x1302.InfoID);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x1300_0x1302 jT809_0x1300_0x1302 = new JT809_0x1300_0x1302
            {
                InfoID = 1234,
                SourceDataType=0x99,
                SourceMsgSn=11
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0x1300_0x1302).ToHexString();
            Assert.Equal("00990000000B", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "00990000000B".ToHexBytes();
            JT809_0x1300_0x1302 jT809_0x1300_0x1302 = JT809_2019_Serializer.Deserialize<JT809_0x1300_0x1302>(bytes);
            Assert.Equal(0u, jT809_0x1300_0x1302.InfoID);
            Assert.Equal(0x99, jT809_0x1300_0x1302.SourceDataType);
            Assert.Equal(11u, jT809_0x1300_0x1302.SourceMsgSn);
        }
    }
}
