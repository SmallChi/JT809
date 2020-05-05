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

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x9500_0x9504Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
        [Fact]
        public void Test1()
        {
            JT809_0x9500_0x9504 jT809_0X9500_0X9504 = new JT809_0x9500_0x9504
            {
                  Command= JT809CommandType.采集记录仪事故疑点记录,
                  StartTime=DateTime.Parse("2018-09-27 20:00:20"),
                  EndTime=DateTime.Parse("2018-09-27 23:00:20"),
                  Max=5556
            };
            var hex = JT809Serializer.Serialize(jT809_0X9500_0X9504).ToHexString();
            //"10 18 09 27 20 00 20 18 09 27 23 00 20 15 B4"
            //"10 18 09 27 20 00 20 18 09 27 23 00 20 15 B4"
            Assert.Equal("1018092720002018092723002015B4",hex);
            //5B 00 00 00 45 00 00 00 85 95 00 01 33 53 D5 01 00 00 00 00 00 27 0F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 95 04 00 00 00 0F 10 18 09 27 20 00 20 18 09 27 23 00 20 15 B4 3C D8 5D
        }

        [Fact]
        public void Test2()
        {
            var bytes = "10 18 09 27 20 00 20 18 09 27 23 00 20 15 B4".ToHexBytes();
            JT809_0x9500_0x9504 jT809_0X9500_0X9504 = JT809Serializer.Deserialize<JT809_0x9500_0x9504>(bytes);
            Assert.Equal(JT809CommandType.采集记录仪事故疑点记录, jT809_0X9500_0X9504.Command);
            Assert.Equal(DateTime.Parse("2018-09-27 20:00:20"), jT809_0X9500_0X9504.StartTime);
            Assert.Equal(DateTime.Parse("2018-09-27 23:00:20"), jT809_0X9500_0X9504.EndTime);
            //Assert.Equal(5556, jT809_0X9500_0X9504.Max);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x9500_0x9504 jT809_0X9500_0X9504 = new JT809_0x9500_0x9504
            {
                Command = JT809CommandType.采集记录仪事故疑点记录,
                StartTime = DateTime.Parse("2020-04-26 20:00:20"),
                EndTime = DateTime.Parse("2020-04-26 23:00:20")
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0X9500_0X9504).ToHexString();
            Assert.Equal("000000005EA577D4000000005EA5A20410", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "000000005EA577D4000000005EA5A20410".ToHexBytes();
            JT809_0x9500_0x9504 jT809_0X9500_0X9504 = JT809_2019_Serializer.Deserialize<JT809_0x9500_0x9504>(bytes);
            Assert.Equal(JT809CommandType.采集记录仪事故疑点记录, jT809_0X9500_0X9504.Command);
            Assert.Equal(DateTime.Parse("2020-04-26 20:00:20"), jT809_0X9500_0X9504.StartTime);
            Assert.Equal(DateTime.Parse("2020-04-26 23:00:20"), jT809_0X9500_0X9504.EndTime);
        }
    }
}
