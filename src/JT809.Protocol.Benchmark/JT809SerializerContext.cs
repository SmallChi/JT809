using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;
using JT809.Protocol.Enums;
using JT809.Protocol.MessageBody;
using JT809.Protocol.SubMessageBody;
using JT809.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Benchmark
{
    [Config(typeof(JT809SerializerContextConfig))]
    [MarkdownExporter]
    [MemoryDiagnoser]
    public class JT809SerializerContext
    {
        private byte[] bytes;
        private JT809Serializer JT809Serializer;
        [Params(100, 10000,100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            JT809Serializer = new JT809Serializer();
            bytes = "5B 00 00 00 92 00 00 06 82 94 00 01 33 EF B8 01 00 00 00 00 00 27 0F D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 02 94 01 00 00 00 5C 01 00 02 00 00 00 00 5A 01 AC 3F 40 12 3F FA A1 00 00 00 00 5A 01 AC 4D 50 03 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00 31 32 33 34 35 36 37 38 39 30 31 00 00 00 00 00 00 00 00 00 31 32 33 34 35 36 40 71 71 2E 63 6F 6D 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 BA D8 5D".ToHexBytes();
        }

        [Benchmark(Description = "JT809_0x9400_0x9401_Package_Deserialize")]
        public void JT809_0x9400_0x9401_Package_Deserialize_Test()
        {
            for (int i = 0; i < N; i++)
            {
                var result = JT809Serializer.Deserialize(bytes);
            }
        }

        [Benchmark(Description = "JT809_0x9400_0x9401_Package_Serialize")]
        public void JT809_0x9400_0x9401_Package_Serialize_Test()
        {
            for (int i = 0; i < N; i++)
            {
                JT809Package jT809Package = new JT809Package();

                jT809Package.Header = new JT809Header
                {
                    MsgSN = 1666,
                    EncryptKey = 9999,
                    EncryptFlag = JT809Header_Encrypt.None,
                    Version = new JT809Header_Version(1, 0, 0),
                    BusinessType = (ushort)JT809BusinessType.从链路报警信息交互消息,
                    MsgGNSSCENTERID = 20180920,
                };

                JT809_0x9400 bodies = new JT809_0x9400
                {
                    VehicleNo = "粤A12345",
                    VehicleColor = JT809VehicleColorType.黄色,
                    SubBusinessType = JT809SubBusinessType.报警督办请求消息.ToUInt16Value(),
                };

                JT809_0x9400_0x9401 jT809_0x9400_0x9401 = new JT809_0x9400_0x9401
                {
                    WarnSrc = JT809WarnSrc.车载终端,
                    WarnType = JT809WarnType.疲劳驾驶报警.ToUInt16Value(),
                    WarnTime = DateTime.Parse("2018-09-27 10:24:00"),
                    SupervisionID = "123FFAA1",
                    SupervisionEndTime = DateTime.Parse("2018-09-27 11:24:00"),
                    SupervisionLevel =  JT809_9401_SupervisionLevel.一般,
                    Supervisor = "smallchi",
                    SupervisorTel = "12345678901",
                    SupervisorEmail = "123456@qq.com"
                };
                bodies.SubBodies = jT809_0x9400_0x9401;
                jT809Package.Bodies = bodies;
                var hex = JT809Serializer.Serialize(jT809Package);
            }
        }

    }

    public class JT809SerializerContextConfig : ManualConfig
    {
        public JT809SerializerContextConfig()
        {
            AddJob(Job.Default.WithGcServer(false).WithToolchain(CsProjCoreToolchain.NetCoreApp70).WithPlatform(Platform.AnyCpu));
        }
    }
}
