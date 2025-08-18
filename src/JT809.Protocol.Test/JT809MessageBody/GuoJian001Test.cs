using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Internal;
using JT809.Protocol.Enums;
using JT809.Protocol.Interfaces;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace JT809.Protocol.Test.JT809MessageBody
{
    public class GuoJian001Test
    {

        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new GuoJian001_GlobalConfig());

        private JsonWriterOptions options = new JsonWriterOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        [Fact(DisplayName = "2019版序列化-大兄弟提供1")]
        public void GuoJian001_2019_1()
        {
            var bytes = "5b0000008e00000010940000000000000000000000000000000000689eb0ff9403000000664a43323032355054303437000300000198abac778e00000198abe3660ebea941313233343500000000000000000000000000013335303130303030000000000003e900000020b3b5c1beb3accbd9b1a8beafa3acb5b1c7b0cbd9b6c8b3acb9fdcfded6c6d6b53d705d".ToHexBytes();
            string json = JT809_2019_Serializer.Analyze(bytes, options);
        }

        [Fact(DisplayName = "2019版序列化-大兄弟提供2")]
        public void GuoJian001_2019_2()
        {
            var package = JT809_2019_Serializer.Analyze(
                "5b0000005c000000499300042c1d810000000100003b8900000000689e195830a40dc885a2cba573c5afb5408a3a5f9087119a5ae184960d1cf378d127390c0bebff775835fddd57d380539049899afc4d7dfd057684e9c6156a1e5d".ToHexBytes()
                , options);
        }

        [Fact(DisplayName = "2019版序列化-大兄弟提供3")]
        public void GuoJian001_2019_3()
        {

            var package = JT809_2019_Serializer.Analyze(
                "5b0000005c00000006930000000000000000000000000000000000689eadf193010000003402b2e24230313834340000000000000000000000000a0000001900000016c6bdcca8b2e9b8dac7ebc7f3cac7b7f1cac7c8cbc0e017f05d".ToHexBytes(), options);
        }

        [Fact(DisplayName = "2019版序列化-大兄弟提供4")]
        public void GuoJian001_2019_4()
        {
            var package = JT809_2019_Serializer.Analyze(
                "5b00000045000000151500052df12c0000000100003b890000000068a2947d11474cfeb5a5ff2e91879f8478be0e5f9087119a5ae091970d1cf375442639150beaff30815d".ToHexBytes(), options);
        }

        class GuoJian001_GlobalConfig : JT809GlobalConfigBase
        {
            public GuoJian001_GlobalConfig()
            {
                Version = JT809Version.JTT2019;
                EncryptOptions = new Configs.JT809EncryptOptions
                {
                    M1 = 56107078,
                    IA1 = 37382110,
                    IC1 = 50361430
                };
            }
            public override string ConfigId => "GuoJian001";
        }
    }
}
