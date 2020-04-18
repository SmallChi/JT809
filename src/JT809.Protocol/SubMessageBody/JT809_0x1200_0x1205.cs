using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 启动车辆定位信息交换应答消息
    /// <para>子业务类型标识:UP_EXG_ MSG_ RETURN_ STARTUP ACK</para>
    /// <para>描述：本条消息是下级平台对上级平台下发的 DOWN_EXG_ MSG_ RETURN_STARTUP 消息的应答消息</para>
    /// </summary>
    public class JT809_0x1200_0x1205:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x1205>, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.启动车辆定位信息交换应答消息.ToUInt16Value();

        public override string Description => "启动车辆定位信息交换应答消息";

        public override bool SkipSerialization => false;
        /// <summary>
        /// 对应启动车辆定位信息交换请求消息源子业务类型标识
        /// </summary>
        public ushort SourceDataType { get; set; }
        /// <summary>
        /// 对应启动车辆定位信息交换请求消息源报文序列号
        /// </summary>
        public uint SourceMsgSn { get; set; }

        public JT809_0x1200_0x1205 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x1200_0x1205();
            if (config.Version == JT809Version.JTT2019) {
                value.SourceDataType = reader.ReadUInt16();
                value.SourceMsgSn = reader.ReadUInt32();
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x1205 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2019) {
                writer.WriteUInt16(value.SourceDataType);
                writer.WriteUInt32(value.SourceMsgSn);
            }
        }
    }
}
