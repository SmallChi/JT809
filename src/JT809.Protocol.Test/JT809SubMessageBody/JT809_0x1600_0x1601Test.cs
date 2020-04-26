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
    public class JT809_0x1600_0x1601Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });

        [Fact]
        public void Test1()
        {
            JT809_0x1600_0x1601 jT809_0x1600_0x1601 = new JT809_0x1600_0x1601
            {
                 CarInfo = "smallchi",
            };
            var hex = JT809Serializer.Serialize(jT809_0x1600_0x1601).ToHexString();
            Assert.Equal("736D616C6C636869", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "736D616C6C636869".ToHexBytes();
            JT809_0x1600_0x1601 jT809_0x1600_0x1601 = JT809Serializer.Deserialize<JT809_0x1600_0x1601>(bytes);
            Assert.Equal("smallchi", jT809_0x1600_0x1601.CarInfo);
        }


        [Fact]
        public void Test_2019_1()
        {
            JT809_0x1600_0x1601 jT809_0x1600_0x1601 = new JT809_0x1600_0x1601
            {
                SourceDataType=1,
                SourceMsgSn=2,
                CarInfo = "smallchi",
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0x1600_0x1601).ToHexString();
            Assert.Equal("000100000002736D616C6C636869", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "000100000002736D616C6C636869".ToHexBytes();
            JT809_0x1600_0x1601 jT809_0x1600_0x1601 = JT809_2019_Serializer.Deserialize<JT809_0x1600_0x1601>(bytes);
            Assert.Equal("smallchi", jT809_0x1600_0x1601.CarInfo);
            Assert.Equal(2u, jT809_0x1600_0x1601.SourceMsgSn);
            Assert.Equal(1, jT809_0x1600_0x1601.SourceDataType);
        }
    }
}
