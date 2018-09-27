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
    public class JT809_0x9400_0x9401Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x9400_0x9401 jT809_0x9400_0x9401 = new JT809_0x9400_0x9401
            {
                  WarnSrc= JT809WarnSrc.车载终端,
                  WarnType= JT809WarnType.疲劳驾驶报警,
                  WarnTime=DateTime.Parse("2018-09-27 10:24:00"),
                  SupervisionID="123FFAA1",
                  SupervisionEndTime= DateTime.Parse("2018-09-27 11:24:00"),
                  SupervisionLevel=3,
                  Supervisor="smallchi",
                  SupervisorTel= "12345678901",
                  SupervisorEmail= "123456@qq.com"
            };
            var hex = JT809Serializer.Serialize(jT809_0x9400_0x9401).ToHexString();
            //"01 00 02 00 00 00 00 5B AC 3F 40 12 3F FA A1 00 00 00 00 5B AC 4D 50 03 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00 31 32 33 34 35 36 37 38 39 30 31 00 00 00 00 00 00 00 00 00 31 32 33 34 35 36 40 71 71 2E 63 6F 6D 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00"
        }

        [Fact]
        public void Test2()
        {
            var bytes = "01 00 02 00 00 00 00 5B AC 3F 40 12 3F FA A1 00 00 00 00 5B AC 4D 50 03 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00 31 32 33 34 35 36 37 38 39 30 31 00 00 00 00 00 00 00 00 00 31 32 33 34 35 36 40 71 71 2E 63 6F 6D 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00".ToHexBytes();
            JT809_0x9400_0x9401 jT809_0x9400_0x9401 = JT809Serializer.Deserialize<JT809_0x9400_0x9401>(bytes);
            Assert.Equal(JT809WarnSrc.车载终端, jT809_0x9400_0x9401.WarnSrc);
            Assert.Equal(JT809WarnType.疲劳驾驶报警, jT809_0x9400_0x9401.WarnType);
            Assert.Equal(DateTime.Parse("2018-09-27 10:24:00"), jT809_0x9400_0x9401.WarnTime);
            Assert.Equal("123FFAA1", jT809_0x9400_0x9401.SupervisionID);
            Assert.Equal(DateTime.Parse("2018-09-27 11:24:00"), jT809_0x9400_0x9401.SupervisionEndTime);
            Assert.Equal(3, jT809_0x9400_0x9401.SupervisionLevel);
            Assert.Equal("smallchi", jT809_0x9400_0x9401.Supervisor);
            Assert.Equal("12345678901", jT809_0x9400_0x9401.SupervisorTel);
            Assert.Equal("123456@qq.com", jT809_0x9400_0x9401.SupervisorEmail);
        }
    }
}
