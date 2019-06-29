using JT809.Protocol.Enums;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using JT809.Protocol.SubMessageBody;
using System;

namespace JT809.Protocol.Internal
{
    static class SubBodiesTypeSerializerFactory
    {
        public static JT809SubBodies Deserialize(this JT809SubBusinessType jT809SubBusinessType, ref JT809MessagePackReader reader, IJT809Config config)
        {
            switch (jT809SubBusinessType)
            {
                case JT809SubBusinessType.上传车辆注册信息:
                    return JT809_0x1200_0x1201_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.实时上传车辆定位信息:
                    return JT809_0x1200_0x1202_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.车辆定位信息自动补报:
                    return JT809_0x1200_0x1203_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.申请交换指定车辆定位信息请求:
                    return JT809_0x1200_0x1207_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.补发车辆定位信息请求:
                    return JT809_0x1200_0x1209_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.上报车辆驾驶员身份识别信息应答:
                    return JT809_0x1200_0x120A_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.上报车辆电子运单应答:
                    return JT809_0x1200_0x120B_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.主动上报驾驶员身份信息:
                    return JT809_0x1200_0x120C_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.主动上报车辆电子运单信息:
                    return JT809_0x1200_0x120D_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.平台查岗应答:
                    return JT809_0x1300_0x1301_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.下发平台间报文应答:
                    return JT809_0x1300_0x1302_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.报警督办应答:
                    return JT809_0x1400_0x1401_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.上报报警信息:
                    return JT809_0x1400_0x1402_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.主动上报报警处理结果信息:
                    return JT809_0x1400_0x1403_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.车辆单向监听应答:
                    return JT809_0x1500_0x1501_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.车辆拍照应答:
                    return JT809_0x1500_0x1502_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.下发车辆报文应答:
                    return JT809_0x1500_0x1503_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.上报车辆行驶记录应答:
                    return JT809_0x1500_0x1504_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.车辆应急接入监管平台应答消息:
                    return JT809_0x1500_0x1505_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.补报车辆静态信息应答:
                    return JT809_0x1600_0x1601_Formatter.Instance.Deserialize(ref reader,config);
                case JT809SubBusinessType.交换车辆定位信息:
                    return JT809_0x9200_0x9202_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.车辆定位信息交换补发:
                    return JT809_0x9200_0x9203_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.交换车辆静态信息:
                    return JT809_0x9200_0x9204_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.启动车辆定位信息交换请求:
                    return JT809_0x9200_0x9205_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.结束车辆定位信息交换请求:
                    return JT809_0x9200_0x9206_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.申请交换指定车辆定位信息应答:
                    return JT809_0x9200_0x9207_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.取消交换指定车辆定位信息应答:
                    return JT809_0x9200_0x9208_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.补发车辆定位信息应答:
                    return JT809_0x9200_0x9209_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.平台查岗请求:
                    return JT809_0x9300_0x9301_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.下发平台间报文请求:
                    return JT809_0x9300_0x9302_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.报警督办请求:
                    return JT809_0x9400_0x9401_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.报警预警:
                    return JT809_0x9400_0x9402_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.实时交换报警信息:
                    return JT809_0x9400_0x9403_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.车辆单向监听请求:
                    return JT809_0x9500_0x9501_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.车辆拍照请求:
                    return JT809_0x9500_0x9502_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.下发车辆报文请求:
                    return JT809_0x9500_0x9503_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.上报车辆行驶记录请求:
                    return JT809_0x9500_0x9504_Formatter.Instance.Deserialize(ref reader, config);
                case JT809SubBusinessType.车辆应急接入监管平台请求消息:
                    return JT809_0x9500_0x9505_Formatter.Instance.Deserialize(ref reader, config);
                default:
                    return default;
            }
        }

