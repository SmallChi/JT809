using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol.SubMessageBody;
using JT809.Protocol.Enums;
using JT809.Protocol.Internal;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public class JT809_0x1600Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });

        [Fact]
        public void Test1()
        {
            JT809_0x1600 jT809Bodies = new JT809_0x1600();
            jT809Bodies.VehicleNo = "粤A12345";
            jT809Bodies.VehicleColor = JT809VehicleColorType.蓝色;
            jT809Bodies.SubBusinessType = JT809SubBusinessType.补报车辆静态信息应答.ToUInt16Value();
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
            Assert.Equal(JT809VehicleColorType.蓝色, jT809Bodies.VehicleColor);
            Assert.Equal(JT809SubBusinessType.补报车辆静态信息应答, (JT809SubBusinessType)jT809Bodies.SubBusinessType);
            Assert.Equal("什么鬼", ((JT809_0x1600_0x1601)jT809Bodies.SubBodies).CarInfo);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x1600 jT809Bodies = new JT809_0x1600();
            jT809Bodies.VehicleNo = "粤A12345";
            jT809Bodies.VehicleColor = JT809VehicleColorType.蓝色;
            jT809Bodies.SubBusinessType = JT809SubBusinessType.补报车辆静态信息应答.ToUInt16Value();
            jT809Bodies.SubBodies = new JT809_0x1600_0x1601
            {
                SourceDataType = 1,
                SourceMsgSn = 2,
                CarInfo = "什么鬼"
            };
            var hex = JT809_2019_Serializer.Serialize(jT809Bodies).ToHexString();
            Assert.Equal("D4C1413132333435000000000000000000000000000116010000000C000100000002CAB2C3B4B9ED", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "D4C1413132333435000000000000000000000000000116010000000C000100000002CAB2C3B4B9ED".ToHexBytes();
            JT809_0x1600 jT809Bodies = JT809_2019_Serializer.Deserialize<JT809_0x1600>(bytes);
            Assert.Equal("粤A12345", jT809Bodies.VehicleNo);
            Assert.Equal(JT809VehicleColorType.蓝色, jT809Bodies.VehicleColor);
            Assert.Equal(JT809SubBusinessType.补报车辆静态信息应答, (JT809SubBusinessType)jT809Bodies.SubBusinessType);
            Assert.Equal("什么鬼", ((JT809_0x1600_0x1601)jT809Bodies.SubBodies).CarInfo);
            Assert.Equal(2u, ((JT809_0x1600_0x1601)jT809Bodies.SubBodies).SourceMsgSn);
            Assert.Equal(1, ((JT809_0x1600_0x1601)jT809Bodies.SubBodies).SourceDataType);
        }
    }
}
