using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public class JT809_0x1005Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809Package heartbeatPackage = JT809BusinessType.主链路连接保持请求消息.Create();
            byte[] sendHeartbeatData = JT809Serializer.Serialize(heartbeatPackage, 100);
        }
    }
}
