using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Enums;

namespace JT809.Protocol.Test.JT809Packages
{
    public class JT809HeaderPackageTest
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            var bytes = "5B 00 00 00 48 00 00 00 85 10 01 01 33 EF B8 01 00 00 00 00 00 27 0F 01 33 EF B8 32 30 31 38 30 39 32 30 31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 03 29 6A 91 5D".ToHexBytes();
            JT809HeaderPackage jT809HeaderPackage = JT809Serializer.Deserialize<JT809HeaderPackage>(bytes);
            Assert.Equal((uint)72, jT809HeaderPackage.Header.MsgLength);
            Assert.Equal((uint)133, jT809HeaderPackage.Header.MsgSN);
            Assert.Equal((uint)9999, jT809HeaderPackage.Header.EncryptKey);
            Assert.Equal((uint)20180920, jT809HeaderPackage.Header.MsgGNSSCENTERID);
            Assert.Equal(JT809BusinessType.主链路登录请求消息, (JT809BusinessType)jT809HeaderPackage.Header.BusinessType);
            Assert.Equal(new JT809Header_Version().ToString(), jT809HeaderPackage.Header.Version.ToString());
            JT809_0x1001 jT809_0X1001 = JT809Serializer.Deserialize<JT809_0x1001>(jT809HeaderPackage.Bodies);
            Assert.Equal((uint)20180920, jT809_0X1001.UserId);
            Assert.Equal("20180920", jT809_0X1001.Password);
            Assert.Equal("127.0.0.1", jT809_0X1001.DownLinkIP);
            Assert.Equal((ushort)809, jT809_0X1001.DownLinkPort);
        }
    }
}
