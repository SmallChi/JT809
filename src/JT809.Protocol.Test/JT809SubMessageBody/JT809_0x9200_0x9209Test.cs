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
    public class JT809_0x9200_0x9209Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
        [Fact]
        public void Test1()
        {
            JT809_0x9200_0x9209 jT809_0X9200_0X9209 = new JT809_0x9200_0x9209
            {
                 Result= JT809_0x9209_Result.成功_上级平台即刻补发
            };
            var hex = JT809Serializer.Serialize(jT809_0X9200_0X9209).ToHexString();
            Assert.Equal("00", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00".ToHexBytes();
            JT809_0x9200_0x9209 jT809_0X9200_0X9209 = JT809Serializer.Deserialize<JT809_0x9200_0x9209>(bytes);
            Assert.Equal(JT809_0x9209_Result.成功_上级平台即刻补发, jT809_0X9200_0X9209.Result);
        }
        [Fact]
        public void Test_2019_1()
        {
            JT809_0x9200_0x9209 jT809_0X9200_0X9209 = new JT809_0x9200_0x9209
            {
                Result = JT809_0x9209_Result.成功_上级平台即刻补发,
                SourceDataType=22,
                SourceMsgSn=33
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0X9200_0X9209).ToHexString();
            Assert.Equal("00160000002100", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "00160000002100".ToHexBytes();
            JT809_0x9200_0x9209 jT809_0X9200_0X9209 = JT809_2019_Serializer.Deserialize<JT809_0x9200_0x9209>(bytes);
            Assert.Equal(JT809_0x9209_Result.成功_上级平台即刻补发, jT809_0X9200_0X9209.Result);
            Assert.Equal(22, jT809_0X9200_0X9209.SourceDataType);
            Assert.Equal(33u, jT809_0X9200_0X9209.SourceMsgSn);
        }
    }
}
