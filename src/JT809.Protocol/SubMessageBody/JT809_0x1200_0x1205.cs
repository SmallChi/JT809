﻿using JT809.Protocol.Enums;
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
    /// 启动车辆定位信息交换应答消息
    /// <para>子业务类型标识:UP_EXG_MSG_RETURN_STARTUP_ACK</para>
    /// <para>描述：本条消息是下级平台对上级平台下发的 DOWN_EXG_MSG_RETURN_STARTUP 消息的应答消息</para>
    /// </summary>
    public class JT809_0x1200_0x1205:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x1205>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.启动车辆定位信息交换应答消息.ToUInt16Value();

        public override string Description => "启动车辆定位信息交换应答消息";

        public override bool SkipSerialization => false;
        public override bool SkipDataLength => true;
        /// <summary>
        /// 子业务类型标识
        /// </summary>
        public ushort DataType { get; set; }
        /// <summary>
        /// 对应启动车辆定位信息交换请求消息源子业务类型标识
        /// </summary>
        public ushort SourceDataType { get; set; }
        /// <summary>
        /// 对应启动车辆定位信息交换请求消息源报文序列号
        /// </summary>
        public uint SourceMsgSN { get; set; }
        /// <summary>
        /// 后续数据长度  值为0x00
        /// </summary>
        public uint DataLength { get; set; } = 0x00;

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            var value = new JT809_0x1200_0x1205();
            if (config.Version == JT809Version.JTT2019)
            {
                value.SourceDataType = reader.ReadUInt16(); 
                writer.WriteString($"[{value.SourceDataType.ReadNumber()}]对应启动车辆定位信息交换请求消息源子业务类型标识", ((JT809SubBusinessType)value.SourceDataType).ToString());
                value.SourceMsgSN = reader.ReadUInt32();
                writer.WriteNumber($"[{value.SourceMsgSN.ReadNumber()}对应启动车辆定位信息交换请求消息源报文序列号]", value.SourceMsgSN);
                value.DataLength = reader.ReadUInt32();
                writer.WriteNumber($"[{value.DataLength.ReadNumber()}后续数据长度]", value.DataLength);
            }
        }

        public JT809_0x1200_0x1205 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x1200_0x1205();
            if (config.Version == JT809Version.JTT2019) 
            {
                value.SourceDataType = reader.ReadUInt16();
                value.SourceMsgSN = reader.ReadUInt32();
                value.DataLength = reader.ReadUInt32();
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x1205 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2019) 
            {
                writer.WriteUInt16(value.SourceDataType);
                writer.WriteUInt32(value.SourceMsgSN);
                writer.WriteUInt32(value.DataLength);
            }
        }
    }
}
