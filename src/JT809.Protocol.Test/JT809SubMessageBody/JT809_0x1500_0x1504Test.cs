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
    public class JT809_0x1500_0x1504Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
        [Fact]
        public void Test1()
        {
            JT809_0x1500_0x1504 jT809_0x1500_0x1504 = new JT809_0x1500_0x1504
            {
                TraveldataInfo = "557AC40014002003251026012003251026010000123400123456A9".ToHexBytes(),
            };
            var hex = JT809Serializer.Serialize(jT809_0x1500_0x1504).ToHexString();
            Assert.Equal("0000001B557AC40014002003251026012003251026010000123400123456A9", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "0000001B557AC40014002003251026012003251026010000123400123456A9".ToHexBytes();
            JT809_0x1500_0x1504 jT809_0x1500_0x1504 = JT809Serializer.Deserialize<JT809_0x1500_0x1504>(bytes);
            Assert.Equal("557AC40014002003251026012003251026010000123400123456A9".ToHexBytes(), jT809_0x1500_0x1504.TraveldataInfo);
            Assert.Equal(0x1bu, jT809_0x1500_0x1504.TraveldataLength);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x1500_0x1504 jT809_0x1500_0x1504 = new JT809_0x1500_0x1504
            {
                CommandType = JT809CommandType.记录仪唯一性编号,
                TraveldataInfo = "557AC40014002003251026012003251026010000123400123456A9".ToHexBytes(),
                SourceMsgSn = 1,
                SourceDataType = 12,
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0x1500_0x1504).ToHexString();
            Assert.Equal("000C00000001070000001B557AC40014002003251026012003251026010000123400123456A9", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "000C00000001070000001B557AC40014002003251026012003251026010000123400123456A9".ToHexBytes();
            JT809_0x1500_0x1504 jT809_0x1500_0x1504 = JT809_2019_Serializer.Deserialize<JT809_0x1500_0x1504>(bytes);
            Assert.Equal(JT809CommandType.记录仪唯一性编号, jT809_0x1500_0x1504.CommandType);
            Assert.Equal("557AC40014002003251026012003251026010000123400123456A9".ToHexBytes(), jT809_0x1500_0x1504.TraveldataInfo);
            Assert.Equal(0x1bu, jT809_0x1500_0x1504.TraveldataLength);
            Assert.Equal(1u, jT809_0x1500_0x1504.SourceMsgSn);
            Assert.Equal(12, jT809_0x1500_0x1504.SourceDataType);
        }
    }
}
