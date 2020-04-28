
using JT809.Protocol.Enums;

namespace JT809.Protocol.Extensions
{
	/// <summary>
	/// 子命令包
	/// auto-generated
	/// </summary>
	public static partial class JT809SubPackageExtensions
    {

		/// <summary>
		/// 4608
		/// UP_EXG_MSG_REGISTER - 上传车辆注册信息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1200_0x1201 Create_上传车辆注册信息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1200_0x1201 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1200_0x1201>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 4608
		/// UP_EXG_MSG_REAL_LOCATION - 实时上传车辆定位信息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1200_0x1202 Create_实时上传车辆定位信息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1200_0x1202 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1200_0x1202>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 4608
		/// UP_EXG_MSG_HISTORY_LOCATION - 车辆定位信息自动补报请求消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1200_0x1203 Create_车辆定位信息自动补报请求消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1200_0x1203 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1200_0x1203>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 4608
		/// UP_EXG_MSG_RETURN_STARTUP_ACK - 启动车辆定位信息交换应答消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1200_0x1205 Create_启动车辆定位信息交换应答消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1200_0x1205 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1200_0x1205>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 4608
		/// UP_EXG_MSG_RETURN_END_ACK - 结束车辆定位信息交换应答消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1200_0x1206 Create_结束车辆定位信息交换应答消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1200_0x1206 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1200_0x1206>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 4608
		/// UP_EXG_MSG_APPLY_FOR_MONITOR_STARTUP - 申请交换指定车辆定位信息请求消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1200_0x1207 Create_申请交换指定车辆定位信息请求消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1200_0x1207 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1200_0x1207>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 4608
		/// UP_EXG_MSG_APPLY_FOR_MONITOR_END - 取消交换指定车辆定位信息请求
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1200_0x1208 Create_取消交换指定车辆定位信息请求(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1200_0x1208 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1200_0x1208>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 4608
		/// UP_EXG_MSG_APPLY_HISGNSSDATA_REQ - 补发车辆定位信息请求
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1200_0x1209 Create_补发车辆定位信息请求(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1200_0x1209 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1200_0x1209>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 4608
		/// UP_EXG_MSG_REPORT_DRIVER_INFO_ACK - 上报驾驶员身份识别信息应答消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1200_0x120A Create_上报驾驶员身份识别信息应答消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1200_0x120A subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1200_0x120A>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 4608
		/// UP_EXG_MSG_TAKE_EWAYBILL_ACK - 上报车辆电子运单应答消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1200_0x120B Create_上报车辆电子运单应答消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1200_0x120B subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1200_0x120B>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 4608
		/// UP_EXG_MSG_REPORT_DRIVER_INFO - 主动上报驾驶员身份信息消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1200_0x120C Create_主动上报驾驶员身份信息消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1200_0x120C subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1200_0x120C>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 4608
		/// UP_EXG_MSG_REPORT_EWAYBILL_INFO - 主动上报车辆电子运单信息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1200_0x120D Create_主动上报车辆电子运单信息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1200_0x120D subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1200_0x120D>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 4608
		/// UP_BASE_MSG_DRVLINE_INFO - 主动上报车辆行驶路线信息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1200_0x120E Create_主动上报车辆行驶路线信息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1200_0x120E subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1200_0x120E>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 4864
		/// UP_PLATFORM_MSG_POST_QUERY_ACK - 平台查岗应答消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1300_0x1301 Create_平台查岗应答消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1300_0x1301 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1300_0x1301>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 4864
		/// UP_PLATFORM_MSG_INFO_ACK - 下发平台间报文应答消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1300_0x1302 Create_下发平台间报文应答消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1300_0x1302 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1300_0x1302>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 4864
		/// UP_PLATFORM_MSG_RETRAN_REQ - 上传平台间消息补传请求消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1300_0x1303 Create_上传平台间消息补传请求消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1300_0x1303 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1300_0x1303>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 5120
		/// UP_WARN_MSG_URGE_TODO_ACK - 报警督办应答消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1400_0x1401 Create_报警督办应答消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1400_0x1401 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1400_0x1401>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 5120
		/// UP_WARN_MSG_ADPT_INFO - 上报报警信息消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1400_0x1402 Create_上报报警信息消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1400_0x1402 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1400_0x1402>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 5120
		/// UP_WARN_MSG_ADPT_TODO_INFO_2013_UP_WARN_MSG_INFORM_TIPS_2019 - 主动上报报警处理结果信息2013_上报报警预警信息2019
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1400_0x1403 Create_主动上报报警处理结果信息2013_上报报警预警信息2019(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1400_0x1403 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1400_0x1403>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 5120
		/// UP_WARN_MSG_URGE_TODO_ACK_INFO - 上报报警督办应答消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1400_0x1411 Create_上报报警督办应答消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1400_0x1411 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1400_0x1411>(jT809SubBusinessType,subBodies);
		}
        /// <summary>
        /// 5120
        /// UP_WARN_MSG_ADPT_TODO_INFO - 主动上报报警处理结果消息
        /// auto-generated
        /// </summary>
        public static JT809.Protocol.SubMessageBody.JT809_0x1400_0x1412 Create_主动上报报警处理结果消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1400_0x1412 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1400_0x1412>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 5120
		/// UP_WARN_MSG_URGE_TODO_REQ_INFO - 上报报警督办请求消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1400_0x1413 Create_上报报警督办请求消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1400_0x1413 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1400_0x1413>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 5376
		/// UP_CTRL_MSG_MONITOR_VEHICLE_ACK - 车辆单向监听应答
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1500_0x1501 Create_车辆单向监听应答(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1500_0x1501 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1500_0x1501>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 5376
		/// UP_CTRL_MSG_TAKE_PHOTO_ACK - 车辆拍照应答
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1500_0x1502 Create_车辆拍照应答(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1500_0x1502 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1500_0x1502>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 5376
		/// UP_CTRL_MSG_TEXT_INFO_ACK - 下发车辆报文应答消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1500_0x1503 Create_下发车辆报文应答消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1500_0x1503 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1500_0x1503>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 5376
		/// UP_CTRL_MSG_TAKE_TRAVEL_ACK - 上报车辆行驶记录应答消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1500_0x1504 Create_上报车辆行驶记录应答消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1500_0x1504 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1500_0x1504>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 5376
		/// UP_CTRL_MSG_EMERGENCY_MONITORING_ACK - 车辆应急接入监管平台应答消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1500_0x1505 Create_车辆应急接入监管平台应答消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1500_0x1505 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1500_0x1505>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 5632
		/// UP_BASE_MSG_VEHICLE_ADDED_ACK - 补报车辆静态信息应答
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1600_0x1601 Create_补报车辆静态信息应答(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1600_0x1601 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1600_0x1601>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 5632
		/// UP_BASE_MSG_DRVLINE_ADDED_REQ - 补报车辆行驶路线信息应答消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x1600_0x1602 Create_补报车辆行驶路线信息应答消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x1600_0x1602 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x1600_0x1602>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37376
		/// DOWN_EXG_MSG_REGISTER_ACK - 车辆注册信息应答消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9200_0x9201 Create_车辆注册信息应答消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9200_0x9201 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9200_0x9201>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37376
		/// DOWN_EXG_MSG_CAR_LOCATION - 交换车辆定位信息消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9200_0x9202 Create_交换车辆定位信息消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9200_0x9202 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9200_0x9202>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37376
		/// DOWN_EXG_MSG_HISTORY_ARCOSSAREA - 车辆定位信息交换补发消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9200_0x9203 Create_车辆定位信息交换补发消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9200_0x9203 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9200_0x9203>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37376
		/// DOWN_EXG_MSG_CAR_INFO - 交换车辆静态信息消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9200_0x9204 Create_交换车辆静态信息消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9200_0x9204 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9200_0x9204>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37376
		/// DOWN_EXG_MSG_RETURN_STARTUP - 启动车辆定位信息交换请求消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9200_0x9205 Create_启动车辆定位信息交换请求消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9200_0x9205 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9200_0x9205>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37376
		/// DOWN_EXG_MSG_RETURN_END - 结束车辆定位信息交换请求
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9200_0x9206 Create_结束车辆定位信息交换请求(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9200_0x9206 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9200_0x9206>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37376
		/// DOWN_EXG_MSG_APPLY_FOR_MONITOR_STARTUP_ACK - 申请交换指定车辆定位信息应答
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9200_0x9207 Create_申请交换指定车辆定位信息应答(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9200_0x9207 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9200_0x9207>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37376
		/// DOWN_EXG_MSG_APPLY_FOR_MONITOR_END_ACK - 取消交换指定车辆定位信息应答
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9200_0x9208 Create_取消交换指定车辆定位信息应答(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9200_0x9208 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9200_0x9208>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37376
		/// DOWN_EXG_MSG_APPLY_HISGNSSDATA_ACK - 补发车辆定位信息应答
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9200_0x9209 Create_补发车辆定位信息应答(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9200_0x9209 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9200_0x9209>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37376
		/// DOWN_EXG_MSG_REPORT_DRIVER_INFO - 上报车辆驾驶员身份识别信息请求
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9200_0x920A Create_上报车辆驾驶员身份识别信息请求(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9200_0x920A subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9200_0x920A>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37376
		/// DOWN_EXG_MSG_TAKE_EWAYBILL_REQ - 上报车辆电子运单请求消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9200_0x920B Create_上报车辆电子运单请求消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9200_0x920B subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9200_0x920B>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37376
		/// DOWN_BASE_MSG_DRVLINE_REQ - 上报车辆车辆行驶路线请求
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9200_0x920C Create_上报车辆车辆行驶路线请求(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9200_0x920C subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9200_0x920C>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37376
		/// DOWN_BASE_MSG_DRVLINE_ACK - 车辆行驶线路请求应答
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9200_0x920D Create_车辆行驶线路请求应答(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9200_0x920D subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9200_0x920D>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37632
		/// DOWN_PLATFORM_MSG_POST_QUERY_REQ - 平台查岗请求
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9300_0x9301 Create_平台查岗请求(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9300_0x9301 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9300_0x9301>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37632
		/// DOWN_PLATFORM_MSG_INFO_REQ - 下发平台间报文请求
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9300_0x9302 Create_下发平台间报文请求(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9300_0x9302 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9300_0x9302>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37632
		/// DOWN_PLATFORM_MSG_RETRAN_REQ - 下发平台间消息补传请求消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9300_0x9303 Create_下发平台间消息补传请求消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9300_0x9303 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9300_0x9303>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37888
		/// DOWN_WARN_MSG_URGE_TODO_REQ - 报警督办请求消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9400_0x9401 Create_报警督办请求消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9400_0x9401 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9400_0x9401>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37888
		/// DOWN_WARN_MSG_INFORM_TIPS - 报警预警2013_下发报警预警消息2019
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9400_0x9402 Create_报警预警2013_下发报警预警消息2019(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9400_0x9402 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9400_0x9402>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 37888
		/// DOWN_WARN_MSG_EXG_INFORM - 实时交换报警信息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9400_0x9403 Create_实时交换报警信息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9400_0x9403 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9400_0x9403>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 38144
		/// DOWN_CTRL_MSG_MONITOR_VEHICLE_REQ - 车辆单向监听请求消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9500_0x9501 Create_车辆单向监听请求消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9500_0x9501 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9500_0x9501>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 38144
		/// DOWN_CTRL_MSG_TAKE_PHOTO_REQ - 车辆拍照请求消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9500_0x9502 Create_车辆拍照请求消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9500_0x9502 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9500_0x9502>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 38144
		/// DOWN_CTRL_MSG_TEXT_INFO - 下发车辆报文请求
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9500_0x9503 Create_下发车辆报文请求(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9500_0x9503 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9500_0x9503>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 38144
		/// DOWN_CTRL_MSG_TAKE_TRAVEL_REQ - 上报车辆行驶记录请求消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9500_0x9504 Create_上报车辆行驶记录请求消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9500_0x9504 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9500_0x9504>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 38144
		/// DOWN_CTRL_MSG_EMERGENCY_MONITORING_REQ - 车辆应急接入监管平台请求消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9500_0x9505 Create_车辆应急接入监管平台请求消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9500_0x9505 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9500_0x9505>(jT809SubBusinessType,subBodies);
		}
		/// <summary>
		/// 38400
		/// DOWN_BASE_MSG_VEHICLE_ADDED - 补报车辆静态信息请求消息
		/// auto-generated
		/// </summary>
	    public static JT809.Protocol.SubMessageBody.JT809_0x9600_0x9601 Create_补报车辆静态信息请求消息(this JT809SubBusinessType jT809SubBusinessType,JT809.Protocol.SubMessageBody.JT809_0x9600_0x9601 subBodies)
		{
			return Create<JT809.Protocol.SubMessageBody.JT809_0x9600_0x9601>(jT809SubBusinessType,subBodies);
		}
	}
}