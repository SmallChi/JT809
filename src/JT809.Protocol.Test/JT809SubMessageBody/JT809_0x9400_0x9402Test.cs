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
    public class JT809_0x9400_0x9402Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x9400_0x9402 jT809_0x9400_0x9402 = new JT809_0x9400_0x9402
            {
                  WarnSrc= JT809WarnSrc.车载终端,
                  WarnType= JT809WarnType.劫警,
                  WarnTime=DateTime.Parse("2018-11-11 10:24:00"),
                  WarnContent= "劫警",
            };
            var hex = JT809Serializer.Serialize(jT809_0x9400_0x9402).ToHexString();
            Assert.Equal("01000A000000005BE792C000000004BDD9BEAF", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "01000A000000005BE792C000000004BDD9BEAF".ToHexBytes();
            JT809_0x9400_0x9402 jT809_0x9400_0x9402 = JT809Serializer.Deserialize<JT809_0x9400_0x9402>(bytes);
            Assert.Equal(JT809WarnSrc.车载终端, jT809_0x9400_0x9402.WarnSrc);
            Assert.Equal(JT809WarnType.劫警, jT809_0x9400_0x9402.WarnType);
            Assert.Equal(DateTime.Parse("2018-11-11 10:24:00"), jT809_0x9400_0x9402.WarnTime);
            Assert.Equal("劫警", jT809_0x9400_0x9402.WarnContent);
            Assert.Equal((uint)4, jT809_0x9400_0x9402.WarnLength);
        }
    }
}
