using JT809.Protocol.Enums;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;

namespace JT809.Protocol.Internal
{
    static class SubBodiesTypeSerializerFactory
    {
        static JT809_0x1200_0x1201_Formatter jT809_0X1200_0X1201_Formatter = new JT809_0x1200_0x1201_Formatter();
        static JT809_0x1200_0x1202_Formatter jT809_0X1200_0X1202_Formatter = new JT809_0x1200_0x1202_Formatter();
        static JT809_0x1200_0x1203_Formatter jT809_0X1200_0X1203_Formatter = new JT809_0x1200_0x1203_Formatter();
        static JT809_0x1200_0x1207_Formatter jT809_0X1200_0X1207_Formatter = new JT809_0x1200_0x1207_Formatter();
        static JT809_0x1200_0x1209_Formatter jT809_0X1200_0X1209_Formatter = new JT809_0x1200_0x1209_Formatter();
        static JT809_0x1200_0x120A_Formatter jT809_0X1200_0X120A_Formatter = new JT809_0x1200_0x120A_Formatter();
        static JT809_0x1200_0x120B_Formatter jT809_0X1200_0X120B_Formatter = new JT809_0x1200_0x120B_Formatter();
        static JT809_0x1200_0x120C_Formatter jT809_0X1200_0X120C_Formatter = new JT809_0x1200_0x120C_Formatter();
        static JT809_0x1200_0x120D_Formatter jT809_0X1200_0X120D_Formatter = new JT809_0x1200_0x120D_Formatter();
        static JT809_0x1300_0x1301_Formatter jT809_0X1300_0X1301_Formatter = new JT809_0x1300_0x1301_Formatter();
        static JT809_0x1300_0x1302_Formatter jT809_0X1300_0X1302_Formatter = new JT809_0x1300_0x1302_Formatter();
        static JT809_0x1400_0x1401_Formatter jT809_0X1400_0X1401_Formatter = new JT809_0x1400_0x1401_Formatter();
        static JT809_0x1400_0x1402_Formatter jT809_0X1400_0X1402_Formatter = new JT809_0x1400_0x1402_Formatter();
        static JT809_0x1400_0x1403_Formatter jT809_0X1400_0X1403_Formatter = new JT809_0x1400_0x1403_Formatter();
        static JT809_0x1500_0x1501_Formatter jT809_0X1500_0X1501_Formatter = new JT809_0x1500_0x1501_Formatter();
        static JT809_0x1500_0x1502_Formatter jT809_0X1500_0X1502_Formatter = new JT809_0x1500_0x1502_Formatter();
        static JT809_0x1500_0x1503_Formatter jT809_0X1500_0X1503_Formatter = new JT809_0x1500_0x1503_Formatter();
        static JT809_0x1500_0x1504_Formatter jT809_0X1500_0X1504_Formatter = new JT809_0x1500_0x1504_Formatter();
        static JT809_0x1500_0x1505_Formatter jT809_0X1500_0X1505_Formatter = new JT809_0x1500_0x1505_Formatter();
        static JT809_0x1600_0x1601_Formatter jT809_0X1600_0X1601_Formatter = new JT809_0x1600_0x1601_Formatter();

