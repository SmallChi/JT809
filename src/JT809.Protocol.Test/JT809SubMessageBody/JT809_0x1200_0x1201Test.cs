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
            Assert.Equal("00000000000000423A35C700000000000000423A35C7313131313131313100000000000000000000000031313131314141323232323232323232323232",hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00 00 00 00 00 00 00 42 3A 35 C7 00 00 00 00 00 00 00 42 3A 35 C7 31 31 31 31 31 31 31 31 00 00 00 00 00 00 00 00 00 00 00 00 31 31 31 31 31 41 41 32 32 32 32 32 32 32 32 32 32 32 32".ToHexBytes();
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
            Assert.Equal("00000000000000423A35C700000000000000423A35C731313131313131310000000000000000000000000000000000000000000031323334353637383900000000000031313131314141000000000000000000000000000000000000000000000000323232323232323232323232", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "00000000000000423A35C700000000000000423A35C731313131313131310000000000000000000000000000000000000000000031323334353637383900000000000031313131314141000000000000000000000000000000000000000000000000323232323232323232323232".ToHexBytes();
            JT809_0x1200_0x1201 jT809_0X1200_0X1201 = JT809_2019_Serializer.Deserialize<JT809_0x1200_0x1201>(bytes);
            Assert.Equal("1111111111", jT809_0X1200_0X1201.PlateformId);
            Assert.Equal("1111111111", jT809_0X1200_0X1201.ProducerId);
            Assert.Equal("11111AA", jT809_0X1200_0X1201.TerminalId);
            Assert.Equal("11111111", jT809_0X1200_0X1201.TerminalModelType);
            Assert.Equal("222222222222", jT809_0X1200_0X1201.TerminalSimCode);
            Assert.Equal("123456789", jT809_0X1200_0X1201.IMIEId);
        }
    }
}
