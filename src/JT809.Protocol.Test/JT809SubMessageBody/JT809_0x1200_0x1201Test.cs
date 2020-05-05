using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using JT809.Protocol.SubMessageBody;
using JT809.Protocol.Internal;
using JT809.Protocol.Enums;

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x1200_0x1201Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();

        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() {  Version= JT809Version.JTT2019});

        [Fact]
        public void Test1()
        {
            JT809_0x1200_0x1201 jT809_0X1200_0X1201 = new JT809_0x1200_0x1201
            {
                 PlateformId= "1111111111",
                 ProducerId= "1111111111",
                 TerminalId= "11111AA",
                 TerminalModelType= "11111111",
                 TerminalSimCode= "222222222222"
            };
            var hex = JT809Serializer.Serialize(jT809_0X1200_0X1201).ToHexString();
            //"00 00 00 00 00 00 00 42 3A 35 C7 00 00 00 00 00 00 00 42 3A 35 C7 31 31 31 31 31 31 31 31 00 00 00 00 00 00 00 00 00 00 00 00 31 31 31 31 31 41 41 32 32 32 32 32 32 32 32 32 32 32 32"
            Assert.Equal("31313131313131313131003131313131313131313100313131313131313100000000000000000000000031313131314141323232323232323232323232", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "31313131313131313131003131313131313131313100313131313131313100000000000000000000000031313131314141323232323232323232323232".ToHexBytes();
            JT809_0x1200_0x1201 jT809_0X1200_0X1201 = JT809Serializer.Deserialize<JT809_0x1200_0x1201>(bytes);
            Assert.Equal("1111111111", jT809_0X1200_0X1201.PlateformId);
            Assert.Equal("1111111111", jT809_0X1200_0X1201.ProducerId);
            Assert.Equal("11111AA", jT809_0X1200_0X1201.TerminalId);
            Assert.Equal("11111111", jT809_0X1200_0X1201.TerminalModelType);
            Assert.Equal("222222222222", jT809_0X1200_0X1201.TerminalSimCode);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x1200_0x1201 jT809_0X1200_0X1201 = new JT809_0x1200_0x1201
            {
                PlateformId = "1111111111",
                ProducerId = "1111111111",
                TerminalId = "11111AA",
                TerminalModelType = "11111111",
                TerminalSimCode = "222222222222",
                IMIEId="123456789"
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0X1200_0X1201).ToHexString();
            Assert.Equal("3131313131313131313100313131313131313131310031313131313131310000000000000000000000000000000000000000000031323334353637383900000000000031313131314141000000000000000000000000000000000000000000000032323232323232323232323200", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "3131313131313131313100313131313131313131310031313131313131310000000000000000000000000000000000000000000031323334353637383900000000000031313131314141000000000000000000000000000000000000000000000032323232323232323232323200".ToHexBytes();
            JT809_0x1200_0x1201 jT809_0X1200_0X1201 = JT809_2019_Serializer.Deserialize<JT809_0x1200_0x1201>(bytes);
            Assert.Equal("1111111111", jT809_0X1200_0X1201.PlateformId);
            Assert.Equal("1111111111", jT809_0X1200_0X1201.ProducerId);
            Assert.Equal("11111AA", jT809_0X1200_0X1201.TerminalId);
            Assert.Equal("11111111", jT809_0X1200_0X1201.TerminalModelType);
            Assert.Equal("222222222222", jT809_0X1200_0X1201.TerminalSimCode);
            Assert.Equal("123456789", jT809_0X1200_0X1201.IMIEId);
        }

        [Fact]
        public void Test_2019_3()
        {
            JT809Package jT809Package = new JT809Package();
            jT809Package.Header = new JT809Header
            {
                MsgSN = 1666,
                EncryptKey = 9999,
                EncryptFlag = JT809Header_Encrypt.None,
                Version = new JT809Header_Version(1, 0, 0),
                BusinessType = JT809BusinessType.主链路车辆动态信息交换业务.ToUInt16Value(),
                MsgGNSSCENTERID = 20190708,
                Time = DateTime.Parse("2020-04-26 12:02:00")
            };
            JT809_0x1200 jT809_0X1200 = new JT809_0x1200();
            jT809_0X1200.VehicleNo = "粤A12345";
            jT809_0X1200.VehicleColor = JT809VehicleColorType.蓝色;
            jT809_0X1200.SubBusinessType = JT809SubBusinessType.上传车辆注册信息.ToUInt16Value();
            jT809_0X1200.DataLength = 110;
            JT809_0x1200_0x1201 jT809_0X1200_0X1201 = new JT809_0x1200_0x1201
            {
                PlateformId = "1111111111",
                ProducerId = "1111111111",
                TerminalId = "11111AA",
                TerminalModelType = "11111111",
                TerminalSimCode = "222222222222",
                IMIEId = "123456789"
            };
            jT809_0X1200.SubBodies = jT809_0X1200_0X1201;
            jT809Package.Bodies = jT809_0X1200;

            var hex = JT809_2019_Serializer.Serialize(jT809Package).ToHexString();
            Assert.Equal("5B000000AC000006821200013415F4010000000000270F000000005E02A507B8D4C1413132333435000000000000000000000000000112010000006E31313131313131313131003131313131313131313100313131313131313100000000000000000000000000000000000000000000313233343536373839000000000000313131313141410000000000000000000000000000000000000000000000323232323232323232323232006D7A5D", hex);
        }

        [Fact]
        public void Test_2019_4()
        {
            var bytes = "5B000000AC000006821200013415F4010000000000270F000000005E02A507B8D4C1413132333435000000000000000000000000000112010000006E31313131313131313131003131313131313131313100313131313131313100000000000000000000000000000000000000000000313233343536373839000000000000313131313141410000000000000000000000000000000000000000000000323232323232323232323232006D7A5D".ToHexBytes();
            var package = JT809_2019_Serializer.Deserialize<JT809Package>(bytes);
            JT809_0x1200 jT809_0X9001 = package.Bodies as JT809_0x1200;
            Assert.Equal("粤A12345", jT809_0X9001.VehicleNo);
            Assert.Equal(JT809VehicleColorType.蓝色, jT809_0X9001.VehicleColor);
            Assert.Equal(JT809SubBusinessType.上传车辆注册信息, (JT809SubBusinessType)jT809_0X9001.SubBusinessType);
            Assert.Equal(110u, jT809_0X9001.DataLength);

            JT809_0x1200_0x1201 jT809_0X1200_0X1201 = jT809_0X9001.SubBodies as JT809_0x1200_0x1201;
            Assert.Equal("1111111111", jT809_0X1200_0X1201.PlateformId);
            Assert.Equal("1111111111", jT809_0X1200_0X1201.ProducerId);
            Assert.Equal("11111AA", jT809_0X1200_0X1201.TerminalId);
            Assert.Equal("11111111", jT809_0X1200_0X1201.TerminalModelType);
            Assert.Equal("222222222222", jT809_0X1200_0X1201.TerminalSimCode);
            Assert.Equal("123456789", jT809_0X1200_0X1201.IMIEId);
        }


    }
}