        static JT809_0x9200_0x9202_Formatter jT809_0X9200_0X9202_Formatter = new JT809_0x9200_0x9202_Formatter();
        static JT809_0x9200_0x9203_Formatter jT809_0X9200_0X9203_Formatter = new JT809_0x9200_0x9203_Formatter();
        static JT809_0x9200_0x9204_Formatter jT809_0X9200_0X9204_Formatter = new JT809_0x9200_0x9204_Formatter();
        static JT809_0x9200_0x9205_Formatter jT809_0X9200_0X9205_Formatter = new JT809_0x9200_0x9205_Formatter();
        static JT809_0x9200_0x9206_Formatter jT809_0X9200_0X9206_Formatter = new JT809_0x9200_0x9206_Formatter();
        static JT809_0x9200_0x9207_Formatter jT809_0X9200_0X9207_Formatter = new JT809_0x9200_0x9207_Formatter();
        static JT809_0x9200_0x9208_Formatter jT809_0X9200_0X9208_Formatter = new JT809_0x9200_0x9208_Formatter();
        static JT809_0x9200_0x9209_Formatter jT809_0X9200_0X9209_Formatter = new JT809_0x9200_0x9209_Formatter();
        static JT809_0x9300_0x9301_Formatter jT809_0X9300_0X9301_Formatter = new JT809_0x9300_0x9301_Formatter();
        static JT809_0x9300_0x9302_Formatter jT809_0X9300_0X9302_Formatter = new JT809_0x9300_0x9302_Formatter();
        static JT809_0x9400_0x9401_Formatter jT809_0X9400_0X9401_Formatter = new JT809_0x9400_0x9401_Formatter();
        static JT809_0x9400_0x9402_Formatter jT809_0X9400_0X9402_Formatter = new JT809_0x9400_0x9402_Formatter();
        static JT809_0x9400_0x9403_Formatter jT809_0X9400_0X9403_Formatter = new JT809_0x9400_0x9403_Formatter();
        static JT809_0x9500_0x9501_Formatter jT809_0X9500_0X9501_Formatter = new JT809_0x9500_0x9501_Formatter();
        static JT809_0x9500_0x9502_Formatter jT809_0X9500_0X9502_Formatter = new JT809_0x9500_0x9502_Formatter();
        static JT809_0x9500_0x9503_Formatter jT809_0X9500_0X9503_Formatter = new JT809_0x9500_0x9503_Formatter();
        static JT809_0x9500_0x9504_Formatter jT809_0X9500_0X9504_Formatter = new JT809_0x9500_0x9504_Formatter();
        static JT809_0x9500_0x9505_Formatter jT809_0X9500_0X9505_Formatter = new JT809_0x9500_0x9505_Formatter();


        public static JT809SubBodies Deserialize(this JT809SubBusinessType jT809SubBusinessType, ReadOnlySpan<byte> bytes, out int readSize)
        {
            switch (jT809SubBusinessType)
            {
                case JT809SubBusinessType.上传车辆注册信息:
                    return jT809_0X1200_0X1201_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.实时上传车辆定位信息:
                    return jT809_0X1200_0X1202_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.车辆定位信息自动补报:
                    return jT809_0X1200_0X1203_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.申请交换指定车辆定位信息请求:
                    return jT809_0X1200_0X1207_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.补发车辆定位信息请求:
                    return jT809_0X1200_0X1209_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.上报车辆驾驶员身份识别信息应答:
                    return jT809_0X1200_0X120A_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.上报车辆电子运单应答:
                    return jT809_0X1200_0X120B_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.主动上报驾驶员身份信息:
                    return jT809_0X1200_0X120C_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.主动上报车辆电子运单信息:
                    return jT809_0X1200_0X120D_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.平台查岗应答:
                    return jT809_0X1300_0X1301_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.下发平台间报文应答:
                    return jT809_0X1300_0X1302_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.报警督办应答:
                    return jT809_0X1400_0X1401_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.上报报警信息:
                    return jT809_0X1400_0X1402_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.主动上报报警处理结果信息:
                    return jT809_0X1400_0X1403_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.车辆单向监听应答:
                    return jT809_0X1500_0X1501_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.车辆拍照应答:
                    return jT809_0X1500_0X1502_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.下发车辆报文应答:
                    return jT809_0X1500_0X1503_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.上报车辆行驶记录应答:
                    return jT809_0X1500_0X1504_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.车辆应急接入监管平台应答消息:
                    return jT809_0X1500_0X1505_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.补报车辆静态信息应答:
                    return jT809_0X1600_0X1601_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.交换车辆定位信息:
                    return jT809_0X9200_0X9202_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.车辆定位信息交换补发:
                    return jT809_0X9200_0X9203_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.交换车辆静态信息:
                    return jT809_0X9200_0X9204_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.启动车辆定位信息交换请求:
                    return jT809_0X9200_0X9205_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.结束车辆定位信息交换请求:
                    return jT809_0X9200_0X9206_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.申请交换指定车辆定位信息应答:
                    return jT809_0X9200_0X9207_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.取消交换指定车辆定位信息应答:
                    return jT809_0X9200_0X9208_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.补发车辆定位信息应答:
                    return jT809_0X9200_0X9209_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.平台查岗请求:
                    return jT809_0X9300_0X9301_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.下发平台间报文请求:
                    return jT809_0X9300_0X9302_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.报警督办请求:
                    return jT809_0X9400_0X9401_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.报警预警:
                    return jT809_0X9400_0X9402_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.实时交换报警信息:
                    return jT809_0X9400_0X9403_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.车辆单向监听请求:
                    return jT809_0X9500_0X9501_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.车辆拍照请求:
                    return jT809_0X9500_0X9502_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.下发车辆报文请求:
                    return jT809_0X9500_0X9503_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.上报车辆行驶记录请求:
                    return jT809_0X9500_0X9504_Formatter.Deserialize(bytes, out readSize);
                case JT809SubBusinessType.车辆应急接入监管平台请求消息:
                    return jT809_0X9500_0X9505_Formatter.Deserialize(bytes, out readSize);
                default:
                    readSize = 0;
                    return default;
            }
        }

