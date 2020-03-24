﻿using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters
{
    public class JT809HeaderFormatter : IJT809MessagePackFormatter<JT809Header>
    {
        public readonly static JT809HeaderFormatter Instance = new JT809HeaderFormatter();

        public JT809Header Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809Header jT809Header = new JT809Header
            {
                MsgLength = reader.ReadUInt32(),
                MsgSN = reader.ReadUInt32(),
                BusinessType = reader.ReadUInt16(),
                MsgGNSSCENTERID = reader.ReadUInt32(),
                Version = new JT809Header_Version(reader.ReadArray(JT809Header_Version.FixedByteLength)),
                EncryptFlag = (JT809Header_Encrypt)reader.ReadByte(),
                EncryptKey = reader.ReadUInt32(),
                Time = reader.ReadUTCDateTime()
            };
            return jT809Header;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809Header value, IJT809Config config)
        {
            writer.WriteUInt32(value.MsgLength);
            writer.WriteUInt32(value.MsgSN);
            writer.WriteUInt16(value.BusinessType);
            writer.WriteUInt32(value.MsgGNSSCENTERID);
            writer.WriteArray(value.Version.Buffer);
            writer.WriteByte((byte)value.EncryptFlag);
            writer.WriteUInt32(value.EncryptKey);
            writer.WriteUTCDateTime(value.Time);
        }
    }
}
