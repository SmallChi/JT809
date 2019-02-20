using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Extensions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters
{
    public class JT809BodiesFormatter<TJT809Bodies> : IJT809Formatter<TJT809Bodies>
       where TJT809Bodies: JT809ExchangeMessageBodies, new ()
    {
        public TJT809Bodies Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            TJT809Bodies jT809Bodies = new TJT809Bodies();
            jT809Bodies.VehicleNo = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 21);
            jT809Bodies.VehicleColor = (JT809VehicleColorType)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809Bodies.SubBusinessType = (JT809SubBusinessType)JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809Bodies.DataLength = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            //JT809.Protocol.Enums.JT809BusinessType 映射对应消息特性
            JT809BodiesTypeAttribute jT809SubBodiesTypeAttribute = jT809Bodies.SubBusinessType.GetAttribute<JT809BodiesTypeAttribute>();
            if (jT809SubBodiesTypeAttribute == null)
            {
                throw new JT809Exception(JT809ErrorCode.GetAttributeError, $"JT809BodiesTypeAttribute Not Found>{jT809Bodies.SubBusinessType.ToString()}");
            }
            try
            {
                jT809Bodies.SubBodies = JT809FormatterResolverExtensions.JT809DynamicDeserialize(JT809FormatterExtensions.GetFormatter(jT809SubBodiesTypeAttribute.JT809BodiesType), bytes.Slice(offset, (int)jT809Bodies.DataLength), out readSize);
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{jT809Bodies.SubBusinessType.ToString()}");
            }
            readSize = offset;
            return jT809Bodies;
        }

        public int Serialize(ref byte[] bytes, int offset, TJT809Bodies value)
        {
            offset += JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.VehicleNo, 21);
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.VehicleColor);
            offset += JT809BinaryExtensions.WriteUInt16Little(bytes, offset, (ushort)value.SubBusinessType);
            //JT809.Protocol.Enums.JT809BusinessType 映射对应消息特性
            JT809BodiesTypeAttribute jT809SubBodiesTypeAttribute = value.SubBusinessType.GetAttribute<JT809BodiesTypeAttribute>();
            if (jT809SubBodiesTypeAttribute == null)
            {
                throw new JT809Exception(JT809ErrorCode.GetAttributeError, $"JT809BodiesTypeAttribute Not Found>{value.SubBusinessType.ToString()}");
            }
            try
            {
                // 先写入内容，然后在根据内容反写内容长度
                offset = offset + 4;
                int contentOffset = JT809FormatterResolverExtensions.JT809DynamicSerialize(JT809FormatterExtensions.GetFormatter(jT809SubBodiesTypeAttribute.JT809BodiesType), ref bytes, offset, value.SubBodies);
                JT809BinaryExtensions.WriteUInt32Little(bytes, offset - 4, (uint)(contentOffset- offset));
                offset = contentOffset;
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{value.SubBusinessType.ToString()}");
            }
            return offset;
        }
    }
}
