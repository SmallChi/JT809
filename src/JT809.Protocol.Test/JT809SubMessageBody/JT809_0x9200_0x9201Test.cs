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
    public class JT809_0x9200_0x9201Test
    {
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });

        /// <summary>
        /// 1078qq群808432702:大兄弟提供的 
        /// 由于车辆注册信息应答消息0x9201子业务不存在车牌号和颜色需要跳过
        /// </summary>
        [Fact]
        public void Test1()
        {
            var bytes = "5B0000002F000004579200000004570101010000000000000000004EBC924F9201000000070400000004000189DA5D".ToHexBytes();
            JT809Package jT809_0X9200_0X9201 = JT809_2019_Serializer.Deserialize(bytes);
            var body = jT809_0X9200_0X9201.Bodies as JT809_0x9200;
            var subBody = body.SubBodies as JT809_0x9200_0x9201;
            Assert.NotNull(body);
            Assert.NotNull(subBody);
            Assert.Equal(JT809VehicleColorType.其他, body.VehicleColor);
            Assert.Equal(JT809_0x9201_Result.审核通过_完成注册, subBody.Result);
            Assert.Equal(1024u, subBody.MsgSn);
            Assert.Equal(1024u, subBody.DataType);
        }

        /// <summary>
        /// 1078qq群808432702:大兄弟提供的 
        /// 由于车辆注册信息应答消息0x9201子业务不存在车牌号和颜色需要跳过
        /// </summary>
        [Fact]
        public void Test2()
        {
            var bytes = "5B0000002F000004579200000004570101010000000000000000004EBC924F9201000000070400000004000189DA5D".ToHexBytes();
            string json = JT809_2019_Serializer.Analyze(bytes);
        }
    }
}
