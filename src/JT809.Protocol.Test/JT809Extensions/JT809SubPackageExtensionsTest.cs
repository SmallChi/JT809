using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.SubMessageBody;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace JT809.Protocol.Test.JT809Extensions
{
    public class JT809SubPackageExtensionsTest
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            var types = Enum.GetNames(typeof(JT809SubBusinessType));
            foreach (var item in types)
            {
                JT809SubBusinessType jT809SubBusinessType = item.ToEnum<JT809SubBusinessType>();
                JT809BodiesTypeAttribute jT809SubBodiesTypeAttribute = jT809SubBusinessType.GetAttribute<JT809BodiesTypeAttribute>();
                JT809SubBusinessTypeDescriptionAttribute jT809SubBusinessTypeDescriptionAttribute = jT809SubBusinessType.GetAttribute<JT809SubBusinessTypeDescriptionAttribute>();
                if (jT809SubBusinessType == JT809SubBusinessType.None)
                {
                    Assert.Null(jT809SubBodiesTypeAttribute);
                    Assert.Null(jT809SubBusinessTypeDescriptionAttribute);
                    continue;
                }
                Assert.NotNull(jT809SubBusinessTypeDescriptionAttribute.Code);
                Assert.NotNull(jT809SubBusinessTypeDescriptionAttribute.Name);
            }
        }

        [Fact]
        public void Create_0x1001_Test()
        {
            JT809Package jT809Package= JT809BusinessType.主链路登录请求消息.Create_主链路登录请求消息(new JT809Header
            {
                MsgSN = 133,
                EncryptKey = 9999,
                MsgGNSSCENTERID = 20180920,
            }, new MessageBody.JT809_0x1001
            {
                UserId = 20180920,
                Password = "20180920",
                DownLinkIP = "127.0.0.1",
                DownLinkPort = 809
            });
            var hex = JT809Serializer.Serialize(jT809Package).ToHexString();
            Assert.Equal("5B000000480000008510010133EFB8010000000000270F0133EFB832303138303932303132372E302E302E31000000000000000000000000000000000000000000000003296A915D", hex);
        }

        [Fact]
        public void Create_JT809_0x9400_0x9401_Test()
        {
            JT809Package jT809Package = JT809BusinessType.从链路报警信息交互消息.Create_从链路报警信息交互消息(
                new JT809Header
                {
                    MsgSN = 1666,
                    EncryptKey = 9999,
                    EncryptFlag = JT809Header_Encrypt.None,
                    Version = new JT809Header_Version(1, 0, 0),
                    MsgGNSSCENTERID = 20180920,
                }, new JT809_0x9400
                {
                    VehicleNo = "粤A12345",
                    VehicleColor = JT809VehicleColorType.黄色,
                    SubBusinessType = JT809SubBusinessType.报警督办请求消息.ToUInt16Value(),
                    SubBodies = JT809SubBusinessType.报警督办请求消息.Create_报警督办请求消息(
                        new JT809_0x9400_0x9401
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
                        })
                }
            );
            var hex = JT809Serializer.Serialize(jT809Package).ToHexString();
            //5B0000007C0000068294000133EFB8010000000000270F94010000005C010002000000005A01AC3F40123FFAA1000000005A01AC4D5003736D616C6C636869000000000000000031323334353637383930310000000000000000003132333435364071712E636F6D00000000000000000000000000000000000000A6565D
            //5B000000920000068294000133EFB8010000000000270FD4C1413132333435000000000000000000000000000294010000005C010002000000005A01AC3F40123FFAA1000000005A01AC4D5003736D616C6C636869000000000000000031323334353637383930310000000000000000003132333435364071712E636F6D00000000000000000000000000000000000000BAD85D
            Assert.Equal("5B000000920000068294000133EFB8010000000000270FD4C1413132333435000000000000000000000000000294010000005C010002000000005A01AC3F40123FFAA1000000005A01AC4D5001736D616C6C636869000000000000000031323334353637383930310000000000000000003132333435364071712E636F6D000000000000000000000000000000000000007AEA5D", hex);
        }
    }
}
