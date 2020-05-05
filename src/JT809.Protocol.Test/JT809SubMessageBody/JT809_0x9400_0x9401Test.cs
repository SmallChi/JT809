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
    public class JT809_0x9400_0x9401Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809_0x9400_0x9401 jT809_0x9400_0x9401 = new JT809_0x9400_0x9401
            {
                  WarnSrc= JT809WarnSrc.车载终端,
                  WarnType= JT809WarnType.疲劳驾驶报警.ToUInt16Value(),
                  WarnTime=DateTime.Parse("2018-09-27 10:24:00"),
                  SupervisionID="123FFAA1",
                  SupervisionEndTime= DateTime.Parse("2018-09-27 11:24:00"),
                  SupervisionLevel= JT809_9401_SupervisionLevel.一般,
                  Supervisor="smallchi",
                  SupervisorTel= "12345678901",
                  SupervisorEmail= "123456@qq.com"
            };
            var hex = JT809Serializer.Serialize(jT809_0x9400_0x9401).ToHexString();
            //010002000000005BAC3F40123FFAA1000000005BAC4D5003736D616C6C63686931323334353637383930313132333435364071712E636F6D
            //010002000000005BAC3F40123FFAA1000000005BAC4D5003736D616C6C636869000000000000000031323334353637383930310000000000000000003132333435364071712E636F6D00000000000000000000000000000000000000
            //"01 00 02 00 00 00 00 5B AC 3F 40 12 3F FA A1 00 00 00 00 5B AC 4D 50 03 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00 31 32 33 34 35 36 37 38 39 30 31 00 00 00 00 00 00 00 00 00 31 32 33 34 35 36 40 71 71 2E 63 6F 6D 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00"
            Assert.Equal("010002000000005BAC3F40123FFAA1000000005BAC4D5001736D616C6C636869000000000000000031323334353637383930310000000000000000003132333435364071712E636F6D00000000000000000000000000000000000000", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "010002000000005BAC3F40123FFAA1000000005BAC4D5001736D616C6C636869000000000000000031323334353637383930310000000000000000003132333435364071712E636F6D00000000000000000000000000000000000000".ToHexBytes();
            JT809_0x9400_0x9401 jT809_0x9400_0x9401 = JT809Serializer.Deserialize<JT809_0x9400_0x9401>(bytes);
            Assert.Equal(JT809WarnSrc.车载终端, jT809_0x9400_0x9401.WarnSrc);
            Assert.Equal(JT809WarnType.疲劳驾驶报警, (JT809WarnType)jT809_0x9400_0x9401.WarnType);
            Assert.Equal(DateTime.Parse("2018-09-27 10:24:00"), jT809_0x9400_0x9401.WarnTime);
            Assert.Equal("123FFAA1", jT809_0x9400_0x9401.SupervisionID);
            Assert.Equal(DateTime.Parse("2018-09-27 11:24:00"), jT809_0x9400_0x9401.SupervisionEndTime);
            Assert.Equal(1, jT809_0x9400_0x9401.SupervisionLevel.ToByteValue());
            Assert.Equal("smallchi", jT809_0x9400_0x9401.Supervisor);
            Assert.Equal("12345678901", jT809_0x9400_0x9401.SupervisorTel);
            Assert.Equal("123456@qq.com", jT809_0x9400_0x9401.SupervisorEmail);
        }
    }
}
