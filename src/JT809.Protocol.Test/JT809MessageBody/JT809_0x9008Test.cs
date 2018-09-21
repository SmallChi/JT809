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
    public class JT809_0x9008Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x9008 jT809_0X9008 = new JT809_0x9008();
            jT809_0X9008.ReasonCode = JT809Enums.JT809_0x9008_ReasonCode.其它原因;
            var hex = JT809Serializer.Serialize(jT809_0X9008).ToHexString();
        }

        [Fact]
        public void Test2()
        {
            var bytes = "01".ToHexBytes();
            JT809_0x9008 jT809_0X9008 = JT809Serializer.Deserialize<JT809_0x9008>(bytes);
            Assert.Equal(JT809Enums.JT809_0x9008_ReasonCode.其它原因, jT809_0X9008.ReasonCode);
        }
    }
}
