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

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x1400_0x1402Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809_0x1400_0x1402 jT809_0x1400_0x1402 = new JT809_0x1400_0x1402
            {
                 WarnSrc= JT809WarnSrc.车载终端,
                 WarnType = JT809WarnType.偏离路线报警,
                 WarnTime=DateTime.Parse("2018-09-26"),
                 InfoContent = "gfdf454553",
                 InfoID = 3344,
            };
            var hex = JT809Serializer.Serialize(jT809_0x1400_0x1402).ToHexString();
            // "01 00 0B 00 00 00 00 5B AA 5B 80 00 00 0D 10 00 00 00 0A 67 66 64 66 34 35 34 35 35 33"
            Assert.Equal("01000B000000005BAA5B8000000D100000000A67666466343534353533", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "01 00 0B 00 00 00 00 5B AA 5B 80 00 00 0D 10 00 00 00 0A 67 66 64 66 34 35 34 35 35 33".ToHexBytes();
            JT809_0x1400_0x1402 jT809_0x1400_0x1402 = JT809Serializer.Deserialize<JT809_0x1400_0x1402>(bytes);
            Assert.Equal(JT809WarnSrc.车载终端, jT809_0x1400_0x1402.WarnSrc);
            Assert.Equal("gfdf454553", jT809_0x1400_0x1402.InfoContent);
            Assert.Equal(JT809WarnType.偏离路线报警, jT809_0x1400_0x1402.WarnType);
            Assert.Equal((uint)3344, jT809_0x1400_0x1402.InfoID);
            Assert.Equal((uint)10, jT809_0x1400_0x1402.InfoLength);
            Assert.Equal(DateTime.Parse("2018-09-26"), jT809_0x1400_0x1402.WarnTime);
        }
    }
}
