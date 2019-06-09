using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Extensions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using JT809.Protocol.Internal;

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
            try
            {
                jT809Bodies.SubBodies = jT809Bodies.SubBusinessType.Deserialize(bytes.Slice(offset, (int)jT809Bodies.DataLength), out readSize);
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
            try
            {
                // 先写入内容，然后在根据内容反写内容长度
                offset = offset + 4;
                int contentOffset = value.SubBusinessType.Serialize(ref bytes, offset, value.SubBodies);
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
