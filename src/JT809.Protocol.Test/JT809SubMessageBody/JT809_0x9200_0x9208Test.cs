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
    public class JT809_0x9200_0x9208Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
        [Fact]
        public void Test1()
        {
            JT809_0x9200_0x9208 jT809_0X9200_0X9208 = new JT809_0x9200_0x9208
            {
                 Result=  JT809_0x9208_Result.其它,
            };
            var hex = JT809Serializer.Serialize(jT809_0X9200_0X9208).ToHexString();
            Assert.Equal("02", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "02".ToHexBytes();
            JT809_0x9200_0x9208 jT809_0X9200_0X9208 = JT809Serializer.Deserialize<JT809_0x9200_0x9208>(bytes);
            Assert.Equal(JT809_0x9208_Result.其它, jT809_0X9200_0X9208.Result);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x9200_0x9208 jT809_0X9200_0X9208 = new JT809_0x9200_0x9208
            {
                Result = JT809_0x9208_Result.其它,
                SourceDataType=1,
                SourceMsgSn=2
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0X9200_0X9208).ToHexString();
            Assert.Equal("00010000000202", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "00010000000202".ToHexBytes();
            JT809_0x9200_0x9208 jT809_0X9200_0X9208 = JT809_2019_Serializer.Deserialize<JT809_0x9200_0x9208>(bytes);
            Assert.Equal(JT809_0x9208_Result.其它, jT809_0X9200_0X9208.Result);
            Assert.Equal(1, jT809_0X9200_0X9208.SourceDataType);
            Assert.Equal(2u, jT809_0X9200_0X9208.SourceMsgSn);
        }
    }
}
