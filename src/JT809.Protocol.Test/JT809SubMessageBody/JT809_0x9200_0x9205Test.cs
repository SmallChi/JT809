using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809MessageBody;
using JT809.Protocol.JT809Exceptions;
using JT809.Protocol.JT809SubMessageBody;
using JT809.Protocol.JT809Enums;

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x9200_0x9205Test
    {
        [Fact]
        public void Test1()
        {
            JT809_0x9200_0x9205 jT809_0X9200_0X9205 = new JT809_0x9200_0x9205
            {
                  ReasonCode= JT809_0x9205_ReasonCode.应急状态下车辆定位信息回传
            };
            var hex = JT809Serializer.Serialize(jT809_0X9200_0X9205).ToHexString();
            Assert.Equal("02", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "02".ToHexBytes();
            JT809_0x9200_0x9205 jT809_0X9200_0X9205 = JT809Serializer.Deserialize<JT809_0x9200_0x9205>(bytes);
            Assert.Equal(JT809_0x9205_ReasonCode.应急状态下车辆定位信息回传, jT809_0X9200_0X9205.ReasonCode);
        }

    }
}
