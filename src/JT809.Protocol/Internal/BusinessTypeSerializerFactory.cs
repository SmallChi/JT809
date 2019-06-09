using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.Formatters.MessageBodyFormatters;
using JT809.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Internal
{
    static class BusinessTypeSerializerFactory
    {
        static JT809_0x1001_Formatter jT809_0x1001_Formatter = new JT809_0x1001_Formatter();
        static JT809_0x1002_Formatter jT809_0x1002_Formatter = new JT809_0x1002_Formatter();
        static JT809_0x1003_Formatter jT809_0x1003_Formatter = new JT809_0x1003_Formatter();
        static JT809_0x1007_Formatter jT809_0x1007_Formatter = new JT809_0x1007_Formatter();
        static JT809_0x1008_Formatter jT809_0x1008_Formatter = new JT809_0x1008_Formatter();
        static JT809BodiesFormatter<JT809_0x1200> JT809_0x1200_Formatter = new JT809BodiesFormatter<JT809_0x1200>();
        static JT809_0x1300_Formatter jT809_0x1300_Formatter = new JT809_0x1300_Formatter();
        static JT809BodiesFormatter<JT809_0x1400> JT809_0x1400_Formatter = new JT809BodiesFormatter<JT809_0x1400>();
        static JT809BodiesFormatter<JT809_0x1500> JT809_0x1500_Formatter = new JT809BodiesFormatter<JT809_0x1500>();
        static JT809BodiesFormatter<JT809_0x1600> JT809_0x1600_Formatter = new JT809BodiesFormatter<JT809_0x1600>();
        static JT809_0x9001_Formatter jT809_0x9001_Formatter = new JT809_0x9001_Formatter();
        static JT809_0x9002_Formatter jT809_0x9002_Formatter = new JT809_0x9002_Formatter();
        static JT809_0x9003_Formatter jT809_0x9003_Formatter = new JT809_0x9003_Formatter();
        static JT809_0x9007_Formatter jT809_0x9007_Formatter = new JT809_0x9007_Formatter();
        static JT809_0x9008_Formatter jT809_0x9008_Formatter = new JT809_0x9008_Formatter();
        static JT809_0x9101_Formatter jT809_0x9101_Formatter = new JT809_0x9101_Formatter();
        static JT809BodiesFormatter<JT809_0x9200> jT809_0x9200_Formatter = new JT809BodiesFormatter<JT809_0x9200>();
        static JT809_0x9300_Formatter jT809_0x9300_Formatter = new JT809_0x9300_Formatter();
        static JT809BodiesFormatter<JT809_0x9400> jT809_0x9400_Formatter = new JT809BodiesFormatter<JT809_0x9400>();
        static JT809BodiesFormatter<JT809_0x9500> jT809_0x9500_Formatter = new JT809BodiesFormatter<JT809_0x9500>();
        static JT809BodiesFormatter<JT809_0x9600> jT809_0x9600_Formatter = new JT809BodiesFormatter<JT809_0x9600>();

        public static JT809Bodies Deserialize(this JT809BusinessType jT809BusinessType, ReadOnlySpan<byte> bytes, out int readSize)
        {
            switch (jT809BusinessType)
            {
                case JT809BusinessType.主链路登录请求消息:
                    return jT809_0x1001_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.主链路登录应答消息:
                    return jT809_0x1002_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.主链路注销请求消息:
                    return jT809_0x1003_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.主链路断开通知消息:
                    return jT809_0x1007_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.下级平台主动关闭链路通知消息:
                    return jT809_0x1008_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.主链路动态信息交换消息:
                    return JT809_0x1200_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.主链路平台间信息交互消息:
                    return jT809_0x1300_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.主链路报警信息交互消息:
                    return JT809_0x1400_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.主链路车辆监管消息:
                    return JT809_0x1500_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.主链路静态信息交换消息:
                    return JT809_0x1600_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.从链路连接请求消息:
                    return jT809_0x9001_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.从链路连接应答消息:
                    return jT809_0x9002_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.从链路注销请求消息:
                    return jT809_0x9003_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.从链路断开通知消息:
                    return jT809_0x9007_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.上级平台主动关闭链路通知消息:
                    return jT809_0x9008_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.接收定位信息数量通知消息:
                    return jT809_0x9101_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.从链路动态信息交换消息:
                    return jT809_0x9200_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.从链路平台间信息交互消息:
                    return jT809_0x9300_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.从链路报警信息交互消息:
                    return jT809_0x9400_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.从链路车辆监管消息:
                    return jT809_0x9500_Formatter.Deserialize(bytes, out readSize);
                case JT809BusinessType.从链路静态信息交换消息:
                    return jT809_0x9600_Formatter.Deserialize(bytes, out readSize);
                default:
                    readSize = 0;
                    return default;
            }
        }

        public static int Serialize(this JT809BusinessType jT809BusinessType, ref byte[] bytes, int offset, dynamic value)
        {
            switch (jT809BusinessType)
            {
                case JT809BusinessType.主链路登录请求消息:
                    return jT809_0x1001_Formatter.Serialize(ref bytes,offset, value);
                case JT809BusinessType.主链路登录应答消息:
                    return jT809_0x1002_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.主链路注销请求消息:
                    return jT809_0x1003_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.主链路断开通知消息:
                    return jT809_0x1007_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.下级平台主动关闭链路通知消息:
                    return jT809_0x1008_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.主链路动态信息交换消息:
                    return JT809_0x1200_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.主链路平台间信息交互消息:
                    return jT809_0x1300_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.主链路报警信息交互消息:
                    return JT809_0x1400_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.主链路车辆监管消息:
                    return JT809_0x1500_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.主链路静态信息交换消息:
                    return JT809_0x1600_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.从链路连接请求消息:
                    return jT809_0x9001_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.从链路连接应答消息:
                    return jT809_0x9002_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.从链路注销请求消息:
                    return jT809_0x9003_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.从链路断开通知消息:
                    return jT809_0x9007_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.上级平台主动关闭链路通知消息:
                    return jT809_0x9008_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.接收定位信息数量通知消息:
                    return jT809_0x9101_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.从链路动态信息交换消息:
                    return jT809_0x9200_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.从链路平台间信息交互消息:
                    return jT809_0x9300_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.从链路报警信息交互消息:
                    return jT809_0x9400_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.从链路车辆监管消息:
                    return jT809_0x9500_Formatter.Serialize(ref bytes, offset, value);
                case JT809BusinessType.从链路静态信息交换消息:
                    return jT809_0x9600_Formatter.Serialize(ref bytes, offset, value);
                default:
                    return offset;
            }
        }
    }
}
