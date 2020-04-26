using Microsoft.Extensions.DependencyInjection;
using System;
using JT809.Protocol.Test.JT1078;
using JT809.Protocol.Extensions;
using Xunit;
using JT809.Protocol.Enums;
using JT809.Protocol.Interfaces;

namespace JT809.Protocol.Test.Simples
{
    public class Demo4
    {
        IServiceProvider ServiceProvider;
        JT809Serializer JT809_2019_Serializer;
        IJT809Config JT809_2011_Config;
        IJT809Config JT809_2019_Config;

        public Demo4()
        {
            IServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddJT809Configure(new JT809_2011_Config())
                              .AddJT1078Configure();
            serviceDescriptors.AddJT809Configure(new JT809_2019_Config())
                                  .AddJT1078Configure();
            ServiceProvider = serviceDescriptors.BuildServiceProvider();
            JT809_2011_Config = ServiceProvider.GetRequiredService<JT809_2011_Config>();
            JT809_2019_Config = ServiceProvider.GetRequiredService<JT809_2019_Config>();
            JT809_2019_Serializer = JT809_2019_Config.GetSerializer();
        }

        [Fact]
        public void Test1()
        {
            JT809Package jT809Package = new JT809Package();
            jT809Package.Header = new JT809Header
            {
                MsgSN = 1666,
                EncryptKey = 9999,
                EncryptFlag = JT809Header_Encrypt.None,
                Version = new JT809Header_Version(1, 0, 0),
                BusinessType = JT809_JT1078_BusinessType.主链路时效口令业务类.ToUInt16Value(),
                MsgGNSSCENTERID = 20190708,
                Time=DateTime.Parse("2020-04-26 12:02:00")
            };
            JT808_JT1078_0x1700 bodies = new JT808_JT1078_0x1700
            {
                VehicleNo = "粤A12345",
                VehicleColor = JT809VehicleColorType.黄色,
                SubBusinessType = JT809_JT1078_SubBusinessType.时效口令上报消息.ToUInt16Value(),
            };
            JT808_JT1078_0x1700_0x1701 jT808_JT1078_0x1700_0x1701 = new JT808_JT1078_0x1700_0x1701
            {
                PlateFormId = new byte[11] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11 },
                AuthorizeCode1 = new byte[64],
                AuthorizeCode2 = new byte[64]
            };
            bodies.SubBodies = jT808_JT1078_0x1700_0x1701;
            jT809Package.Bodies = bodies;
            var hex = JT809_2019_Serializer.Serialize(jT809Package).ToHexString();
            Assert.Equal("5B000000C9000006821700013415F4010000000000270F000000005E02A507B8D4C1413132333435000000000000000000000000000217010000008B01020304050607080910110000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000E7D35D", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "5B000000C9000006821700013415F4010000000000270F000000005E02A507B8D4C1413132333435000000000000000000000000000217010000008B01020304050607080910110000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000E7D35D".ToHexBytes();
            JT809Package jT809Package = JT809_2019_Serializer.Deserialize(data);
            Assert.Equal((uint)1666, jT809Package.Header.MsgSN);
            Assert.Equal((uint)9999, jT809Package.Header.EncryptKey);
            Assert.Equal(JT809Header_Encrypt.None, jT809Package.Header.EncryptFlag);
            Assert.Equal(new JT809Header_Version(1, 0, 0).ToString(), jT809Package.Header.Version.ToString());
            Assert.Equal(DateTime.Parse("2020-04-26 12:02:00"), jT809Package.Header.Time);
            Assert.Equal(0x1700, jT809Package.Header.BusinessType);
            Assert.Equal((uint)20190708, jT809Package.Header.MsgGNSSCENTERID);
            JT809ExchangeMessageBodies bodies = jT809Package.Bodies as JT809ExchangeMessageBodies;
            JT808_JT1078_0x1700_0x1701 subBodies = bodies.SubBodies as JT808_JT1078_0x1700_0x1701;
            Assert.Equal(new byte[11] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11 }, subBodies.PlateFormId);
            Assert.Equal(new byte[64], subBodies.AuthorizeCode1);
            Assert.Equal(new byte[64], subBodies.AuthorizeCode2);
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal("JT809_2011", JT809_2011_Config.ConfigId);
            Assert.Equal(JT809Version.JTT2011, JT809_2011_Config.Version);
            Assert.Equal("JT809_2019", JT809_2019_Config.ConfigId);
            Assert.Equal(JT809Version.JTT2019, JT809_2019_Config.Version);
        }
    }

    public class JT809_2011_Config: JT809GlobalConfigBase
    {
        public override string ConfigId => "JT809_2011";
    }

    public class JT809_2019_Config : JT809GlobalConfigBase
    {
        public override string ConfigId => "JT809_2019";

        public JT809_2019_Config()
        {
            Version = JT809Version.JTT2019;
        }
    }
}
