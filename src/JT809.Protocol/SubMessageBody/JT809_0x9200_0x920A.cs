using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上报车辆驾驶员身份识别信息请求
    /// <para>子业务类型标识:DOWN_EXG_MSG_REPORT_DRIVER_INFO</para>
    /// </summary>
    public class JT809_0x9200_0x920A:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9200_0x920A>, IJT809Analyze, IJT809_2019_Version
    {        
        public override ushort SubMsgId => JT809SubBusinessType.上报车辆驾驶员身份识别信息请求.ToUInt16Value();

        public override string Description => "上报车辆驾驶员身份识别信息请求";

        public override bool SkipSerialization => false;
        /// <summary>
        /// 上传标志
        /// </summary>
        public JT809_0x920A_UploadFlag Flag { get; set; }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200_0x920A value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2019)
            {
                writer.WriteByte((byte)value.Flag);
            }
        }

        public JT809_0x9200_0x920A Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x9200_0x920A();
            if (config.Version == JT809Version.JTT2019)
            {
                value.Flag = (JT809_0x920A_UploadFlag)reader.ReadByte();
            }
            return value;
        }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            var value = new JT809_0x9200_0x920A();
            if (config.Version == JT809Version.JTT2019)
            {
                value.Flag = (JT809_0x920A_UploadFlag)reader.ReadByte();
                writer.WriteString($"[{value.Flag.ToByteValue()}]上传标志", value.Flag.ToString());
            }
        }
    }
}
