using JT808.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public class Jt809_0x9103Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            var jT809_0X9103 = new JT809_0x9103
            {
                SubBusinessType = 10086,
                ManageMsgSNInform = new List<Metadata.JT809ManageMsgSNInform>
                {
                    new Metadata.JT809ManageMsgSNInform
                    {
                        SubBusinessType=10010,
                        MsgSN=10010,
                        Time=DateTime.Parse("2011-11-11 11:11:11")
                    },
                    new Metadata.JT809ManageMsgSNInform
                    {
                        SubBusinessType=10086,
                        MsgSN=10086,
                        Time=DateTime.Parse("2011-11-11 11:11:11")
                    },
                    new Metadata.JT809ManageMsgSNInform
                    {
                        SubBusinessType=10000,
                        MsgSN=10000,
                        Time=DateTime.Parse("2011-11-11 11:11:11")
                    }
                }
            };
            var hex = JT809Serializer.Serialize(jT809_0X9103).ToHexString();
            Assert.Equal("27660000002B03271A0000271A000000004EBC924F276600002766000000004EBC924F271000002710000000004EBC924F", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "27660000002B03271A0000271A000000004EBC924F276600002766000000004EBC924F271000002710000000004EBC924F".ToHexBytes();
            var jT809_0X9102 = JT809Serializer.Deserialize<JT809_0x9103>(bytes);
            Assert.Equal(10086u, jT809_0X9102.SubBusinessType);
            Assert.Equal(3, jT809_0X9102.Count);
            Assert.Equal(10010u, jT809_0X9102.ManageMsgSNInform[0].SubBusinessType);
            Assert.Equal(10010u, jT809_0X9102.ManageMsgSNInform[0].MsgSN);
            Assert.Equal(DateTime.Parse("2011-11-11 11:11:11"), jT809_0X9102.ManageMsgSNInform[0].Time);
            Assert.Equal(10086u, jT809_0X9102.ManageMsgSNInform[1].SubBusinessType);
            Assert.Equal(10086u, jT809_0X9102.ManageMsgSNInform[1].MsgSN);
            Assert.Equal(DateTime.Parse("2011-11-11 11:11:11"), jT809_0X9102.ManageMsgSNInform[1].Time);
            Assert.Equal(10000u, jT809_0X9102.ManageMsgSNInform[2].SubBusinessType);
            Assert.Equal(10000u, jT809_0X9102.ManageMsgSNInform[2].MsgSN);
            Assert.Equal(DateTime.Parse("2011-11-11 11:11:11"), jT809_0X9102.ManageMsgSNInform[2].Time);
        }
    }
}
