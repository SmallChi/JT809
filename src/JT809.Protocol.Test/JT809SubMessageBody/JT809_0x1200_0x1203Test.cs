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
using JT809.Protocol.Internal;
using JT809.Protocol.Metadata;

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x1200_0x1203Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
        [Fact]
        public void Test1()
        {
            JT809_0x1200_0x1203 jT809_0X1200_0X1203 = new JT809_0x1200_0x1203();
            jT809_0X1200_0X1203.GNSS = new List<JT809_0x1200_0x1202>();

            JT809_0x1200_0x1202 jT809_0X1200_0X1202_1 = new JT809_0x1200_0x1202();
            jT809_0X1200_0X1202_1.VehiclePosition = new  JT809VehiclePositionProperties
            {
                Day = 19,
                Month = 7,
                Year = 2012,
                Hour = 15,
                Minute = 15,
                Second = 15,
                Lon = 133123456,
                Lat = 24123456,
                Vec1 = 50,
                Vec2 = 51,
                Vec3 = 150,
                Direction = 45,
                Altitude = 45,
                State = 3,
                Alarm = 257,
            };

            JT809_0x1200_0x1202 jT809_0X1200_0X1202_2 = new JT809_0x1200_0x1202();
            jT809_0X1200_0X1202_2.VehiclePosition = new  JT809VehiclePositionProperties
            {
                Day = 19,
                Month = 7,
                Year = 2012,
                Hour = 16,
                Minute = 16,
                Second = 16,
                Lon = 133123456,
                Lat = 24123456,
                Vec1 = 50,
                Vec2 = 51,
                Vec3 = 150,
                Direction = 45,
                Altitude = 45,
                State = 3,
                Alarm = 257,
            };

            JT809_0x1200_0x1202 jT809_0X1200_0X1202_3 = new JT809_0x1200_0x1202();
            jT809_0X1200_0X1202_3.VehiclePosition = new  JT809VehiclePositionProperties
            {
                Day = 19,
                Month = 7,
                Year = 2012,
                Hour = 17,
                Minute = 17,
                Second = 17,
                Lon = 133123456,
                Lat = 24123456,
                Vec1 = 50,
                Vec2 = 51,
                Vec3 = 150,
                Direction = 45,
                Altitude = 45,
                State = 3,
                Alarm = 257,
            };


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

            var vehiclePosition1 = jT809_0X1200_0X1203.GNSS[0].VehiclePosition;
            var vehiclePosition2 = jT809_0X1200_0X1203.GNSS[1].VehiclePosition;
            var vehiclePosition3 = jT809_0X1200_0X1203.GNSS[2].VehiclePosition;
            Assert.Equal(19, vehiclePosition1.Day);
            Assert.Equal(7, vehiclePosition1.Month);
            Assert.Equal(2012, vehiclePosition1.Year);
            Assert.Equal(15, vehiclePosition1.Hour);
            Assert.Equal(15, vehiclePosition1.Minute);
            Assert.Equal(15, vehiclePosition1.Second);
            Assert.Equal((uint)133123456, vehiclePosition1.Lon);
            Assert.Equal((uint)24123456, vehiclePosition1.Lat);
            Assert.Equal(50, vehiclePosition1.Vec1);
            Assert.Equal(51, vehiclePosition1.Vec2);
            Assert.Equal((ushort)45, vehiclePosition1.Direction);
            Assert.Equal((ushort)45, vehiclePosition1.Altitude);
            Assert.Equal((uint)3, vehiclePosition1.State);
            Assert.Equal((uint)257, vehiclePosition1.Alarm);

            Assert.Equal(19, vehiclePosition2.Day);
            Assert.Equal(7, vehiclePosition2.Month);
            Assert.Equal(2012, vehiclePosition2.Year);
            Assert.Equal(16, vehiclePosition2.Hour);
            Assert.Equal(16, vehiclePosition2.Minute);
            Assert.Equal(16, vehiclePosition2.Second);
            Assert.Equal((uint)133123456, vehiclePosition2.Lon);
            Assert.Equal((uint)24123456, vehiclePosition2.Lat);
            Assert.Equal(50, vehiclePosition2.Vec1);
            Assert.Equal(51, vehiclePosition2.Vec2);
            Assert.Equal((ushort)45, vehiclePosition2.Direction);
            Assert.Equal((ushort)45, vehiclePosition2.Altitude);
            Assert.Equal((uint)3, vehiclePosition2.State);
            Assert.Equal((uint)257, vehiclePosition2.Alarm);

            Assert.Equal(19, vehiclePosition3.Day);
            Assert.Equal(7, vehiclePosition3.Month);
            Assert.Equal(2012, vehiclePosition3.Year);
            Assert.Equal(17, vehiclePosition3.Hour);
            Assert.Equal(17, vehiclePosition3.Minute);
            Assert.Equal(17, vehiclePosition3.Second);
            Assert.Equal((uint)133123456, vehiclePosition3.Lon);
            Assert.Equal((uint)24123456, vehiclePosition3.Lat);
            Assert.Equal(50, vehiclePosition3.Vec1);
            Assert.Equal(51, vehiclePosition3.Vec2);
            Assert.Equal((ushort)45, vehiclePosition3.Direction);
            Assert.Equal((ushort)45, vehiclePosition3.Altitude);
            Assert.Equal((uint)3, vehiclePosition3.State);
            Assert.Equal((uint)257, vehiclePosition3.Alarm);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x1200_0x1203 jT809_0X1200_0X1203 = new JT809_0x1200_0x1203();
            jT809_0X1200_0X1203.GNSS = new List<JT809_0x1200_0x1202>(){
                new JT809_0x1200_0x1202
                {
                    VehiclePosition_2019 = new  JT809VehiclePositionProperties_2019
                    {
                        Encrypt = JT809_VehiclePositionEncrypt.已加密,
                        PlatformId1 = "11111111111",
                        Alarm1 = 1,
                        PlatformId2 = "22222222222",
                        Alarm2 = 2,
                        PlatformId3 = "33333333333",
                        Alarm3 = 3,
                    }
                },
                new JT809_0x1200_0x1202{
                    VehiclePosition_2019=new JT809VehiclePositionProperties_2019{
                        Encrypt = JT809_VehiclePositionEncrypt.已加密,
                        PlatformId1 = "11111111111",
                        Alarm1 = 1,
                        PlatformId2 = "22222222222",
                        Alarm2 = 2,
                        PlatformId3 = "33333333333",
                        Alarm3 = 3,
                    }
                }
            };

            var hex = JT809_2019_Serializer.Serialize(jT809_0X1200_0X1203).ToHexString();
            Assert.Equal("0201000000003131313131313131313131000000013232323232323232323232000000023333333333333333333333000000030100000000313131313131313131313100000001323232323232323232323200000002333333333333333333333300000003", hex);

        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "0201000000003131313131313131313131000000013232323232323232323232000000023333333333333333333333000000030100000000313131313131313131313100000001323232323232323232323200000002333333333333333333333300000003".ToHexBytes();
            JT809_0x1200_0x1203 jT809_0X1200_0X1203 = JT809_2019_Serializer.Deserialize<JT809_0x1200_0x1203>(bytes);

            var vehiclePosition1 = jT809_0X1200_0X1203.GNSS[0].VehiclePosition_2019;
            var vehiclePosition2 = jT809_0X1200_0X1203.GNSS[1].VehiclePosition_2019;
            Assert.Equal(JT809_VehiclePositionEncrypt.已加密, vehiclePosition1.Encrypt);
            Assert.Equal("11111111111", vehiclePosition1.PlatformId1);
            Assert.Equal(1u, vehiclePosition1.Alarm1);
            Assert.Equal("22222222222", vehiclePosition1.PlatformId2);
            Assert.Equal(2u, vehiclePosition1.Alarm2);
            Assert.Equal("33333333333", vehiclePosition1.PlatformId3);
            Assert.Equal(3u, vehiclePosition1.Alarm3);

            Assert.Equal(JT809_VehiclePositionEncrypt.已加密, vehiclePosition2.Encrypt);
            Assert.Equal("11111111111", vehiclePosition2.PlatformId1);
            Assert.Equal(1u, vehiclePosition2.Alarm1);
            Assert.Equal("22222222222", vehiclePosition2.PlatformId2);
            Assert.Equal(2u, vehiclePosition2.Alarm2);
            Assert.Equal("33333333333", vehiclePosition2.PlatformId3);
            Assert.Equal(3u, vehiclePosition2.Alarm3);
        }
    }
}
