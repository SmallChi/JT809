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
    public class JT809_0x1200_0x1205Test
    {
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });

        /// <summary>
        /// 1078qq群808432702:大兄弟提供的 
        /// </summary>
        [Fact]
        public void Test1()
        {
            var bytes = "5B00000044000004571200000004570101010000000000000000004EBC924FB2E2CAD43131313100000000000000000000000000041205040000000400000000001B735D".ToHexBytes();
            JT809Package jT809Package = JT809_2019_Serializer.Deserialize(bytes);
            var body = jT809Package.Bodies as JT809_0x1200;
            var subBody = body.SubBodies as JT809_0x1200_0x1205;
            Assert.NotNull(body);
            Assert.NotNull(subBody);
            Assert.Equal("测试1111", body.VehicleNo);
            Assert.Equal(JT809VehicleColorType.白色, body.VehicleColor);
            Assert.Equal(1024u, subBody.SourceDataType);
            Assert.Equal(1024u, subBody.SourceMsgSN);
            Assert.Equal(0u, subBody.DataLength);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "5B00000044000004571200000004570101010000000000000000004EBC924FB2E2CAD43131313100000000000000000000000000041205040000000400000000001B735D".ToHexBytes();
            string json = JT809_2019_Serializer.Analyze(bytes);
        }
    }
}
