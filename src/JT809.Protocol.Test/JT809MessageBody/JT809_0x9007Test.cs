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
    public class JT809_0x9007Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809_0x9007 jT809_0X9007 = new JT809_0x9007();
            jT809_0X9007.ErrorCode =  JT809_0x1007_ErrorCode.主链路断开;
            var hex = JT809Serializer.Serialize(jT809_0X9007).ToHexString();
            Assert.Equal("00", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00".ToHexBytes();
            JT809_0x9007 jT809_0X9007 = JT809Serializer.Deserialize<JT809_0x9007>(bytes);
            Assert.Equal(JT809_0x1007_ErrorCode.主链路断开, jT809_0X9007.ErrorCode);
        }
    }
}