        public static int Serialize(this JT809SubBusinessType jT809SubBusinessType, ref byte[] bytes, int offset, dynamic value)
        {
            switch (jT809SubBusinessType)
            {
                case JT809SubBusinessType.上传车辆注册信息:
                    return jT809_0X1200_0X1201_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.实时上传车辆定位信息:
                    return jT809_0X1200_0X1202_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.车辆定位信息自动补报:
                    return jT809_0X1200_0X1203_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.申请交换指定车辆定位信息请求:
                    return jT809_0X1200_0X1207_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.补发车辆定位信息请求:
                    return jT809_0X1200_0X1209_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.上报车辆驾驶员身份识别信息应答:
                    return jT809_0X1200_0X120A_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.上报车辆电子运单应答:
                    return jT809_0X1200_0X120B_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.主动上报驾驶员身份信息:
                    return jT809_0X1200_0X120C_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.主动上报车辆电子运单信息:
                    return jT809_0X1200_0X120D_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.平台查岗应答:
                    return jT809_0X1300_0X1301_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.下发平台间报文应答:
                    return jT809_0X1300_0X1302_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.报警督办应答:
                    return jT809_0X1400_0X1401_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.上报报警信息:
                    return jT809_0X1400_0X1402_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.主动上报报警处理结果信息:
                    return jT809_0X1400_0X1403_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.车辆单向监听应答:
                    return jT809_0X1500_0X1501_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.车辆拍照应答:
                    return jT809_0X1500_0X1502_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.下发车辆报文应答:
                    return jT809_0X1500_0X1503_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.上报车辆行驶记录应答:
                    return jT809_0X1500_0X1504_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.车辆应急接入监管平台应答消息:
                    return jT809_0X1500_0X1505_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.补报车辆静态信息应答:
                    return jT809_0X1600_0X1601_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.交换车辆定位信息:
                    return jT809_0X9200_0X9202_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.车辆定位信息交换补发:
                    return jT809_0X9200_0X9203_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.交换车辆静态信息:
                    return jT809_0X9200_0X9204_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.启动车辆定位信息交换请求:
                    return jT809_0X9200_0X9205_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.结束车辆定位信息交换请求:
                    return jT809_0X9200_0X9206_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.申请交换指定车辆定位信息应答:
                    return jT809_0X9200_0X9207_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.取消交换指定车辆定位信息应答:
                    return jT809_0X9200_0X9208_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.补发车辆定位信息应答:
                    return jT809_0X9200_0X9209_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.平台查岗请求:
                    return jT809_0X9300_0X9301_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.下发平台间报文请求:
                    return jT809_0X9300_0X9302_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.报警督办请求:
                    return jT809_0X9400_0X9401_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.报警预警:
                    return jT809_0X9400_0X9402_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.实时交换报警信息:
                    return jT809_0X9400_0X9403_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.车辆单向监听请求:
                    return jT809_0X9500_0X9501_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.车辆拍照请求:
                    return jT809_0X9500_0X9502_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.下发车辆报文请求:
                    return jT809_0X9500_0X9503_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.上报车辆行驶记录请求:
                    return jT809_0X9500_0X9504_Formatter.Serialize(ref bytes, offset, value);
                case JT809SubBusinessType.车辆应急接入监管平台请求消息:
                    return jT809_0X9500_0X9505_Formatter.Serialize(ref bytes, offset, value);
                default:
                    return offset;
            }
        }
    }
}
