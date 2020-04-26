using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Internal;
using JT809.Protocol.Enums;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public class JT809_0x1001Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();

        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });

        [Fact]
        public void Test1()
        {
            JT809_0x1001 jT809_0X1001 = new JT809_0x1001();
            jT809_0X1001.UserId = 20180920;
            jT809_0X1001.Password = "20180920";
            jT809_0X1001.DownLinkIP = "127.0.0.1";
            jT809_0X1001.DownLinkPort = 809;
            var hex = JT809Serializer.Serialize(jT809_0X1001).ToHexString();
            Assert.Equal("0133EFB832303138303932303132372E302E302E3100000000000000000000000000000000000000000000000329", hex);
            //5B 
            //00 00 00 48 
            //00 00 00 85 
            //10 01 
            //01 33 53 D5 
            //01 00 00 
            //00 
            //00 00 27 0F 

            //01 33 EF B8 
            //32 30 31 38 30 39 32 30 
            //31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
            //03 29 
            //C3 0D 
            //5D

            //"01 33 EF B8 
            //32 30 31 38 30 39 32 30 
            //31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
            //03 29"
        }

        [Fact]
        public void Test2()
        {
            var bytes = "01 33 EF B8 32 30 31 38 30 39 32 30 31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 03 29".ToHexBytes();
            JT809_0x1001 jT809_0X1001 = JT809Serializer.Deserialize<JT809_0x1001>(bytes);
            Assert.Equal((uint)20180920, jT809_0X1001.UserId);
            Assert.Equal("20180920", jT809_0X1001.Password);
            Assert.Equal("127.0.0.1", jT809_0X1001.DownLinkIP);
            Assert.Equal((ushort)809,jT809_0X1001.DownLinkPort);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x1001 jT809_0X1001 = new JT809_0x1001();
            jT809_0X1001.UserId = 20180920;
            jT809_0X1001.Password = "20180920";
            jT809_0X1001.MsgGNSSCENTERID = 44555555;
            jT809_0X1001.DownLinkIP = "127.0.0.1";
            jT809_0X1001.DownLinkPort = 809;
            var hex = JT809_2019_Serializer.Serialize(jT809_0X1001).ToHexString();
            Assert.Equal("0133EFB8323031383039323002A7DD233132372E302E302E3100000000000000000000000000000000000000000000000329", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "0133EFB8323031383039323002A7DD233132372E302E302E3100000000000000000000000000000000000000000000000329".ToHexBytes();
            JT809_0x1001 jT809_0X1001 = JT809_2019_Serializer.Deserialize<JT809_0x1001>(bytes);
            Assert.Equal(20180920u, jT809_0X1001.UserId);
            Assert.Equal("20180920", jT809_0X1001.Password);
            Assert.Equal("127.0.0.1", jT809_0X1001.DownLinkIP);
            Assert.Equal(809u, jT809_0X1001.DownLinkPort);
            Assert.Equal(44555555u, jT809_0X1001.MsgGNSSCENTERID);
        }
    }
}
