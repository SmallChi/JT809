using JT808.Protocol.Extensions;
using JT809.Protocol.Enums;
using JT809.Protocol.Internal;
using JT809.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public class JT809_0x1102Test
    {
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
        [Fact]
        public void Test1()
        {
            var bytes = "5B0000004C000000011102000027660000000000000000000000005F0596041102000000243330303030313233343500000000005F059604000000005F059604000000000A0000001E17B45D".ToHexBytes();
            JT809Package jT809Package = JT809_2019_Serializer.Deserialize(bytes);

            Assert.Equal((uint)1, jT809Package.Header.MsgSN);
            Assert.Equal((ushort)0x1102, jT809Package.Header.BusinessType);
            Assert.Equal((uint)10086, jT809Package.Header.MsgGNSSCENTERID);
            Assert.Equal((uint)76, jT809Package.Header.MsgLength);
            Assert.Equal("0.0.0", jT809Package.Header.Version.ToString());
            Assert.Equal(DateTime.Parse("2020-07-08 17:46:44"), jT809Package.Header.Time);

            var body = jT809Package.Bodies as JT809_0x1102;
            Assert.NotNull(body);
            Assert.Equal((ushort)0x1102, body.MsgId);
            Assert.Equal((uint)36, body.DataLength);
            Assert.Equal("3000012345", body.PlateformId);
            Assert.Equal(DateTime.Parse("2020-07-08 17:46:44"), body.StartTime);
            Assert.Equal(DateTime.Parse("2020-07-08 17:46:44"), body.EndTime);
            Assert.Equal((uint)0, body.LoseDymamicSum);
            Assert.Equal((byte)10, body.DisconnectNum);
            Assert.Equal((uint)30, body.DisconnectTime);
        }

        [Fact]
        public void Test2()
        {
            var package = new JT809Package
            {
                Header = new JT809Header
                {
                    BusinessType = 0x1102,
                    MsgGNSSCENTERID = 10086,
                    Time = DateTime.Parse("2020-07-08 17:46:44"),
                    Version = new JT809Header_Version(0, 0, 0),
                },
                Bodies = new JT809_0x1102
                {
                    SubBusinessType = 0x1102,
                    PlateformId = "3000012345",
                    StartTime = DateTime.Parse("2020-07-08 17:46:44"),
                    EndTime = DateTime.Parse("2020-07-08 17:46:44"),
                    LoseDymamicSum = 0,
                    DisconnectNum = 10,
                    DisconnectTime = 30,
                }
            };
            Assert.Equal("5B0000004C000000011102000027660000000000000000000000005F0596041102000000243330303030313233343500000000005F059604000000005F059604000000000A0000001E17B45D", JT809_2019_Serializer.Serialize(package).ToHexString());
        }
    }
}
