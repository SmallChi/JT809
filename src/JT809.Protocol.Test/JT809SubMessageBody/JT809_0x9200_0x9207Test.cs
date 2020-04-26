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
    public class JT809_0x9200_0x9207Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
        [Fact]
        public void Test1()
        {
            JT809_0x9200_0x9207 jT809_0X9200_0X9207 = new JT809_0x9200_0x9207
            {
                 Result=  JT809_0x9207_Result.申请成功
            };
            var hex = JT809Serializer.Serialize(jT809_0X9200_0X9207).ToHexString();
            Assert.Equal("00", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00".ToHexBytes();
            JT809_0x9200_0x9207 jT809_0X9200_0X9207 = JT809Serializer.Deserialize<JT809_0x9200_0x9207>(bytes);
            Assert.Equal(JT809_0x9207_Result.申请成功, jT809_0X9200_0X9207.Result);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x9200_0x9207 jT809_0X9200_0X9207 = new JT809_0x9200_0x9207
            {
                SourceDataType= 1,
                SourceMsgSn=2,
                Result = JT809_0x9207_Result.申请成功
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0X9200_0X9207).ToHexString();
            Assert.Equal("00010000000200", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "00010000000200".ToHexBytes();
            JT809_0x9200_0x9207 jT809_0X9200_0X9207 = JT809_2019_Serializer.Deserialize<JT809_0x9200_0x9207>(bytes);
            Assert.Equal(JT809_0x9207_Result.申请成功, jT809_0X9200_0X9207.Result);
            Assert.Equal(1, jT809_0X9200_0X9207.SourceDataType);
            Assert.Equal(2u, jT809_0X9200_0X9207.SourceMsgSn);
        }
    }
}