        public static void Serialize(this JT809SubBusinessType jT809SubBusinessType, ref JT809MessagePackWriter writer, object value, IJT809Config config)
        {
            switch (jT809SubBusinessType)
            {
                case JT809SubBusinessType.上传车辆注册信息:
                     JT809_0x1200_0x1201_Formatter.Instance.Serialize(ref writer, (JT809_0x1200_0x1201)value, config);
                    break;
                case JT809SubBusinessType.实时上传车辆定位信息:
                     JT809_0x1200_0x1202_Formatter.Instance.Serialize(ref writer,(JT809_0x1200_0x1202)value, config);
                    break;
                case JT809SubBusinessType.车辆定位信息自动补报:
                     JT809_0x1200_0x1203_Formatter.Instance.Serialize(ref writer,(JT809_0x1200_0x1203)value, config);
                    break;
                case JT809SubBusinessType.申请交换指定车辆定位信息请求:
                     JT809_0x1200_0x1207_Formatter.Instance.Serialize(ref writer,(JT809_0x1200_0x1207)value, config);
                    break;
                case JT809SubBusinessType.补发车辆定位信息请求:
                     JT809_0x1200_0x1209_Formatter.Instance.Serialize(ref writer,(JT809_0x1200_0x1209)value, config);
                    break;
                case JT809SubBusinessType.上报车辆驾驶员身份识别信息应答:
                     JT809_0x1200_0x120A_Formatter.Instance.Serialize(ref writer,(JT809_0x1200_0x120A)value, config);
                    break;
                case JT809SubBusinessType.上报车辆电子运单应答:
                     JT809_0x1200_0x120B_Formatter.Instance.Serialize(ref writer,(JT809_0x1200_0x120B)value, config);
                    break;
                case JT809SubBusinessType.主动上报驾驶员身份信息:
                     JT809_0x1200_0x120C_Formatter.Instance.Serialize(ref writer, (JT809_0x1200_0x120C)value, config);
                    break;
                case JT809SubBusinessType.主动上报车辆电子运单信息:
                     JT809_0x1200_0x120D_Formatter.Instance.Serialize(ref writer,(JT809_0x1200_0x120D)value, config);
                    break;
                case JT809SubBusinessType.平台查岗应答:
                     JT809_0x1300_0x1301_Formatter.Instance.Serialize(ref writer, (JT809_0x1300_0x1301)value, config);
                    break;
                case JT809SubBusinessType.下发平台间报文应答:
                     JT809_0x1300_0x1302_Formatter.Instance.Serialize(ref writer, (JT809_0x1300_0x1302)value, config);
                    break;
                case JT809SubBusinessType.报警督办应答:
                     JT809_0x1400_0x1401_Formatter.Instance.Serialize(ref writer, (JT809_0x1400_0x1401)value, config);
                    break;
                case JT809SubBusinessType.上报报警信息:
                     JT809_0x1400_0x1402_Formatter.Instance.Serialize(ref writer, (JT809_0x1400_0x1402)value, config);
                    break;
                case JT809SubBusinessType.主动上报报警处理结果信息:
                     JT809_0x1400_0x1403_Formatter.Instance.Serialize(ref writer, (JT809_0x1400_0x1403)value, config);
                    break;
                case JT809SubBusinessType.车辆单向监听应答:
                     JT809_0x1500_0x1501_Formatter.Instance.Serialize(ref writer, (JT809_0x1500_0x1501)value, config);
                    break;
                case JT809SubBusinessType.车辆拍照应答:
                     JT809_0x1500_0x1502_Formatter.Instance.Serialize(ref writer, (JT809_0x1500_0x1502)value, config);
                    break;
                case JT809SubBusinessType.下发车辆报文应答:
                     JT809_0x1500_0x1503_Formatter.Instance.Serialize(ref writer, (JT809_0x1500_0x1503)value, config);
                    break;
                case JT809SubBusinessType.上报车辆行驶记录应答:
                     JT809_0x1500_0x1504_Formatter.Instance.Serialize(ref writer,(JT809_0x1500_0x1504) value, config);
                    break;
                case JT809SubBusinessType.车辆应急接入监管平台应答消息:
                     JT809_0x1500_0x1505_Formatter.Instance.Serialize(ref writer, (JT809_0x1500_0x1505)value, config);
                    break;
                case JT809SubBusinessType.补报车辆静态信息应答:
                     JT809_0x1600_0x1601_Formatter.Instance.Serialize(ref writer, (JT809_0x1600_0x1601)value, config);
                    break;
                case JT809SubBusinessType.交换车辆定位信息:
                     JT809_0x9200_0x9202_Formatter.Instance.Serialize(ref writer, (JT809_0x9200_0x9202)value, config);
                    break;
                case JT809SubBusinessType.车辆定位信息交换补发:
                     JT809_0x9200_0x9203_Formatter.Instance.Serialize(ref writer, (JT809_0x9200_0x9203)value, config);
                    break;
                case JT809SubBusinessType.交换车辆静态信息:
                     JT809_0x9200_0x9204_Formatter.Instance.Serialize(ref writer, (JT809_0x9200_0x9204)value, config);
                    break;
                case JT809SubBusinessType.启动车辆定位信息交换请求:
                     JT809_0x9200_0x9205_Formatter.Instance.Serialize(ref writer, (JT809_0x9200_0x9205)value, config);
                    break;
                case JT809SubBusinessType.结束车辆定位信息交换请求:
                     JT809_0x9200_0x9206_Formatter.Instance.Serialize(ref writer, (JT809_0x9200_0x9206)value, config);
                    break;
                case JT809SubBusinessType.申请交换指定车辆定位信息应答:
                     JT809_0x9200_0x9207_Formatter.Instance.Serialize(ref writer, (JT809_0x9200_0x9207)value, config);
                    break;
                case JT809SubBusinessType.取消交换指定车辆定位信息应答:
                     JT809_0x9200_0x9208_Formatter.Instance.Serialize(ref writer, (JT809_0x9200_0x9208)value, config);
                    break;
                case JT809SubBusinessType.补发车辆定位信息应答:
                     JT809_0x9200_0x9209_Formatter.Instance.Serialize(ref writer, (JT809_0x9200_0x9209)value, config);
                    break;
                case JT809SubBusinessType.平台查岗请求:
                     JT809_0x9300_0x9301_Formatter.Instance.Serialize(ref writer, (JT809_0x9300_0x9301)value, config);
                    break;
                case JT809SubBusinessType.下发平台间报文请求:
                     JT809_0x9300_0x9302_Formatter.Instance.Serialize(ref writer, (JT809_0x9300_0x9302)value, config);
                    break;
                case JT809SubBusinessType.报警督办请求:
                     JT809_0x9400_0x9401_Formatter.Instance.Serialize(ref writer, (JT809_0x9400_0x9401)value, config);
                    break;
                case JT809SubBusinessType.报警预警:
                     JT809_0x9400_0x9402_Formatter.Instance.Serialize(ref writer, (JT809_0x9400_0x9402)value, config);
                    break;
                case JT809SubBusinessType.实时交换报警信息:
                     JT809_0x9400_0x9403_Formatter.Instance.Serialize(ref writer, (JT809_0x9400_0x9403)value, config);
                    break;
                case JT809SubBusinessType.车辆单向监听请求:
                     JT809_0x9500_0x9501_Formatter.Instance.Serialize(ref writer, (JT809_0x9500_0x9501)value, config);
                    break;
                case JT809SubBusinessType.车辆拍照请求:
                     JT809_0x9500_0x9502_Formatter.Instance.Serialize(ref writer, (JT809_0x9500_0x9502)value, config);
                    break;
                case JT809SubBusinessType.下发车辆报文请求:
                     JT809_0x9500_0x9503_Formatter.Instance.Serialize(ref writer, (JT809_0x9500_0x9503)value, config);
                    break;
                case JT809SubBusinessType.上报车辆行驶记录请求:
                     JT809_0x9500_0x9504_Formatter.Instance.Serialize(ref writer, (JT809_0x9500_0x9504)value, config);
                    break;
                case JT809SubBusinessType.车辆应急接入监管平台请求消息:
                     JT809_0x9500_0x9505_Formatter.Instance.Serialize(ref writer, (JT809_0x9500_0x9505)value, config);
                    break;
            }
        }
    }
}
