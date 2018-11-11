using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809MessageBody;
using JT809.Protocol.JT809Exceptions;
using JT809.Protocol.JT809SubMessageBody;
using JT809.Protocol.JT809Enums;

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x9400_0x9403Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x9400_0x9403 jT809_0x9400_0x9403 = new JT809_0x9400_0x9403
            {
                  WarnSrc= JT809WarnSrc.车载终端,
                  WarnType= JT809WarnType.疲劳驾驶报警,
                  WarnTime=DateTime.Parse("2018-11-11 10:24:00"),
                  WarnContent= "疲劳驾驶报警",
            };
            var hex = JT809Serializer.Serialize(jT809_0x9400_0x9403).ToHexString();
            Assert.Equal("010002000000005BE792C00000000CC6A3C0CDBCDDCABBB1A8BEAF", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "010002000000005BE792C00000000CC6A3C0CDBCDDCABBB1A8BEAF".ToHexBytes();
            JT809_0x9400_0x9403 jT809_0x9400_0x9403 = JT809Serializer.Deserialize<JT809_0x9400_0x9403>(bytes);
            Assert.Equal(JT809WarnSrc.车载终端, jT809_0x9400_0x9403.WarnSrc);
            Assert.Equal(JT809WarnType.疲劳驾驶报警, jT809_0x9400_0x9403.WarnType);
            Assert.Equal(DateTime.Parse("2018-11-11 10:24:00"), jT809_0x9400_0x9403.WarnTime);
            Assert.Equal("疲劳驾驶报警", jT809_0x9400_0x9403.WarnContent);
            Assert.Equal((uint)12, jT809_0x9400_0x9403.WarnLength);
        }
    }
}
