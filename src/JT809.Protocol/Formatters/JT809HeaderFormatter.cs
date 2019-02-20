using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters
{
    public class JT809HeaderFormatter : IJT809Formatter<JT809Header>
    {
        public JT809Header Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809Header jT809Header = new JT809Header();
            jT809Header.MsgLength = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809Header.MsgSN= JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809Header.BusinessType = (JT809BusinessType)JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809Header.MsgGNSSCENTERID = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809Header.Version = new JT809Header_Version(JT809BinaryExtensions.ReadBytesLittle(bytes, ref offset, JT809Header_Version.FixedByteLength));
            jT809Header.EncryptFlag= (JT809Header_Encrypt)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809Header.EncryptKey= JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            readSize = offset;
            return jT809Header;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809Header value)
        {
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.MsgLength);
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.MsgSN);
            offset += JT809BinaryExtensions.WriteUInt16Little(bytes, offset, (ushort)value.BusinessType);
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.MsgGNSSCENTERID);
            offset += JT809BinaryExtensions.WriteBytesLittle(bytes, offset, value.Version.Buffer);
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.EncryptFlag);
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.EncryptKey);
            return offset;
        }
    }
}
