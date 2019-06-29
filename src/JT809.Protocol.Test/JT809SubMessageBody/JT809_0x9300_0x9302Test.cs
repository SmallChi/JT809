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
    public class JT809_0x9300_0x9302Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809_0x9300_0x9302 jT809_0X9300_0X9302 = new JT809_0x9300_0x9302
            {
                ObjectType= JT809_0x9302_ObjectType.下级平台所属单一平台,
                ObjectID="afdasf3",
                InfoID=1234,
                InfoContent= "下级平台所属单一平台"
            };
            var hex = JT809Serializer.Serialize(jT809_0X9300_0X9302).ToHexString();
            Assert.Equal("00616664617366330000000000000004D200000014CFC2BCB6C6BDCCA8CBF9CAF4B5A5D2BBC6BDCCA8", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00616664617366330000000000000004D200000014CFC2BCB6C6BDCCA8CBF9CAF4B5A5D2BBC6BDCCA8".ToHexBytes();
            JT809_0x9300_0x9302 jT809_0X9300_0X9302 = JT809Serializer.Deserialize<JT809_0x9300_0x9302>(bytes);
            Assert.Equal(JT809_0x9302_ObjectType.下级平台所属单一平台, jT809_0X9300_0X9302.ObjectType);
            Assert.Equal("afdasf3", jT809_0X9300_0X9302.ObjectID);
            Assert.Equal((uint)1234, jT809_0X9300_0X9302.InfoID);
            Assert.Equal("下级平台所属单一平台", jT809_0X9300_0X9302.InfoContent);
            Assert.Equal((uint)20, jT809_0X9300_0X9302.InfoLength);
        }
    }
}
