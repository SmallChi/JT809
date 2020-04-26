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
    public class JT809_0x9500_0x9501Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        
        [Fact]
        public void Test1()
        {
            JT809_0x9500_0x9501 jT809_0X9500_0X9501 = new JT809_0x9500_0x9501
            {
                 MonitorTel="123456789"
            };
            var hex = JT809Serializer.Serialize(jT809_0X9500_0X9501).ToHexString();
            Assert.Equal("3132333435363738390000000000000000000000", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "3132333435363738390000000000000000000000".ToHexBytes();
            JT809_0x9500_0x9501 jT809_0X9500_0X9501 = JT809Serializer.Deserialize<JT809_0x9500_0x9501>(bytes);
            Assert.Equal("123456789", jT809_0X9500_0X9501.MonitorTel);
        }
    }
}
