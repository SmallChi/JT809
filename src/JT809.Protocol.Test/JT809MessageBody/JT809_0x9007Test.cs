using JT809.Protocol;
using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809MessageBody;
using JT809.Protocol.JT809Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public class JT809_0x9007Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x9007 jT809_0X9007 = new JT809_0x9007();
            jT809_0X9007.ReasonCode =  JT809Enums.JT809_0x9007_ReasonCode.无法连接下级平台指定的服务IP与端口;
            var hex = JT809Serializer.Serialize(jT809_0X9007).ToHexString();
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00".ToHexBytes();
            JT809_0x9007 jT809_0X9007 = JT809Serializer.Deserialize<JT809_0x9007>(bytes);
            Assert.Equal(JT809Enums.JT809_0x9007_ReasonCode.无法连接下级平台指定的服务IP与端口, jT809_0X9007.ReasonCode);
        }
    }
}
