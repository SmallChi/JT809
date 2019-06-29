using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public class JT809_0x1003Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809_0x1003 jT809_0X1003 = new JT809_0x1003();
            jT809_0X1003.UserId = 20180920;
            jT809_0X1003.Password = "20180920";
            var hex = JT809Serializer.Serialize(jT809_0X1003).ToHexString();
            //"01 33 EF B8 32 30 31 38 30 39 32 30"
            Assert.Equal("0133EFB83230313830393230", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "01 33 EF B8 32 30 31 38 30 39 32 30".ToHexBytes();
            JT809_0x1003 jT809_0X1003 = JT809Serializer.Deserialize<JT809_0x1003>(bytes);
            Assert.Equal((uint)20180920, jT809_0X1003.UserId);
            Assert.Equal("20180920", jT809_0X1003.Password);
        }
    }
}
