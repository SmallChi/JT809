using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809MessageBody;
using JT809.Protocol.JT809Exceptions;
using JT809.Protocol.JT809SubMessageBody;

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x1200_0x1203Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x1200_0x1203 jT809_0X1200_0X1203 = new JT809_0x1200_0x1203();
            jT809_0X1200_0X1203.GNSS = new List<JT809_0x1200_0x1202>();

            JT809_0x1200_0x1202 jT809_0X1200_0X1202_1 = new JT809_0x1200_0x1202();
            jT809_0X1200_0X1202_1.VehiclePosition.Day = 19;
            jT809_0X1200_0X1202_1.VehiclePosition.Month = 7;
            jT809_0X1200_0X1202_1.VehiclePosition.Year = 2012;
            jT809_0X1200_0X1202_1.VehiclePosition.Hour = 15;
            jT809_0X1200_0X1202_1.VehiclePosition.Minute = 15;
            jT809_0X1200_0X1202_1.VehiclePosition.Second = 15;
            jT809_0X1200_0X1202_1.VehiclePosition.Lon = 133123456;
            jT809_0X1200_0X1202_1.VehiclePosition.Lat = 24123456;
            jT809_0X1200_0X1202_1.VehiclePosition.Vec1 = 50;
            jT809_0X1200_0X1202_1.VehiclePosition.Vec2 = 51;
            jT809_0X1200_0X1202_1.VehiclePosition.Vec3 = 150;
            jT809_0X1200_0X1202_1.VehiclePosition.Direction = 45;
            jT809_0X1200_0X1202_1.VehiclePosition.Altitude = 45;
            jT809_0X1200_0X1202_1.VehiclePosition.State = 3;
            jT809_0X1200_0X1202_1.VehiclePosition.Alarm = 257;

            JT809_0x1200_0x1202 jT809_0X1200_0X1202_2 = new JT809_0x1200_0x1202();
            jT809_0X1200_0X1202_2.VehiclePosition.Day = 19;
            jT809_0X1200_0X1202_2.VehiclePosition.Month = 7;
            jT809_0X1200_0X1202_2.VehiclePosition.Year = 2012;
            jT809_0X1200_0X1202_2.VehiclePosition.Hour = 16;
            jT809_0X1200_0X1202_2.VehiclePosition.Minute = 16;
            jT809_0X1200_0X1202_2.VehiclePosition.Second = 16;
            jT809_0X1200_0X1202_2.VehiclePosition.Lon = 133123456;
            jT809_0X1200_0X1202_2.VehiclePosition.Lat = 24123456;
            jT809_0X1200_0X1202_2.VehiclePosition.Vec1 = 50;
            jT809_0X1200_0X1202_2.VehiclePosition.Vec2 = 51;
            jT809_0X1200_0X1202_2.VehiclePosition.Vec3 = 150;
            jT809_0X1200_0X1202_2.VehiclePosition.Direction = 45;
            jT809_0X1200_0X1202_2.VehiclePosition.Altitude = 45;
            jT809_0X1200_0X1202_2.VehiclePosition.State = 3;
            jT809_0X1200_0X1202_2.VehiclePosition.Alarm = 257;

            JT809_0x1200_0x1202 jT809_0X1200_0X1202_3 = new JT809_0x1200_0x1202();
            jT809_0X1200_0X1202_3.VehiclePosition.Day = 19;
            jT809_0X1200_0X1202_3.VehiclePosition.Month = 7;
            jT809_0X1200_0X1202_3.VehiclePosition.Year = 2012;
            jT809_0X1200_0X1202_3.VehiclePosition.Hour = 17;
            jT809_0X1200_0X1202_3.VehiclePosition.Minute = 17;
            jT809_0X1200_0X1202_3.VehiclePosition.Second = 17;
            jT809_0X1200_0X1202_3.VehiclePosition.Lon = 133123456;
            jT809_0X1200_0X1202_3.VehiclePosition.Lat = 24123456;
            jT809_0X1200_0X1202_3.VehiclePosition.Vec1 = 50;
            jT809_0X1200_0X1202_3.VehiclePosition.Vec2 = 51;
            jT809_0X1200_0X1202_3.VehiclePosition.Vec3 = 150;
            jT809_0X1200_0X1202_3.VehiclePosition.Direction = 45;
            jT809_0X1200_0X1202_3.VehiclePosition.Altitude = 45;
            jT809_0X1200_0X1202_3.VehiclePosition.State = 3;
            jT809_0X1200_0X1202_3.VehiclePosition.Alarm = 257;


            jT809_0X1200_0X1203.GNSS.Add(jT809_0X1200_0X1202_1);
            jT809_0X1200_0X1203.GNSS.Add(jT809_0X1200_0X1202_2);
            jT809_0X1200_0X1203.GNSS.Add(jT809_0X1200_0X1202_3);

            var hex = JT809Serializer.Serialize(jT809_0X1200_0X1203).ToHexString();
            //"03 00 13 07 07 DC 0F 0F 0F 07 EF 4D 80 01 70 18 40 00 32 00 33 00 00 00 96 00 2D 00 2D 00 00 00 03 00 00 01 01 00 13 07 07 DC 10 10 10 07 EF 4D 80 01 70 18 40 00 32 00 33 00 00 00 96 00 2D 00 2D 00 00 00 03 00 00 01 01 00 13 07 07 DC 11 11 11 07 EF 4D 80 01 70 18 40 00 32 00 33 00 00 00 96 00 2D 00 2D 00 00 00 03 00 00 01 01"
            Assert.Equal("0300130707DC0F0F0F07EF4D80017018400032003300000096002D002D000000030000010100130707DC10101007EF4D80017018400032003300000096002D002D000000030000010100130707DC11111107EF4D80017018400032003300000096002D002D0000000300000101", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "03 00 13 07 07 DC 0F 0F 0F 07 EF 4D 80 01 70 18 40 00 32 00 33 00 00 00 96 00 2D 00 2D 00 00 00 03 00 00 01 01 00 13 07 07 DC 10 10 10 07 EF 4D 80 01 70 18 40 00 32 00 33 00 00 00 96 00 2D 00 2D 00 00 00 03 00 00 01 01 00 13 07 07 DC 11 11 11 07 EF 4D 80 01 70 18 40 00 32 00 33 00 00 00 96 00 2D 00 2D 00 00 00 03 00 00 01 01".ToHexBytes();
            JT809_0x1200_0x1203 jT809_0X1200_0X1203 = JT809Serializer.Deserialize<JT809_0x1200_0x1203>(bytes);

            Assert.Equal(3, jT809_0X1200_0X1203.GNSSCount);


            Assert.Equal(19, jT809_0X1200_0X1203.GNSS[0].VehiclePosition.Day);
            Assert.Equal(7, jT809_0X1200_0X1203.GNSS[0].VehiclePosition.Month);
            Assert.Equal(2012, jT809_0X1200_0X1203.GNSS[0].VehiclePosition.Year);
            Assert.Equal(15, jT809_0X1200_0X1203.GNSS[0].VehiclePosition.Hour);
            Assert.Equal(15, jT809_0X1200_0X1203.GNSS[0].VehiclePosition.Minute);
            Assert.Equal(15, jT809_0X1200_0X1203.GNSS[0].VehiclePosition.Second);
            Assert.Equal((uint)133123456, jT809_0X1200_0X1203.GNSS[0].VehiclePosition.Lon);
            Assert.Equal((uint)24123456, jT809_0X1200_0X1203.GNSS[0].VehiclePosition.Lat);
            Assert.Equal(50, jT809_0X1200_0X1203.GNSS[0].VehiclePosition.Vec1);
            Assert.Equal(51, jT809_0X1200_0X1203.GNSS[0].VehiclePosition.Vec2);
            Assert.Equal((ushort)45, jT809_0X1200_0X1203.GNSS[0].VehiclePosition.Direction);
            Assert.Equal((ushort)45, jT809_0X1200_0X1203.GNSS[0].VehiclePosition.Altitude);
            Assert.Equal((uint)3, jT809_0X1200_0X1203.GNSS[0].VehiclePosition.State);
            Assert.Equal((uint)257, jT809_0X1200_0X1203.GNSS[0].VehiclePosition.Alarm);

            Assert.Equal(19, jT809_0X1200_0X1203.GNSS[1].VehiclePosition.Day);
            Assert.Equal(7, jT809_0X1200_0X1203.GNSS[1].VehiclePosition.Month);
            Assert.Equal(2012, jT809_0X1200_0X1203.GNSS[1].VehiclePosition.Year);
            Assert.Equal(16, jT809_0X1200_0X1203.GNSS[1].VehiclePosition.Hour);
            Assert.Equal(16, jT809_0X1200_0X1203.GNSS[1].VehiclePosition.Minute);
            Assert.Equal(16, jT809_0X1200_0X1203.GNSS[1].VehiclePosition.Second);
            Assert.Equal((uint)133123456, jT809_0X1200_0X1203.GNSS[1].VehiclePosition.Lon);
            Assert.Equal((uint)24123456, jT809_0X1200_0X1203.GNSS[1].VehiclePosition.Lat);
            Assert.Equal(50, jT809_0X1200_0X1203.GNSS[1].VehiclePosition.Vec1);
            Assert.Equal(51, jT809_0X1200_0X1203.GNSS[1].VehiclePosition.Vec2);
            Assert.Equal((ushort)45, jT809_0X1200_0X1203.GNSS[1].VehiclePosition.Direction);
            Assert.Equal((ushort)45, jT809_0X1200_0X1203.GNSS[1].VehiclePosition.Altitude);
            Assert.Equal((uint)3, jT809_0X1200_0X1203.GNSS[1].VehiclePosition.State);
            Assert.Equal((uint)257, jT809_0X1200_0X1203.GNSS[1].VehiclePosition.Alarm);

            Assert.Equal(19, jT809_0X1200_0X1203.GNSS[2].VehiclePosition.Day);
            Assert.Equal(7, jT809_0X1200_0X1203.GNSS[2].VehiclePosition.Month);
            Assert.Equal(2012, jT809_0X1200_0X1203.GNSS[2].VehiclePosition.Year);
            Assert.Equal(17, jT809_0X1200_0X1203.GNSS[2].VehiclePosition.Hour);
            Assert.Equal(17, jT809_0X1200_0X1203.GNSS[2].VehiclePosition.Minute);
            Assert.Equal(17, jT809_0X1200_0X1203.GNSS[2].VehiclePosition.Second);
            Assert.Equal((uint)133123456, jT809_0X1200_0X1203.GNSS[2].VehiclePosition.Lon);
            Assert.Equal((uint)24123456, jT809_0X1200_0X1203.GNSS[2].VehiclePosition.Lat);
            Assert.Equal(50, jT809_0X1200_0X1203.GNSS[2].VehiclePosition.Vec1);
            Assert.Equal(51, jT809_0X1200_0X1203.GNSS[2].VehiclePosition.Vec2);
            Assert.Equal((ushort)45, jT809_0X1200_0X1203.GNSS[2].VehiclePosition.Direction);
            Assert.Equal((ushort)45, jT809_0X1200_0X1203.GNSS[2].VehiclePosition.Altitude);
            Assert.Equal((uint)3, jT809_0X1200_0X1203.GNSS[2].VehiclePosition.State);
            Assert.Equal((uint)257, jT809_0X1200_0X1203.GNSS[2].VehiclePosition.Alarm);
        }
    }
}
