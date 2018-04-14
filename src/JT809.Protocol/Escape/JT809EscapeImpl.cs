using System.Collections.Generic;

namespace JT809.Protocol.Escape
{
    public class JT809EscapeImpl : IEscape
    {
        public byte[] Escape(byte[] bodyBuffer, IEncrypt encrypt)
        {
            List<byte> dataList = new List<byte>();
            dataList.Add(bodyBuffer[0]);
            for (int i = 1; i < bodyBuffer.Length - 1; i++)
            {
                var item = bodyBuffer[i];
                switch (item)
                {
                    case 0x5b:
                        dataList.Add(0x5a);
                        dataList.Add(0x01);
                        break;
                    case 0x5a:
                        dataList.Add(0x5a);
                        dataList.Add(0x02);
                        break;
                    case 0x5d:
                        dataList.Add(0x5e);
                        dataList.Add(0x01);
                        break;
                    case 0x5e:
                        dataList.Add(0x5e);
                        dataList.Add(0x02);
                        break;
                    default:
                        dataList.Add(item);
                        break;
                }
            }
            dataList.Add(bodyBuffer[bodyBuffer.Length - 1]);
            var tempBuffe = dataList.ToArray();
            if (encrypt != null)
            {
                encrypt.Encrypt(tempBuffe);
            }
            return tempBuffe;
        }

        public byte[] UnEscape(byte[] bodyBuffer, IEncrypt encrypt)
        {
            List<byte> dataList = new List<byte>();
            dataList.Add(bodyBuffer[0]);
            for (int i = 1; i < bodyBuffer.Length - 1; i++)
            {
                byte first = bodyBuffer[i];
                byte second = bodyBuffer[i + 1];
                if (first == 0x5a && second == 0x01)
                {
                    dataList.Add(0x5b);
                    i++;
                }
                else if (first == 0x5a && second == 0x02)
                {
                    dataList.Add(0x5a);
                    i++;
                }
                else if (first == 0x5e && second == 0x01)
                {
                    dataList.Add(0x5d);
                    i++;
                }
                else if (first == 0x5e && second == 0x02)
                {
                    dataList.Add(0x5e);
                    i++;
                }
                else
                {
                    dataList.Add(first);
                }
            }
            dataList.Add(bodyBuffer[bodyBuffer.Length - 1]);
            var tempBuffe = dataList.ToArray();
            if (encrypt != null)
            {
                encrypt.Decrypt(tempBuffe);
            }
            return tempBuffe;
        }
    }
}
