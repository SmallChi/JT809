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
    public class JT809_0x9500_0x9505Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809_0x9500_0x9505 jT809_0X9500_0X9505 = new JT809_0x9500_0x9505
            {
                 AuthenticationCode= "808",
                 AccessPointName= "jt808",
                 UserName = "adslsmallchi",
                 Password= "adsl123",
                 ServerIP= "127.0.0.1",
                 TcpPort=808,
                 UdpPort=809,
                 EndTime=DateTime.Parse("2018-09-27 20:00:00")
            };
            var hex = JT809Serializer.Serialize(jT809_0X9500_0X9505).ToHexString();
            Assert.Equal("000000000000000008086A743830380000000000000000000000000000006164736C736D616C6C636869000000000000000000000000000000000000000000000000000000000000000000000000006164736C3132330000000000000000000000000000003132372E302E302E31000000000000000000000000000000000000000000000003280329000000005BACC640", hex);
            //"00 00 00 00 00 00 00 00 08 08 6A 74 38 30 38 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 61 64 73 6C 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 61 64 73 6C 31 32 33 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 03 28 03 29 00 00 00 00 5B AC C6 40"
            //"00 00 00 00 00 00 00 00 08 08 6A 74 38 30 38 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 61 64 73 6C 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 61 64 73 6C 31 32 33 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 03 28 03 29 00 00 00 00 5A 01 AC C6 40"
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00 00 00 00 00 00 00 00 08 08 6A 74 38 30 38 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 61 64 73 6C 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 61 64 73 6C 31 32 33 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 03 28 03 29 00 00 00 00 5B AC C6 40".ToHexBytes();
            JT809_0x9500_0x9505 jT809_0X9500_0X9505 = JT809Serializer.Deserialize<JT809_0x9500_0x9505>(bytes);
            Assert.Equal("00000000000000000808", jT809_0X9500_0X9505.AuthenticationCode);
            Assert.Equal("jt808", jT809_0X9500_0X9505.AccessPointName);
            Assert.Equal("adslsmallchi", jT809_0X9500_0X9505.UserName);
            Assert.Equal("adsl123", jT809_0X9500_0X9505.Password);
            Assert.Equal("127.0.0.1", jT809_0X9500_0X9505.ServerIP);
            Assert.Equal(808, jT809_0X9500_0X9505.TcpPort);
            Assert.Equal(809, jT809_0X9500_0X9505.UdpPort);
            Assert.Equal(DateTime.Parse("2018-09-27 20:00:00"), jT809_0X9500_0X9505.EndTime);
        }
    }
}
