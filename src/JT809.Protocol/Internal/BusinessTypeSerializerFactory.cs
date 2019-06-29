using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.Formatters.MessageBodyFormatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessageBody;
using JT809.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Internal
{
    static class BusinessTypeSerializerFactory
    {
        public static JT809Bodies Deserialize(this JT809BusinessType jT809BusinessType, ref JT809MessagePackReader reader,IJT809Config config)
        {
            switch (jT809BusinessType)
            {
                case JT809BusinessType.主链路登录请求消息:
                    return JT809_0x1001_Formatter.Instance.Deserialize(ref reader, config);
                case JT809BusinessType.主链路登录应答消息:
                    return JT809_0x1002_Formatter.Instance.Deserialize(ref reader,config);
                case JT809BusinessType.主链路注销请求消息:
                    return JT809_0x1003_Formatter.Instance.Deserialize(ref reader,config);
                case JT809BusinessType.主链路断开通知消息:
                    return JT809_0x1007_Formatter.Instance.Deserialize(ref reader,config);
                case JT809BusinessType.下级平台主动关闭链路通知消息:
                    return JT809_0x1008_Formatter.Instance.Deserialize(ref reader,config);
                case JT809BusinessType.主链路动态信息交换消息:
                    return JT809BodiesFormatter<JT809_0x1200>.Instance_0x1200.Deserialize(ref reader,config);
                case JT809BusinessType.主链路平台间信息交互消息:
                    return JT809_0x1300_Formatter.Instance.Deserialize(ref reader,config);
                case JT809BusinessType.主链路报警信息交互消息:
                    return JT809BodiesFormatter<JT809_0x1400>.Instance_0x1400.Deserialize(ref reader,config);
                case JT809BusinessType.主链路车辆监管消息:
                    return JT809BodiesFormatter<JT809_0x1500>.Instance_0x1500.Deserialize(ref reader,config);
                case JT809BusinessType.主链路静态信息交换消息:
                    return JT809BodiesFormatter<JT809_0x1600>.Instance_0x1600.Deserialize(ref reader,config);
                case JT809BusinessType.从链路连接请求消息:
                    return JT809_0x9001_Formatter.Instance.Deserialize(ref reader,config);
                case JT809BusinessType.从链路连接应答消息:
                    return JT809_0x9002_Formatter.Instance.Deserialize(ref reader,config);
                case JT809BusinessType.从链路注销请求消息:
                    return JT809_0x9003_Formatter.Instance.Deserialize(ref reader,config);
                case JT809BusinessType.从链路断开通知消息:
                    return JT809_0x9007_Formatter.Instance.Deserialize(ref reader,config);
                case JT809BusinessType.上级平台主动关闭链路通知消息:
                    return JT809_0x9008_Formatter.Instance.Deserialize(ref reader,config);
                case JT809BusinessType.接收定位信息数量通知消息:
                    return JT809_0x9101_Formatter.Instance.Deserialize(ref reader,config);
                case JT809BusinessType.从链路动态信息交换消息:
                    return JT809BodiesFormatter<JT809_0x9200>.Instance_0x9200.Deserialize(ref reader,config);
                case JT809BusinessType.从链路平台间信息交互消息:
                    return JT809_0x9300_Formatter.Instance.Deserialize(ref reader,config);
                case JT809BusinessType.从链路报警信息交互消息:
                    return JT809BodiesFormatter<JT809_0x9400>.Instance_0x9400.Deserialize(ref reader,config);
                case JT809BusinessType.从链路车辆监管消息:
                    return JT809BodiesFormatter<JT809_0x9500>.Instance_0x9500.Deserialize(ref reader,config);
                case JT809BusinessType.从链路静态信息交换消息:
                    return JT809BodiesFormatter<JT809_0x9600>.Instance_0x9600.Deserialize(ref reader,config);
                default:
                    return default;
            }
        }

        public static void Serialize(this JT809BusinessType jT809BusinessType, ref JT809MessagePackWriter writer, object value,IJT809Config config)
        {
            switch (jT809BusinessType)
            {
                case JT809BusinessType.主链路登录请求消息:
                    JT809_0x1001_Formatter.Instance.Serialize(ref writer, (JT809_0x1001)value, config);
                    break;
                case JT809BusinessType.主链路登录应答消息:
                    JT809_0x1002_Formatter.Instance.Serialize(ref writer, (JT809_0x1002)value, config);
                    break;
                case JT809BusinessType.主链路注销请求消息:
                    JT809_0x1003_Formatter.Instance.Serialize(ref writer, (JT809_0x1003)value, config);
                    break;
                case JT809BusinessType.主链路断开通知消息:
                    JT809_0x1007_Formatter.Instance.Serialize(ref writer, (JT809_0x1007)value, config);
                    break;
                case JT809BusinessType.下级平台主动关闭链路通知消息:
                    JT809_0x1008_Formatter.Instance.Serialize(ref writer, (JT809_0x1008)value, config);
                    break;
                case JT809BusinessType.主链路动态信息交换消息:
                    JT809BodiesFormatter<JT809_0x1200>.Instance_0x1200.Serialize(ref writer, (JT809_0x1200)value, config);
                    break;
                case JT809BusinessType.主链路平台间信息交互消息:
                    JT809_0x1300_Formatter.Instance.Serialize(ref writer, (JT809_0x1300)value, config);
                    break;
                case JT809BusinessType.主链路报警信息交互消息:
                    JT809BodiesFormatter<JT809_0x1400>.Instance_0x1400.Serialize(ref writer, (JT809_0x1400)value, config);
                    break;
                case JT809BusinessType.主链路车辆监管消息:
                    JT809BodiesFormatter<JT809_0x1500>.Instance_0x1500.Serialize(ref writer,(JT809_0x1500) value, config);
                    break;
                case JT809BusinessType.主链路静态信息交换消息:
                    JT809BodiesFormatter<JT809_0x1600>.Instance_0x1600.Serialize(ref writer,(JT809_0x1600) value, config);
                    break;
                case JT809BusinessType.从链路连接请求消息:
                    JT809_0x9001_Formatter.Instance.Serialize(ref writer, (JT809_0x9001)value, config);
                    break;
                case JT809BusinessType.从链路连接应答消息:
                     JT809_0x9002_Formatter.Instance.Serialize(ref writer, (JT809_0x9002)value, config);
                    break;
                case JT809BusinessType.从链路注销请求消息:
                     JT809_0x9003_Formatter.Instance.Serialize(ref writer, (JT809_0x9003)value, config);
                    break;
                case JT809BusinessType.从链路断开通知消息:
                    JT809_0x9007_Formatter.Instance.Serialize(ref writer, (JT809_0x9007)value, config);
                    break;
                case JT809BusinessType.上级平台主动关闭链路通知消息:
                    JT809_0x9008_Formatter.Instance.Serialize(ref writer, (JT809_0x9008)value, config);
                    break;
                case JT809BusinessType.接收定位信息数量通知消息:
                    JT809_0x9101_Formatter.Instance.Serialize(ref writer, (JT809_0x9101)value, config);
                    break;
                case JT809BusinessType.从链路动态信息交换消息:
                    JT809BodiesFormatter<JT809_0x9200>.Instance_0x9200.Serialize(ref writer, (JT809_0x9200)value, config);
                    break;
                case JT809BusinessType.从链路平台间信息交互消息:
                    JT809_0x9300_Formatter.Instance.Serialize(ref writer, (JT809_0x9300)value, config);
                    break;
                case JT809BusinessType.从链路报警信息交互消息:
                    JT809BodiesFormatter<JT809_0x9400>.Instance_0x9400.Serialize(ref writer, (JT809_0x9400)value, config);
                    break;
                case JT809BusinessType.从链路车辆监管消息:
                    JT809BodiesFormatter<JT809_0x9500>.Instance_0x9500.Serialize(ref writer, (JT809_0x9500)value, config);
                    break;
                case JT809BusinessType.从链路静态信息交换消息:
                    JT809BodiesFormatter<JT809_0x9600>.Instance_0x9600.Serialize(ref writer, (JT809_0x9600)value, config);
                    break;
            }
        }
    }
}
