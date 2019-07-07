using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.SubMessageBody;
using JT809.Protocol.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol.Enums;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public class JT809_0x1200Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809_0x1200 jT809_0X1200 = new JT809_0x1200();
            jT809_0X1200.VehicleNo= "粤A12345";
            jT809_0X1200.VehicleColor = JT809VehicleColorType.蓝色;
            jT809_0X1200.SubBusinessType = JT809SubBusinessType.上传车辆注册信息.ToUInt16Value();
            jT809_0X1200.DataLength = 61;
            JT809_0x1200_0x1201 jT809_0X1200_0X1201 = new JT809_0x1200_0x1201
            {
                PlateformId = "1111111111",
                ProducerId = "1111111111",
                TerminalId = "11111AA",
                TerminalModelType = "11111111",
                TerminalSimCode = "222222222222"
            };
            jT809_0X1200.SubBodies = jT809_0X1200_0X1201;
            var hex = JT809Serializer.Serialize(jT809_0X1200).ToHexString();
            //D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 
            //00 
            //01 
            //12 01 
            //00 00 00 3D
            //00 00 00 00 00 00 00 42 3A 35 C7
            //00 00 00 00 00 00 00 42 3A 35 C7 31 31 31 31 31 31 31 31 
            //00 00 00 00 00 00 00 00 00 00 00 00 31 31 31 31 31 41 41 32 32 32 32 32 32 32 32 32 32 32 32
            //D4C1413132333435000000000000000000000000000112010000003D00000000000000423A35C700000000000000423A35C7313131313131313100000000000000000000000031313131314141323232323232323232323232
            Assert.Equal("D4C1413132333435000000000000000000000000000112010000003D00000000000000423A35C700000000000000423A35C7313131313131313100000000000000000000000031313131314141323232323232323232323232", hex);
            //"D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 01 12 01 00 00 00 3D 00 00 00 00 00 00 00 42 3A 35 C7 00 00 00 00 00 00 00 42 3A 35 C7 31 31 31 31 31 31 31 31 00 00 00 00 00 00 00 00 00 00 00 00 31 31 31 31 31 41 41 32 32 32 32 32 32 32 32 32 32 32 32"
            //"D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 01 12 01 00 00 00 3D 00 00 00 00 00 00 00 42 3A 35 C7 00 00 00 00 00 00 00 42 3A 35 C7 31 31 31 31 31 31 31 31 00 00 00 00 00 00 00 00 00 00 00 00 31 31 31 31 31 61 61 32 32 32 32 32 32 32 32 32 32 32 32"
        }

        [Fact]
        public void Test2()
        {
            var bytes = "D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 01 12 01 00 00 00 3D 00 00 00 00 00 00 00 42 3A 35 C7 00 00 00 00 00 00 00 42 3A 35 C7 31 31 31 31 31 31 31 31 00 00 00 00 00 00 00 00 00 00 00 00 31 31 31 31 31 41 41 32 32 32 32 32 32 32 32 32 32 32 32".ToHexBytes();
            JT809_0x1200 jT809_0X9001 = JT809Serializer.Deserialize<JT809_0x1200>(bytes);
            Assert.Equal("粤A12345", jT809_0X9001.VehicleNo);
            Assert.Equal(JT809VehicleColorType.蓝色, jT809_0X9001.VehicleColor);
            Assert.Equal(JT809SubBusinessType.上传车辆注册信息, (JT809SubBusinessType)jT809_0X9001.SubBusinessType);
            Assert.Equal((ushort)61, jT809_0X9001.DataLength);
            JT809_0x1200_0x1201 jT809_0X1200_0X1201 = jT809_0X9001.SubBodies as JT809_0x1200_0x1201;
            Assert.Equal("1111111111", jT809_0X1200_0X1201.PlateformId);
            Assert.Equal("1111111111", jT809_0X1200_0X1201.ProducerId);
            Assert.Equal("11111AA", jT809_0X1200_0X1201.TerminalId);
            Assert.Equal("11111111", jT809_0X1200_0X1201.TerminalModelType);
            Assert.Equal("222222222222", jT809_0X1200_0X1201.TerminalSimCode);
        }
    }
}
