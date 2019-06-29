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

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x9200_0x9204Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809_0x9200_0x9204 jT809_0X9200_0X9204 = new JT809_0x9200_0x9204
            {
                   CarInfo= "车辆信息"
            };
            var hex = JT809Serializer.Serialize(jT809_0X9200_0X9204).ToHexString();
            Assert.Equal("B3B5C1BED0C5CFA2", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "B3B5C1BED0C5CFA2".ToHexBytes();
            JT809_0x9200_0x9204 jT809_0X9200_0X9204 = JT809Serializer.Deserialize<JT809_0x9200_0x9204>(bytes);
            Assert.Equal("车辆信息", jT809_0X9200_0X9204.CarInfo);
        }

    }
}
