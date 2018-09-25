using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Exceptions;
using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809MessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809MessageBodyFormatters
{
    public class JT809_0x1600Formatter : IJT809Formatter<JT809_0x1600>
    {
        public JT809_0x1600 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1600 jT809_0X1600 = new JT809_0x1600();
            jT809_0X1600.VehicleNo = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 21);
            jT809_0X1600.VehicleColor = (JT809VehicleColorType)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1600.SubBusinessType = (JT809SubBusinessType)JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X1600.DataLength = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            //JT809.Protocol.JT809Enums.JT809BusinessType 映射对应消息特性
            JT809BodiesTypeAttribute jT809SubBodiesTypeAttribute = jT809_0X1600.SubBusinessType.GetAttribute<JT809BodiesTypeAttribute>();
            if (jT809SubBodiesTypeAttribute == null)
            {
                throw new JT809Exception(JT809ErrorCode.GetAttributeError, $"JT809BodiesTypeAttribute Not Found>{jT809_0X1600.SubBusinessType.ToString()}");
            }
            try
            {
                jT809_0X1600.JT809SubBodies = JT809FormatterResolverExtensions.JT809DynamicDeserialize(JT809FormatterExtensions.GetFormatter(jT809SubBodiesTypeAttribute.JT809BodiesType), bytes.Slice(offset, (int)jT809_0X1600.DataLength), out readSize);
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{jT809_0X1600.SubBusinessType.ToString()}");
            }
            readSize = offset;
            return jT809_0X1600;
        }

        public int Serialize(IMemoryOwner<byte> memoryOwner, int offset, JT809_0x1600 value)
        {
            offset += JT809BinaryExtensions.WriteStringLittle(memoryOwner, offset, value.VehicleNo, 21);
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, (byte)value.VehicleColor);
            offset += JT809BinaryExtensions.WriteUInt16Little(memoryOwner, offset, (ushort)value.SubBusinessType);
            offset += JT809BinaryExtensions.WriteUInt32Little(memoryOwner, offset, value.DataLength);
            //JT809.Protocol.JT809Enums.JT809BusinessType 映射对应消息特性
            JT809BodiesTypeAttribute jT809SubBodiesTypeAttribute = value.SubBusinessType.GetAttribute<JT809BodiesTypeAttribute>();
            if (jT809SubBodiesTypeAttribute == null)
            {
                throw new JT809Exception(JT809ErrorCode.GetAttributeError, $"JT809BodiesTypeAttribute Not Found>{value.SubBusinessType.ToString()}");
            }
            try
            {
                offset = JT809FormatterResolverExtensions.JT809DynamicSerialize(JT809FormatterExtensions.GetFormatter(jT809SubBodiesTypeAttribute.JT809BodiesType), memoryOwner, offset, value.JT809SubBodies);
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{value.SubBusinessType.ToString()}");
            }
            return offset;
        }
    }
}
