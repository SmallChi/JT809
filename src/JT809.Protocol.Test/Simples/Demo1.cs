using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.SubMessageBody;
using JT809.Protocol.Enums;
using JT809.Protocol.Configs;

namespace JT809.Protocol.Test.Simples
{
    public class Demo1
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();

        [Fact]
        public void Test1()
        {
            JT809Package jT809Package = new JT809Package();

            jT809Package.Header = new JT809Header
            {
                MsgSN = 1666,
                EncryptKey = 9999,
                EncryptFlag = JT809Header_Encrypt.None,
                Version = new JT809Header_Version(1, 0, 0),
                BusinessType = JT809BusinessType.从链路报警信息交互消息.ToUInt16Value(),
                MsgGNSSCENTERID = 20180920,
            };

            JT809_0x9400 bodies = new JT809_0x9400
            {
                VehicleNo = "粤A12345",
                VehicleColor = JT809VehicleColorType.黄色,
                SubBusinessType = JT809SubBusinessType.报警督办请求消息.ToUInt16Value(),
            };

            JT809_0x9400_0x9401 jT809_0x9400_0x9401 = new JT809_0x9400_0x9401
            {
                WarnSrc = JT809WarnSrc.车载终端,
                WarnType = JT809WarnType.疲劳驾驶报警.ToUInt16Value(),
                WarnTime = DateTime.Parse("2018-09-27 10:24:00"),
                SupervisionID = "123FFAA1",
                SupervisionEndTime = DateTime.Parse("2018-09-27 11:24:00"),
                SupervisionLevel =  JT809_9401_SupervisionLevel.一般,
                Supervisor = "smallchi",
                SupervisorTel = "12345678901",
                SupervisorEmail = "123456@qq.com"
            };
            bodies.SubBodies = jT809_0x9400_0x9401;
            jT809Package.Bodies = bodies;
            var hex = JT809Serializer.Serialize(jT809Package).ToHexString();
            //"5B 00 00 00 92 00 00 06 82 94 00 01 33 EF B8 01 00 00 00 00 00 27 0F D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 02 94 01 00 00 00 5C 01 00 02 00 00 00 00 5A 01 AC 3F 40 12 3F FA A1 00 00 00 00 5A 01 AC 4D 50 03 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00 31 32 33 34 35 36 37 38 39 30 31 00 00 00 00 00 00 00 00 00 31 32 33 34 35 36 40 71 71 2E 63 6F 6D 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 BA D8 5D"
            Assert.Equal("5B000000920000068294000133EFB8010000000000270FD4C1413132333435000000000000000000000000000294010000005C010002000000005A01AC3F40123FFAA1000000005A01AC4D5001736D616C6C636869000000000000000031323334353637383930310000000000000000003132333435364071712E636F6D000000000000000000000000000000000000007AEA5D", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "5B000000920000068294000133EFB8010000000000270FD4C1413132333435000000000000000000000000000294010000005C010002000000005A01AC3F40123FFAA1000000005A01AC4D5001736D616C6C636869000000000000000031323334353637383930310000000000000000003132333435364071712E636F6D000000000000000000000000000000000000007AEA5D".ToHexBytes();
            JT809Package jT809Package = JT809Serializer.Deserialize(bytes);

            Assert.Equal((uint)146, jT809Package.Header.MsgLength);
            Assert.Equal((uint)1666, jT809Package.Header.MsgSN);
            Assert.Equal((uint)9999, jT809Package.Header.EncryptKey);
            Assert.Equal(JT809Header_Encrypt.None, jT809Package.Header.EncryptFlag);
            Assert.Equal((uint)20180920, jT809Package.Header.MsgGNSSCENTERID);
            Assert.Equal(JT809BusinessType.从链路报警信息交互消息, (JT809BusinessType)jT809Package.Header.BusinessType);
            Assert.Equal(new JT809Header_Version().ToString(), jT809Package.Header.Version.ToString());

            JT809_0x9400 jT809_0X400 = (JT809_0x9400)jT809Package.Bodies;
            Assert.Equal("粤A12345", jT809_0X400.VehicleNo);
            Assert.Equal(JT809VehicleColorType.黄色, jT809_0X400.VehicleColor);
            Assert.Equal(JT809SubBusinessType.报警督办请求消息, (JT809SubBusinessType)jT809_0X400.SubBusinessType);
            Assert.Equal((uint)92, jT809_0X400.DataLength);

            JT809_0x9400_0x9401 jT809_0x9400_0x9401 = (JT809_0x9400_0x9401)jT809_0X400.SubBodies;
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

        [Fact]
        public void Test3()
        {
            JT809Serializer JT809SerializerTest3 = new JT809Serializer();
            JT809Package jT809Package = JT809BusinessType.从链路报警信息交互消息.Create(new JT809_0x9400
            {
                VehicleNo = "粤A12345",
                VehicleColor = JT809VehicleColorType.黄色,
                SubBusinessType = JT809SubBusinessType.报警督办请求消息.ToUInt16Value(),
                SubBodies = new JT809_0x9400_0x9401
                {
                    WarnSrc = JT809WarnSrc.车载终端,
                    WarnType = JT809WarnType.疲劳驾驶报警.ToUInt16Value(),
                    WarnTime = DateTime.Parse("2018-09-27 10:24:00"),
                    SupervisionID = "123FFAA1",
                    SupervisionEndTime = DateTime.Parse("2018-09-27 11:24:00"),
                    SupervisionLevel =  JT809_9401_SupervisionLevel.一般,
                    Supervisor = "smallchi",
                    SupervisorTel = "12345678901",
                    SupervisorEmail = "123456@qq.com"
                }
            });
            jT809Package.Header.MsgSN = 1666;
            jT809Package.Header.EncryptKey = 9999;
            jT809Package.Header.MsgGNSSCENTERID = 20180920;
            var hex = JT809SerializerTest3.Serialize(jT809Package).ToHexString();
            //"5B000000920000068294000133EFB8010000000000270FD4C1413132333435000000000000000000000000000294010000005C010002000000005A01AC3F40123FFAA1000000005A01AC4D5001736D616C6C636869000000000000000031323334353637383930310000000000000000003132333435364071712E636F6D000000000000000000000000000000000000007AEA5D"
            Assert.Equal("5B000000920000068294000133EFB8010000000000270FD4C1413132333435000000000000000000000000000294010000005C010002000000005A01AC3F40123FFAA1000000005A01AC4D5001736D616C6C636869000000000000000031323334353637383930310000000000000000003132333435364071712E636F6D000000000000000000000000000000000000007AEA5D", hex);
        }
    }
}
