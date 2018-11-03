using JT809.Protocol;
using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809MessageBody;
using JT809.Protocol.JT809Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol.JT809SubMessageBody;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public class JT809_0x1600Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x1600 jT809Bodies = new JT809_0x1600();
            jT809Bodies.VehicleNo = "粤A12345";
            jT809Bodies.VehicleColor = JT809Enums.JT809VehicleColorType.蓝色;
            jT809Bodies.SubBusinessType = JT809Enums.JT809SubBusinessType.补报车辆静态信息应答;
            jT809Bodies.SubBodies = new JT809_0x1600_0x1601
            {
                CarInfo = "什么鬼"
            };
            var hex = JT809Serializer.Serialize(jT809Bodies).ToHexString();
            //"D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 01 16 01 00 00 00 06 CA B2 C3 B4 B9 ED"
            Assert.Equal("D4C14131323334350000000000000000000000000001160100000006CAB2C3B4B9ED",hex);            
        }

        [Fact]
        public void Test2()
        {
            var bytes = "D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 01 16 01 00 00 00 06 CA B2 C3 B4 B9 ED".ToHexBytes();
            JT809_0x1600 jT809Bodies = JT809Serializer.Deserialize<JT809_0x1600>(bytes);
            Assert.Equal("粤A12345", jT809Bodies.VehicleNo);
            Assert.Equal(JT809Enums.JT809VehicleColorType.蓝色, jT809Bodies.VehicleColor);
            Assert.Equal(JT809Enums.JT809SubBusinessType.补报车辆静态信息应答, jT809Bodies.SubBusinessType);
            Assert.Equal("什么鬼", ((JT809_0x1600_0x1601)jT809Bodies.SubBodies).CarInfo);
        }
    }
}
