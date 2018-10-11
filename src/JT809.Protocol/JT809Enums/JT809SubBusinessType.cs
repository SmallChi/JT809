using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809SubMessageBody;
using System.ComponentModel;

namespace JT809.Protocol.JT809Enums
{
    ///<summary>
    ///子业务类型标识
    ///</summary>
    public enum JT809SubBusinessType : ushort
    {
        None=0x0000,
        #region 主链路动态信息交换消息 UP_EXG_MSG
        /// <summary>
        /// 上传车辆注册信息
        ///<para>UP_EXG_MSG_REGISTER</para>
        ///<para>JT809_0x1200_0x1201</para>
        ///<para>JT809_0x1200</para> 
        /// </summary>
        [Description("上传车辆注册信息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1201))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_REGISTER", "上传车辆注册信息", JT809BusinessType.主链路动态信息交换消息)]
        上传车辆注册信息 = 0x1201,
        ///<summary>
        ///实时上传车辆定位信息  
        ///<para>UP_EXG_MSG_REAL_LOCATION</para>
        ///<para>JT809_0x1200_0x1202</para>
        ///<para>JT809_0x1200</para> 
        ///</summary>
        [Description("实时上传车辆定位信息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1202))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_REAL_LOCATION", "实时上传车辆定位信息", JT809BusinessType.主链路动态信息交换消息)]
        实时上传车辆定位信息 = 0x1202,
        ///<summary>
        ///车辆定位信息自动补报
        ///<para>UP_EXG_MSG_HISTORY_LOCATION</para>
        ///<para>JT809_0x1200_0x1203</para>
        ///<para>JT809_0x1200</para> 
        ///</summary>
        [Description("车辆定位信息自动补报")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1203))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_HISTORY_LOCATION", "车辆定位信息自动补报", JT809BusinessType.主链路动态信息交换消息)]
        车辆定位信息自动补报 = 0x1203,
        ///<summary>
        ///启动车辆定位信息交换应答	
        ///<para>UP_EXG_MSG_RETURN_STARTUP_ACK</para>
        ///<para>JT809_0x1200_0x1205</para>
        ///<para>JT809_0x1200</para> 
        ///</summary>
        [Description("启动车辆定位信息交换应答")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1205))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_RETURN_STARTUP_ACK", "启动车辆定位信息交换应答", JT809BusinessType.主链路动态信息交换消息)]
        启动车辆定位信息交换应答 = 0x1205,
        ///<summary>
        ///结束车辆定位信息交换应答	
        ///<para>UP_EXG_MSG_RETURN_END_ACK</para>
        ///<para>JT809_0x1200_0x1206</para>
        ///<para>JT809_0x1200</para> 
        ///</summary>
        [Description("结束车辆定位信息交换应答")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1206))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_RETURN_END_ACK", "结束车辆定位信息交换应答", JT809BusinessType.主链路动态信息交换消息)]
        结束车辆定位信息交换应答 = 0x1206,
        ///<summary>
        ///申请交换指定车辆定位信息请求	
        ///<para>UP_EXG_MSG_APPLY_FOR_MONITOR_STARTUP</para>
        ///<para>JT809_0x1200_0x1207</para>
        ///<para>JT809_0x1200</para> 
        ///</summary>
        [Description("申请交换指定车辆定位信息请求")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1207))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_APPLY_FOR_MONITOR_STARTUP", "申请交换指定车辆定位信息请求", JT809BusinessType.主链路动态信息交换消息)]
        申请交换指定车辆定位信息请求 = 0x1207,
        ///<summary>
        ///取消交换指定车辆定位信息请求
        ///<para>UP_EXG_MSG_APPLY_FOR_MONITOR_END</para>
        ///<para>JT809_0x1200_0x1208</para>
        ///<para>JT809_0x1200</para> 
        ///</summary>
        [Description("取消交换指定车辆定位信息请求")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1208))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_APPLY_FOR_MONITOR_END", "取消交换指定车辆定位信息请求", JT809BusinessType.主链路动态信息交换消息)]
        取消交换指定车辆定位信息请求 = 0x1208,
        ///<summary>
        ///补发车辆定位信息请求
        ///<para>UP_EXG_MSG_APPLY_HISGNSSDATA_REQ</para>
        ///<para>JT809_0x1200_0x1209</para>
        ///<para>JT809_0x1200</para> 
        ///</summary>
        [Description("补发车辆定位信息请求")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1209))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_APPLY_HISGNSSDATA_REQ", "补发车辆定位信息请求", JT809BusinessType.主链路动态信息交换消息)]
        补发车辆定位信息请求 = 0x1209,
        ///<summary>
        ///上报车辆驾驶员身份识别信息应答
        ///<para>UP_EXG_MSG_REPORT_DRIVER_INFO_ACK</para>
        ///<para>JT809_0x1200_0x120A</para>
        ///<para>JT809_0x1200</para> 
        ///</summary>
        [Description("上报车辆驾驶员身份识别信息应答")]
        [JT809BodiesType(typeof(JT809_0x1200_0x120A))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_REPORT_DRIVER_INFO_ACK", "上报车辆驾驶员身份识别信息应答", JT809BusinessType.主链路动态信息交换消息)]
        上报车辆驾驶员身份识别信息应答 = 0x120A,
        ///<summary>
        ///上报车辆电子运单应答	
        ///<para>UP_EXG_MSG_TAKE_EWAYBILL_ACK</para>
        ///<para>JT809_0x1200_0x120B</para>
        ///<para>JT809_0x1200</para> 
        ///</summary>
        [Description("上报车辆电子运单应答")]
        [JT809BodiesType(typeof(JT809_0x1200_0x120B))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_TAKE_EWAYBILL_ACK", "上报车辆电子运单应答", JT809BusinessType.主链路动态信息交换消息)]
        上报车辆电子运单应答 = 0x120B,
        ///<summary>
        ///主动上报驾驶员身份信息	
        ///<para>UP_EXG_MSG_REPORT_DRIVER_INFO</para>
        ///<para>JT809_0x1200_0x120C</para>
        ///<para>JT809_0x1200</para> 
        ///</summary>
        [Description("主动上报驾驶员身份信息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x120C))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_REPORT_DRIVER_INFO", "主动上报驾驶员身份信息", JT809BusinessType.主链路动态信息交换消息)]
        主动上报驾驶员身份信息 = 0x120C,
        ///<summary>
        ///主动上报车辆电子运单信息	
        ///<para>UP_EXG_MSG_REPORT_EWAYBILL_INFO</para>
        ///<para>JT809_0x1200_0x120D</para>
        ///<para>JT809_0x1200</para>         
        ///</summary>
        [Description("主动上报车辆电子运单信息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x120D))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_REPORT_EWAYBILL_INFO", "主动上报车辆电子运单信息", JT809BusinessType.主链路动态信息交换消息)]
        主动上报车辆电子运单信息 = 0x120D,
        #endregion

        #region 从链路动态信息交换消息 DOWN_EXG_MSG
        ///<summary>
        ///交换车辆定位信息	
        ///<para>DOWN_EXG_MSG_CAR_LOCATION</para>
        ///<para>JT809_0x9200_0x9202</para>
        ///<para>JT809_0x9200</para>   
        ///</summary>
        [Description("交换车辆定位信息")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9202))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_CAR_LOCATION", "交换车辆定位信息", JT809BusinessType.从链路动态信息交换消息)]
        交换车辆定位信息 = 0x9202,
        ///<summary>
        ///车辆定位信息交换补发	
        ///<para>DOWN_EXG_MSG_HISTORY_ARCOSSAREA</para>
        ///<para>JT809_0x9200_0x9203</para>
        ///<para>JT809_0x9200</para>   
        ///</summary>
        [Description("车辆定位信息交换补发")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9203))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_HISTORY_ARCOSSAREA", "车辆定位信息交换补发", JT809BusinessType.从链路动态信息交换消息)]
        车辆定位信息交换补发 = 0x9203,
        ///<summary>
        ///交换车辆静态信息
        ///<para>DOWN_EXG_MSG_CAR_INFO</para>
        ///<para>JT809_0x9200_0x9204</para>
        ///<para>JT809_0x9200</para>   
        ///</summary>
        [Description("交换车辆静态信息")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9204))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_CAR_INFO", "交换车辆静态信息", JT809BusinessType.从链路动态信息交换消息)]
        交换车辆静态信息 = 0x9204,
        ///<summary>
        ///启动车辆定位信息交换请求
        ///<para>DOWN_EXG_MSG_RETURN_STARTUP</para>
        ///<para>JT809_0x9200_0x9205</para>
        ///<para>JT809_0x9200</para>   
        ///</summary>
        [Description("启动车辆定位信息交换请求")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9205))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_RETURN_STARTUP", "启动车辆定位信息交换请求", JT809BusinessType.从链路动态信息交换消息)]
        启动车辆定位信息交换请求 = 0x9205,
        ///<summary>
        ///结束车辆定位信息交换请求	
        ///<para>DOWN_EXG_MSG_RETURN_END</para>
        ///<para>JT809_0x9200_0x9206</para>
        ///<para>JT809_0x9200</para>   
        ///</summary>
        [Description("结束车辆定位信息交换请求")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9206))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_RETURN_END", "结束车辆定位信息交换请求", JT809BusinessType.从链路动态信息交换消息)]
        结束车辆定位信息交换请求 = 0x9206,
        ///<summary>
        ///申请交换指定车辆定位信息应答	
        ///<para>DOWN_EXG_MSG_APPLY_FOR_MONITOR_STARTUP_ACK</para>
        ///<para>JT809_0x9200_0x9207</para>
        ///<para>JT809_0x9200</para>   
        ///</summary>
        [Description("申请交换指定车辆定位信息应答")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9207))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_APPLY_FOR_MONITOR_STARTUP_ACK", "申请交换指定车辆定位信息应答", JT809BusinessType.从链路动态信息交换消息)]
        申请交换指定车辆定位信息应答 = 0x9207,
        ///<summary>
        ///取消交换指定车辆定位信息应答	
        ///<para>DOWN_EXG_MSG_APPLY_FOR_MONITOR_END_ACK</para>
        ///<para>JT809_0x9200_0x9208</para>
        ///<para>JT809_0x9200</para>
        ///</summary>
        [Description("取消交换指定车辆定位信息应答")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9208))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_APPLY_FOR_MONITOR_END_ACK", "取消交换指定车辆定位信息应答", JT809BusinessType.从链路动态信息交换消息)]
        取消交换指定车辆定位信息应答 = 0x9208,
        ///<summary>
        ///补发车辆定位信息应答	
        ///<para>DOWN_EXG_MSG_APPLY_HISGNSSDATA_ACK</para>
        ///<para>JT809_0x9200_0x9209</para>
        ///<para>JT809_0x9200</para>
        ///</summary>
        [Description("补发车辆定位信息应答")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9209))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_APPLY_HISGNSSDATA_ACK", "补发车辆定位信息应答", JT809BusinessType.从链路动态信息交换消息)]
        补发车辆定位信息应答 = 0x9209,
        ///<summary>
        ///上报车辆驾驶员身份识别信息请求	
        ///<para>DOWN_EXG_MSG_REPORT_DRIVER_INFO</para>
        ///<para>JT809_0x9200_0x920A</para>
        ///<para>JT809_0x9200</para>
        ///</summary>
        [Description("上报车辆驾驶员身份识别信息请求")]
        [JT809BodiesType(typeof(JT809_0x9200_0x920A))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_REPORT_DRIVER_INFO", "上报车辆驾驶员身份识别信息请求", JT809BusinessType.从链路动态信息交换消息)]
        上报车辆驾驶员身份识别信息请求 = 0x920A,
        ///<summary>
        ///上报车辆电子运单请求	
        ///<para>DOWN_EXG_MSG_TAKE_EWAYBILL_REQ</para>
        ///<para>JT809_0x9200_0x920B</para>
        ///<para>JT809_0x9200</para>
        ///</summary>
        [Description("上报车辆电子运单请求")]
        [JT809BodiesType(typeof(JT809_0x9200_0x920B))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_TAKE_EWAYBILL_REQ", "上报车辆电子运单请求", JT809BusinessType.从链路动态信息交换消息)]
        上报车辆电子运单请求 = 0x920B,
        #endregion

        #region 主链路平台信息交互消息 UP_PLATFORM_MSG
        ///<summary>
        ///平台查岗应答	
        ///<para>UP_PLATFORM_MSG_POST_QUERY_ACK</para>
        ///<para>JT809_0x1300_0x1301</para>
        ///<para>JT809_0x1300</para>
        ///</summary>
        [Description("平台查岗应答")]
        [JT809BodiesType(typeof(JT809_0x1300_0x1301))]
        [JT809SubBusinessTypeDescription("UP_PLATFORM_MSG_POST_QUERY_ACK", "平台查岗应答", JT809BusinessType.主链路平台间信息交互消息)]
        平台查岗应答 = 0x1301,
        ///<summary>
        ///下发平台间报文应答	
        ///<para>UP_PLATFORM_MSG_INFO_ACK</para>
        ///<para>JT809_0x1300_0x1302</para>
        ///<para>JT809_0x1300</para>
        ///</summary>
        [Description("下发平台间报文应答")]
        [JT809BodiesType(typeof(JT809_0x1300_0x1302))]
        [JT809SubBusinessTypeDescription("UP_PLATFORM_MSG_INFO_ACK", "下发平台间报文应答", JT809BusinessType.主链路平台间信息交互消息)]
        下发平台间报文应答 = 0x1302,
        #endregion

        #region 从链路平台信息交互消息 DOWN_PLATFORM_MSG
        ///<summary>
        ///平台查岗请求	
        ///<para>DOWN_PLATFORM_MSG_POST_QUERY_REQ</para>
        ///<para>JT809_0x9300_0x9301</para>
        ///<para>JT809_0x9300</para>
        ///</summary>
        [Description("平台查岗请求")]
        [JT809BodiesType(typeof(JT809_0x9300_0x9301))]
        [JT809SubBusinessTypeDescription("DOWN_PLATFORM_MSG_POST_QUERY_REQ", "平台查岗请求", JT809BusinessType.从链路平台间信息交互消息)]
        平台查岗请求 = 0x9301,
        ///<summary>
        ///下发平台间报文请求	
        ///<para>DOWN_PLATFORM_MSG_INFO_REQ</para>
        ///<para>JT809_0x9300_0x9302</para>
        ///<para>JT809_0x9300</para>
        ///</summary>
        [Description("下发平台间报文请求")]
        [JT809BodiesType(typeof(JT809_0x9300_0x9302))]
        [JT809SubBusinessTypeDescription("DOWN_PLATFORM_MSG_INFO_REQ", "下发平台间报文请求", JT809BusinessType.从链路平台间信息交互消息)]
        下发平台间报文请求 = 0x9302,
        #endregion

        #region 主链路报警信息交互消息 UP_WARN_MSG
        ///<summary>
        ///报警督办应答	
        ///<para>DOWN_PLATFORM_MSG_INFO_REQ</para>
        ///<para>JT809_0x1400_0x1401</para>
        ///<para>JT809_0x1400</para>
        ///</summary>
        [Description("报警督办应答")]
        [JT809BodiesType(typeof(JT809_0x1400_0x1401))]
        [JT809SubBusinessTypeDescription("DOWN_PLATFORM_MSG_INFO_REQ", "下发平台间报文请求", JT809BusinessType.主链路报警信息交互消息)]
        UP_WARN_MSG_URGE_TODO_ACK = 0x1401,
        ///<summary>
        ///上报报警信息	
        ///<para>UP_WARN_MSG_ADPT_INFO</para>
        ///<para>JT809_0x1400_0x1402</para>
        ///<para>JT809_0x1400</para>
        ///</summary>
        [Description("上报报警信息")]
        [JT809BodiesType(typeof(JT809_0x1400_0x1402))]
        [JT809SubBusinessTypeDescription("UP_WARN_MSG_ADPT_INFO", "上报报警信息", JT809BusinessType.主链路报警信息交互消息)]
        上报报警信息 = 0x1402,
        ///<summary>
        ///主动上报报警处理结果信息	
        ///<para>UP_WARN_MSG_ADPT_TODO_INFO</para>
        ///<para>JT809_0x1400_0x1403</para>
        ///<para>JT809_0x1400</para>
        ///</summary>
        [Description("主动上报报警处理结果信息")]
        [JT809BodiesType(typeof(JT809_0x1400_0x1403))]
        [JT809SubBusinessTypeDescription("UP_WARN_MSG_ADPT_TODO_INFO", "主动上报报警处理结果信息", JT809BusinessType.主链路报警信息交互消息)]
        主动上报报警处理结果信息 = 0x1403,
        #endregion

        #region 从链路报警信息交互消息 DOWN_WARN_MSG
        ///<summary>
        ///报警督办请求	
        ///<para>DOWN_WARN_MSG_URGE_TODO_REQ</para>
        ///<para>JT809_0x9400_0x9401</para>
        ///<para>JT809_0x9400</para>
        ///</summary>
        [Description("报警督办请求")]
        [JT809BodiesType(typeof(JT809_0x9400_0x9401))]
        [JT809SubBusinessTypeDescription("DOWN_WARN_MSG_URGE_TODO_REQ", "报警督办请求", JT809BusinessType.从链路报警信息交互消息)]
        报警督办请求 = 0x9401,
        ///<summary>
        ///报警预警	
        ///<para>DOWN_WARN_MSG_INFORM_TIPS</para>
        ///<para>JT809_0x9400_0x9402</para>
        ///<para>JT809_0x9400</para>
        ///</summary>
        [Description("报警预警")]
        [JT809BodiesType(typeof(JT809_0x9400_0x9402))]
        [JT809SubBusinessTypeDescription("DOWN_WARN_MSG_INFORM_TIPS", "报警预警", JT809BusinessType.从链路报警信息交互消息)]
        报警预警 = 0x9402,
        ///<summary>
        ///实时交换报警信息 	
        ///<para>DOWN_WARN_MSG_EXG_INFORM</para>
        ///<para>JT809_0x9400_0x9403</para>
        ///<para>JT809_0x9400</para>
        ///</summary>
        [Description("实时交换报警信息")]
        [JT809BodiesType(typeof(JT809_0x9400_0x9403))]
        [JT809SubBusinessTypeDescription("DOWN_WARN_MSG_EXG_INFORM", "实时交换报警信息", JT809BusinessType.从链路报警信息交互消息)]
        实时交换报警信息 = 0x9403,
        #endregion

        #region 主链路车辆监管消息 UP_CTRL_MSG
        ///<summary>
        ///车辆单向监听应答	
        ///<para>UP_CTRL_MSG_MONITOR_VEHICLE_ACK</para>
        ///<para>JT809_0x1500_0x1501</para>
        ///<para>JT809_0x1500</para>
        ///</summary>
        [Description("车辆单向监听应答")]
        [JT809BodiesType(typeof(JT809_0x1500_0x1501))]
        [JT809SubBusinessTypeDescription("UP_CTRL_MSG_MONITOR_VEHICLE_ACK", "车辆单向监听应答", JT809BusinessType.主链路车辆监管消息)]
        车辆单向监听应答 = 0x1501,
        ///<summary>
        ///车辆拍照应答	
        ///<para>UP_CTRL_MSG_TAKE_PHOTO_ACK</para>
        ///<para>JT809_0x1500_0x1502</para>
        ///<para>JT809_0x1500</para>
        ///</summary>
        [Description("车辆拍照应答")]
        [JT809BodiesType(typeof(JT809_0x1500_0x1502))]
        [JT809SubBusinessTypeDescription("UP_CTRL_MSG_TAKE_PHOTO_ACK", "车辆拍照应答", JT809BusinessType.主链路车辆监管消息)]
        车辆拍照应答 = 0x1502,
        ///<summary>
        ///下发车辆报文应答	
        ///<para>UP_CTRL_MSG_TEXT_INFO_ACK</para>
        ///<para>JT809_0x1500_0x1503</para>
        ///<para>JT809_0x1500</para>
        ///</summary>
        [Description("下发车辆报文应答")]
        [JT809BodiesType(typeof(JT809_0x1500_0x1503))]
        [JT809SubBusinessTypeDescription("UP_CTRL_MSG_TEXT_INFO_ACK", "下发车辆报文应答", JT809BusinessType.主链路车辆监管消息)]
        下发车辆报文应答 = 0x1503,
        ///<summary>
        ///上报车辆行驶记录应答	
        ///<para>UP_CTRL_MSG_TAKE_TRAVEL_ACK</para>
        ///<para>JT809_0x1500_0x1504</para>
        ///<para>JT809_0x1500</para>
        ///</summary>
        [Description("上报车辆行驶记录应答")]
        [JT809BodiesType(typeof(JT809_0x1500_0x1504))]
        [JT809SubBusinessTypeDescription("UP_CTRL_MSG_TAKE_TRAVEL_ACK", "上报车辆行驶记录应答", JT809BusinessType.主链路车辆监管消息)]
        上报车辆行驶记录应答 = 0x1504,
        ///<summary>
        ///车辆应急接入监管平台应答消息	
        ///<para>UP_CTRL_MSG_EMERGENCY_MONITORING_ACK</para>
        ///<para>JT809_0x1500_0x1505</para>
        ///<para>JT809_0x1500</para>
        ///</summary>
        [Description("车辆应急接入监管平台应答消息")]
        [JT809BodiesType(typeof(JT809_0x1500_0x1505))]
        [JT809SubBusinessTypeDescription("UP_CTRL_MSG_EMERGENCY_MONITORING_ACK", "车辆应急接入监管平台应答消息", JT809BusinessType.主链路车辆监管消息)]
        车辆应急接入监管平台应答消息 = 0x1505,
        #endregion

        #region 从链路车辆监管消息 DOWN_CTRL_MSG
        ///<summary>
        ///车辆单向监听请求	
        ///<para>DOWN_CTRL_MSG_MONITOR_VEHICLE_REQ</para>
        ///<para>JT809_0x9500_0x9501</para>
        ///<para>JT809_0x9500</para>
        ///</summary>
        [Description("车辆单向监听请求")]
        [JT809BodiesType(typeof(JT809_0x9500_0x9501))]
        [JT809SubBusinessTypeDescription("DOWN_CTRL_MSG_MONITOR_VEHICLE_REQ", "车辆单向监听请求", JT809BusinessType.从链路车辆监管消息)]
        车辆单向监听请求 = 0x9501,
        ///<summary>
        ///车辆拍照请求	
        ///<para>DOWN_CTRL_MSG_TAKE_PHOTO_REQ</para>
        ///<para>JT809_0x9500_0x9502</para>
        ///<para>JT809_0x9500</para>
        ///</summary>
        [Description("车辆拍照请求")]
        [JT809BodiesType(typeof(JT809_0x9500_0x9502))]
        [JT809SubBusinessTypeDescription("DOWN_CTRL_MSG_TAKE_PHOTO_REQ", "车辆拍照请求", JT809BusinessType.从链路车辆监管消息)]
        车辆拍照请求 = 0x9502,
        ///<summary>
        ///下发车辆报文请求	
        ///<para>DOWN_CTRL_MSG_TEXT_INFO</para>
        ///<para>JT809_0x9500_0x9503</para>
        ///<para>JT809_0x9500</para>
        ///</summary>
        [Description("下发车辆报文请求")]
        [JT809BodiesType(typeof(JT809_0x9500_0x9503))]
        [JT809SubBusinessTypeDescription("DOWN_CTRL_MSG_TEXT_INFO", "下发车辆报文请求", JT809BusinessType.从链路车辆监管消息)]
        下发车辆报文请求 = 0x9503,
        ///<summary>
        ///上报车辆行驶记录请求	
        ///<para>DOWN_CTRL_MSG_TAKE_TRAVEL_REQ</para>
        ///<para>JT809_0x9500_0x9504</para>
        ///<para>JT809_0x9500</para>
        ///</summary>
        [Description("上报车辆行驶记录请求")]
        [JT809BodiesType(typeof(JT809_0x9500_0x9504))]
        [JT809SubBusinessTypeDescription("DOWN_CTRL_MSG_TAKE_TRAVEL_REQ", "上报车辆行驶记录请求", JT809BusinessType.从链路车辆监管消息)]
        上报车辆行驶记录请求 = 0x9504,
        ///<summary>
        ///车辆应急接入监管平台请求消息	
        ///<para>DOWN_CTRL_MSG_EMERGENCY_MONITORING_REQ</para>
        ///<para>JT809_0x9500_0x9505</para>
        ///<para>JT809_0x9500</para>
        ///</summary>
        [Description("车辆应急接入监管平台请求消息")]
        [JT809BodiesType(typeof(JT809_0x9500_0x9505))]
        [JT809SubBusinessTypeDescription("DOWN_CTRL_MSG_EMERGENCY_MONITORING_REQ", "车辆应急接入监管平台请求消息", JT809BusinessType.从链路车辆监管消息)]
        车辆应急接入监管平台请求消息 = 0x9505,
        #endregion

        #region 主链路静态信息交换消息 UP_BASE_MSG
        ///<summary>
        ///补报车辆静态信息应答	
        ///<para>UP_BASE_MSG_VEHICLE_ADDED_ACK</para>
        ///<para>JT809_0x1600_0x1601</para>
        ///<para>JT809_0x1600</para>
        ///</summary>
        [Description("补报车辆静态信息应答")]
        [JT809BodiesType(typeof(JT809_0x1600_0x1601))]
        [JT809SubBusinessTypeDescription("UP_BASE_MSG_VEHICLE_ADDED_ACK", "补报车辆静态信息应答", JT809BusinessType.主链路静态信息交换消息)]
        补报车辆静态信息应答 = 0x1601,
        #endregion

        #region 从链路静态信息交换消息 DOWN_BASE_MSG
        ///<summary>
        ///补报车辆静态信息请求
        ///<para>DOWN_BASE_MSG_VEHICLE_ADDED</para>
        ///<para>JT809_0x9600_0x9601</para>
        ///<para>JT809_0x9600</para>
        ///</summary>
        [Description("补报车辆静态信息请求")]
        [JT809BodiesType(typeof(JT809_0x9600_0x9601))]
        [JT809SubBusinessTypeDescription("DOWN_BASE_MSG_VEHICLE_ADDED", "补报车辆静态信息请求", JT809BusinessType.从链路静态信息交换消息)]
        补报车辆静态信息请求 = 0x9601,
        #endregion
    }
}
