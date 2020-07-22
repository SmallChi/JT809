using JT808.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public class Jt809_0x9102Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809_0x9102 jT809_0X9102 = new JT809_0x9102
            {
                SubBusinessType = 10086,
                PlateformId = "10010",
                StartTime = DateTime.Parse("2011-11-11 11:11:11"),
                EndTime = DateTime.Parse("2011-11-11 11:11:11")
            };
            var hex = JT809Serializer.Serialize(jT809_0X9102).ToHexString();
            Assert.Equal("27660000001B3130303130000000000000000000004EBC924F000000004EBC924F", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "27660000001B3130303130000000000000000000004EBC924F000000004EBC924F".ToHexBytes();
            JT809_0x9102 jT809_0X9102 = JT809Serializer.Deserialize<JT809_0x9102>(bytes);
            Assert.Equal(10086u, jT809_0X9102.SubBusinessType);
            Assert.Equal("10010", jT809_0X9102.PlateformId);
            Assert.Equal(DateTime.Parse("2011-11-11 11:11:11"), jT809_0X9102.StartTime);
            Assert.Equal(DateTime.Parse("2011-11-11 11:11:11"), jT809_0X9102.EndTime);
        }
    }
}
