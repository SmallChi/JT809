using JT809.Protocol.Attributes;
using JT809.Protocol.SubMessageBody;
using System.ComponentModel;

namespace JT809.Protocol.Enums
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
        /// UP_EXG_MSG_REGISTER
        /// </summary>
        [Description("上传车辆注册信息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1201))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_REGISTER", "上传车辆注册信息", JT809BusinessType.主链路车辆动态信息交换业务)]
        上传车辆注册信息 = 0x1201,
        ///<summary>
        ///实时上传车辆定位信息  
        ///UP_EXG_MSG_REAL_LOCATION
        ///</summary>
        [Description("实时上传车辆定位信息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1202))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_REAL_LOCATION", "实时上传车辆定位信息", JT809BusinessType.主链路车辆动态信息交换业务)]
        实时上传车辆定位信息 = 0x1202,
        ///<summary>
        ///车辆定位信息自动补报请求消息
        ///UP_EXG_MSG_HISTORY_LOCATION
        ///</summary>
        [Description("车辆定位信息自动补报请求消息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1203))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_HISTORY_LOCATION", "车辆定位信息自动补报请求消息", JT809BusinessType.主链路车辆动态信息交换业务)]
        车辆定位信息自动补报请求消息 = 0x1203,
        ///<summary>
        ///启动车辆定位信息交换应答消息	
        ///UP_EXG_MSG_RETURN_STARTUP_ACK
        ///</summary>
        [Description("启动车辆定位信息交换应答消息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1205))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_RETURN_STARTUP_ACK", "启动车辆定位信息交换应答消息", JT809BusinessType.主链路车辆动态信息交换业务)]
        启动车辆定位信息交换应答消息 = 0x1205,
        ///<summary>
        ///结束车辆定位信息交换应答	
        ///UP_EXG_MSG_RETURN_END_ACK
        ///</summary>
        [Description("结束车辆定位信息交换应答消息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1206))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_RETURN_END_ACK", "结束车辆定位信息交换应答消息", JT809BusinessType.主链路车辆动态信息交换业务)]
        结束车辆定位信息交换应答消息 = 0x1206,
        ///<summary>
        ///申请交换指定车辆定位信息请求	
        ///UP_EXG_MSG_APPLY_FOR_MONITOR_STARTUP
        ///</summary>
        [Description("申请交换指定车辆定位信息请求消息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1207))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_APPLY_FOR_MONITOR_STARTUP", "申请交换指定车辆定位信息请求消息", JT809BusinessType.主链路车辆动态信息交换业务)]
        申请交换指定车辆定位信息请求消息 = 0x1207,
        ///<summary>
        ///取消交换指定车辆定位信息请求
        ///UP_EXG_MSG_APPLY_FOR_MONITOR_END
        ///</summary>
        [Description("取消交换指定车辆定位信息请求")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1208))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_APPLY_FOR_MONITOR_END", "取消交换指定车辆定位信息请求", JT809BusinessType.主链路车辆动态信息交换业务)]
        取消交换指定车辆定位信息请求 = 0x1208,
        ///<summary>
        ///补发车辆定位信息请求
        ///UP_EXG_MSG_APPLY_HISGNSSDATA_REQ
        ///</summary>
        [Description("补发车辆定位信息请求")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1209))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_APPLY_HISGNSSDATA_REQ", "补发车辆定位信息请求", JT809BusinessType.主链路车辆动态信息交换业务)]
        补发车辆定位信息请求 = 0x1209,
        ///<summary>
        ///上报车辆驾驶员身份识别信息应答
        ///UP_EXG_MSG_REPORT_DRIVER_INFO_ACK
        ///</summary>
        [Description("上报驾驶员身份识别信息应答消息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x120A))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_REPORT_DRIVER_INFO_ACK", "上报驾驶员身份识别信息应答消息", JT809BusinessType.主链路车辆动态信息交换业务)]
        上报驾驶员身份识别信息应答消息 = 0x120A,
        ///<summary>
        ///上报车辆电子运单应答	
        ///UP_EXG_MSG_TAKE_EWAYBILL_ACK
        ///</summary>
        [Description("上报车辆电子运单应答消息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x120B))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_TAKE_EWAYBILL_ACK", "上报车辆电子运单应答消息", JT809BusinessType.主链路车辆动态信息交换业务)]
        上报车辆电子运单应答消息 = 0x120B,
        ///<summary>
        ///主动上报驾驶员身份信息消息	
        ///UP_EXG_MSG_REPORT_DRIVER_INFO
        ///</summary>
        [Description("主动上报驾驶员身份信息消息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x120C))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_REPORT_DRIVER_INFO", "主动上报驾驶员身份信息消息", JT809BusinessType.主链路车辆动态信息交换业务)]
        主动上报驾驶员身份信息消息 = 0x120C,
        ///<summary>
        ///主动上报车辆电子运单信息	
        ///UP_EXG_MSG_REPORT_EWAYBILL_INFO
        ///</summary>
        [Description("主动上报车辆电子运单信息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x120D))]
        [JT809SubBusinessTypeDescription("UP_EXG_MSG_REPORT_EWAYBILL_INFO", "主动上报车辆电子运单信息", JT809BusinessType.主链路车辆动态信息交换业务)]
        主动上报车辆电子运单信息 = 0x120D,
        ///<summary>
        ///主动上报车辆行驶路线信息	
        ///UP_BASE_MSG_DRVLINE_INFO
        ///</summary>
        [Description("主动上报车辆行驶路线信息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x120E))]
        [JT809SubBusinessTypeDescription("UP_BASE_MSG_DRVLINE_INFO", "主动上报车辆行驶路线信息", JT809BusinessType.主链路车辆动态信息交换业务)]
        主动上报车辆行驶路线信息 = 0x120E, 


        #endregion

        #region 从链路动态信息交换消息 DOWN_EXG_MSG
        ///<summary>
        ///车辆注册信息应答消息	
        ///DOWN_EXG_MSG_REGISTER_ACK
        ///</summary>
        [Description("车辆注册信息应答消息")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9201))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_REGISTER_ACK", "车辆注册信息应答消息", JT809BusinessType.从链路车辆动态信息交换业务)]
        车辆注册信息应答消息 = 0x9201,
        
        ///<summary>
        ///交换车辆定位信息	
        ///DOWN_EXG_MSG_CAR_LOCATION
        ///</summary>
        [Description("交换车辆定位信息消息")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9202))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_CAR_LOCATION", "交换车辆定位信息消息", JT809BusinessType.从链路车辆动态信息交换业务)]
        交换车辆定位信息消息 = 0x9202,
        ///<summary>
        ///车辆定位信息交换补发	
        ///DOWN_EXG_MSG_HISTORY_ARCOSSAREA
        ///</summary>
        [Description("车辆定位信息交换补发消息")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9203))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_HISTORY_ARCOSSAREA", "车辆定位信息交换补发消息", JT809BusinessType.从链路车辆动态信息交换业务)]
        车辆定位信息交换补发消息 = 0x9203,
        ///<summary>
        ///交换车辆静态信息
        ///DOWN_EXG_MSG_CAR_INFO
        ///</summary>
        [Description("交换车辆静态信息消息")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9204))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_CAR_INFO", "交换车辆静态信息消息", JT809BusinessType.从链路车辆动态信息交换业务)]
        交换车辆静态信息消息 = 0x9204,
        ///<summary>
        ///启动车辆定位信息交换请求消息
        ///DOWN_EXG_MSG_RETURN_STARTUP
        ///</summary>
        [Description("启动车辆定位信息交换请求消息")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9205))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_RETURN_STARTUP", "启动车辆定位信息交换请求消息", JT809BusinessType.从链路车辆动态信息交换业务)]
        启动车辆定位信息交换请求消息 = 0x9205,
        ///<summary>
        ///结束车辆定位信息交换请求	
        ///</summary>
        [Description("结束车辆定位信息交换请求")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9206))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_RETURN_END", "结束车辆定位信息交换请求", JT809BusinessType.从链路车辆动态信息交换业务)]
        结束车辆定位信息交换请求 = 0x9206,
        ///<summary>
        ///申请交换指定车辆定位信息应答	
        ///DOWN_EXG_MSG_APPLY_FOR_MONITOR_STARTUP_ACK
        ///</summary>
        [Description("申请交换指定车辆定位信息应答")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9207))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_APPLY_FOR_MONITOR_STARTUP_ACK", "申请交换指定车辆定位信息应答", JT809BusinessType.从链路车辆动态信息交换业务)]
        申请交换指定车辆定位信息应答 = 0x9207,
        ///<summary>
        ///取消交换指定车辆定位信息应答or取消申请交换指定车辆定位信息应答消息	
        ///DOWN_EXG_MSG_APPLY_FOR_MONITOR_END_ACK
        ///</summary>
        [Description("取消交换指定车辆定位信息应答or取消申请交换指定车辆定位信息应答消息")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9208))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_APPLY_FOR_MONITOR_END_ACK", "取消交换指定车辆定位信息应答", JT809BusinessType.从链路车辆动态信息交换业务)]
        取消交换指定车辆定位信息应答or取消申请交换指定车辆定位信息应答消息 = 0x9208,
        ///<summary>
        ///补发车辆定位信息应答	
        ///DOWN_EXG_MSG_APPLY_HISGNSSDATA_ACK
        ///</summary>
        [Description("补发车辆定位信息应答")]
        [JT809BodiesType(typeof(JT809_0x9200_0x9209))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_APPLY_HISGNSSDATA_ACK", "补发车辆定位信息应答", JT809BusinessType.从链路车辆动态信息交换业务)]
        补发车辆定位信息应答 = 0x9209,
        ///<summary>
        ///上报车辆驾驶员身份识别信息请求	
        ///DOWN_EXG_MSG_REPORT_DRIVER_INFO
        ///</summary>
        [Description("上报车辆驾驶员身份识别信息请求")]
        [JT809BodiesType(typeof(JT809_0x9200_0x920A))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_REPORT_DRIVER_INFO", "上报车辆驾驶员身份识别信息请求", JT809BusinessType.从链路车辆动态信息交换业务)]
        上报车辆驾驶员身份识别信息请求 = 0x920A,
        ///<summary>
        ///上报车辆电子运单请求	
        ///DOWN_EXG_MSG_TAKE_EWAYBILL_REQ
        ///</summary>
        [Description("上报车辆电子运单请求消息")]
        [JT809BodiesType(typeof(JT809_0x9200_0x920B))]
        [JT809SubBusinessTypeDescription("DOWN_EXG_MSG_TAKE_EWAYBILL_REQ", "上报车辆电子运单请求消息", JT809BusinessType.从链路车辆动态信息交换业务)]
        上报车辆电子运单请求消息 = 0x920B,
        ///<summary>
        ///上报车辆车辆行驶路线请求	
        ///DOWN_BASE_MSG_DRVLINE_REQ
        ///</summary>
        [Description("上报车辆车辆行驶路线请求")]
        [JT809BodiesType(typeof(JT809_0x9200_0x920C))]
        [JT809SubBusinessTypeDescription("DOWN_BASE_MSG_DRVLINE_REQ", "上报车辆车辆行驶路线请求", JT809BusinessType.从链路车辆动态信息交换业务)]
        上报车辆车辆行驶路线请求 = 0x920C,
        ///<summary>
        ///车辆行驶线路请求应答	
        ///DOWN_BASE_MSG_DRVLINE_ACK
        ///</summary>
        [Description("车辆行驶线路请求应答")]
        [JT809BodiesType(typeof(JT809_0x9200_0x920D))]
        [JT809SubBusinessTypeDescription("DOWN_BASE_MSG_DRVLINE_ACK", "车辆行驶线路请求应答", JT809BusinessType.从链路车辆动态信息交换业务)]
        车辆行驶线路请求应答 = 0x920D,
        #endregion

        #region 主链路平台信息交互消息 UP_PLATFORM_MSG
        ///<summary>
        ///平台查岗应答消息	
        ///UP_PLATFORM_MSG_POST_QUERY_ACK
        ///</summary>
        [Description("平台查岗应答消息")]
        [JT809BodiesType(typeof(JT809_0x1300_0x1301))]
        [JT809SubBusinessTypeDescription("UP_PLATFORM_MSG_POST_QUERY_ACK", "平台查岗应答消息", JT809BusinessType.主链路平台间信息交互消息)]
        平台查岗应答消息 = 0x1301,
        ///<summary>
        ///下发平台间报文应答消息	
        ///UP_PLATFORM_MSG_INFO_ACK
        ///</summary>
        [Description("下发平台间报文应答消息")]
        [JT809BodiesType(typeof(JT809_0x1300_0x1302))]
        [JT809SubBusinessTypeDescription("UP_PLATFORM_MSG_INFO_ACK", "下发平台间报文应答消息", JT809BusinessType.主链路平台间信息交互消息)]
        下发平台间报文应答消息 = 0x1302,
        ///<summary>
        ///上传平台间消息补传请求消息	
        ///UP_PLATFORM_MSG_RETRAN_REQ
        ///</summary>
        [Description("上传平台间消息补传请求消息")]
        [JT809BodiesType(typeof(JT809_0x1300_0x1303))]
        [JT809SubBusinessTypeDescription("UP_PLATFORM_MSG_RETRAN_REQ", "上传平台间消息补传请求消息", JT809BusinessType.主链路平台间信息交互消息)]
        上传平台间消息补传请求消息 = 0x1303,
        
        #endregion

        #region 从链路平台信息交互消息 DOWN_PLATFORM_MSG
        ///<summary>
        ///平台查岗请求	
        ///DOWN_PLATFORM_MSG_POST_QUERY_REQ
        ///</summary>
        [Description("平台查岗请求")]
        [JT809BodiesType(typeof(JT809_0x9300_0x9301))]
        [JT809SubBusinessTypeDescription("DOWN_PLATFORM_MSG_POST_QUERY_REQ", "平台查岗请求", JT809BusinessType.从链路平台间信息交互业务)]
        平台查岗请求 = 0x9301,
        ///<summary>
        ///下发平台间报文请求	
        ///DOWN_PLATFORM_MSG_INFO_REQ
        ///</summary>
        [Description("下发平台间报文请求")]
        [JT809BodiesType(typeof(JT809_0x9300_0x9302))]
        [JT809SubBusinessTypeDescription("DOWN_PLATFORM_MSG_INFO_REQ", "下发平台间报文请求", JT809BusinessType.从链路平台间信息交互业务)]
        下发平台间报文请求 = 0x9302,
        ///<summary>
        ///下发平台间消息补传请求消息	
        ///DOWN_PLATFORM_MSG_RETRAN_REQ
        ///</summary>
        [Description("下发平台间消息补传请求消息")]
        [JT809BodiesType(typeof(JT809_0x9300_0x9303))]
        [JT809SubBusinessTypeDescription("DOWN_PLATFORM_MSG_RETRAN_REQ", "下发平台间消息补传请求消息", JT809BusinessType.从链路平台间信息交互业务)]
        下发平台间消息补传请求消息 = 0x9303,
        
        #endregion

        #region 主链路报警信息交互消息 UP_WARN_MSG
        ///<summary>
        ///报警督办应答消息	
        ///UP_WARN_MSG_URGE_TODO_ACK
        ///</summary>
        [Description("报警督办应答消息")]
        [JT809BodiesType(typeof(JT809_0x1400_0x1401))]
        [JT809SubBusinessTypeDescription("UP_WARN_MSG_URGE_TODO_ACK", "报警督办应答消息", JT809BusinessType.主链路报警信息交互消息)]
        报警督办应答消息 = 0x1401,
        ///<summary>
        ///上报报警信息消息	
        ///UP_WARN_MSG_ADPT_INFO
        ///</summary>
        [Description("上报报警信息消息")]
        [JT809BodiesType(typeof(JT809_0x1400_0x1402))]
        [JT809SubBusinessTypeDescription("UP_WARN_MSG_ADPT_INFO", "上报报警信息消息", JT809BusinessType.主链路报警信息交互消息)]
        上报报警信息消息 = 0x1402,
        ///<summary>
        ///上报报警督办应答消息	
        ///UP_WARN_MSG_URGE_TODO_ACK_INFO
        ///</summary>
        [Description("上报报警督办应答消息")]
        [JT809BodiesType(typeof(JT809_0x1400_0x1411))]
        [JT809SubBusinessTypeDescription("UP_WARN_MSG_URGE_TODO_ACK_INFO", "上报报警督办应答消息", JT809BusinessType.主链路报警信息交互消息)]
        上报报警督办应答消息 = 0x1411,
        ///<summary>
        ///主动上报报警处理结果消息	
        ///UP_WARN_MSG_ADPT_TODO_INFO
        ///</summary>
        [Description("主动上报报警处理结果消息")]
        [JT809BodiesType(typeof(JT809_0x1400_0x1412))]
        [JT809SubBusinessTypeDescription("UP_WARN_MSG_ADPT_TODO_INFO", "主动上报报警处理结果消息", JT809BusinessType.主链路报警信息交互消息)]
        主动上报报警处理结果消息 = 0x1412,
        ///<summary>
        ///上报报警督办请求消息	
        ///UP_WARN_MSG_URGE_TODO_REQ_INFO
        ///</summary>
        [Description("上报报警督办请求消息")]
        [JT809BodiesType(typeof(JT809_0x1400_0x1413))]
        [JT809SubBusinessTypeDescription("UP_WARN_MSG_URGE_TODO_REQ_INFO", "上报报警督办请求消息", JT809BusinessType.主链路报警信息交互消息)]
        上报报警督办请求消息 = 0x1413,
        
        ///<summary>
        ///主动上报报警处理结果信息2013_上报报警预警信息2019	
        ///UP_WARN_MSG_ADPT_TODO_INFO_2013_UP_WARN_MSG_INFORM_TIPS_2019
        ///</summary>
        [Description("主动上报报警处理结果信息2013_上报报警预警信息2019")]
        [JT809BodiesType(typeof(JT809_0x1400_0x1403))]
        [JT809SubBusinessTypeDescription("UP_WARN_MSG_ADPT_TODO_INFO_2013_UP_WARN_MSG_INFORM_TIPS_2019", "主动上报报警处理结果信息2013_上报报警预警信息2019", JT809BusinessType.主链路报警信息交互消息)]
        主动上报报警处理结果信息2013_上报报警预警信息2019 = 0x1403,
        #endregion

        #region 从链路报警信息交互消息 DOWN_WARN_MSG
        ///<summary>
        ///报警督办请求消息	
        ///DOWN_WARN_MSG_URGE_TODO_REQ
        ///</summary>
        [Description("报警督办请求消息")]
        [JT809BodiesType(typeof(JT809_0x9400_0x9401))]
        [JT809SubBusinessTypeDescription("DOWN_WARN_MSG_URGE_TODO_REQ", "报警督办请求消息", JT809BusinessType.从链路报警信息交互消息)]
        报警督办请求消息 = 0x9401,
        ///<summary>
        ///报警预警2013_下发报警预警消息2019	
        ///DOWN_WARN_MSG_INFORM_TIPS
        ///</summary>
        [Description("报警预警2013_下发报警预警消息2019")]
        [JT809BodiesType(typeof(JT809_0x9400_0x9402))]
        [JT809SubBusinessTypeDescription("DOWN_WARN_MSG_INFORM_TIPS", "报警预警2013_下发报警预警消息2019", JT809BusinessType.从链路报警信息交互消息)]
        报警预警2013_下发报警预警消息2019 = 0x9402,
        ///<summary>
        ///实时交换报警信息 	
        ///DOWN_WARN_MSG_EXG_INFORM
        ///</summary>
        [Description("实时交换报警信息")]
        [JT809BodiesType(typeof(JT809_0x9400_0x9403))]
        [JT809SubBusinessTypeDescription("DOWN_WARN_MSG_EXG_INFORM", "实时交换报警信息", JT809BusinessType.从链路报警信息交互消息)]
        实时交换报警信息 = 0x9403,
        #endregion

        #region 主链路车辆监管消息 UP_CTRL_MSG
        ///<summary>
        ///车辆单向监听应答	
        ///UP_CTRL_MSG_MONITOR_VEHICLE_ACK
        ///</summary>
        [Description("车辆单向监听应答")]
        [JT809BodiesType(typeof(JT809_0x1500_0x1501))]
        [JT809SubBusinessTypeDescription("UP_CTRL_MSG_MONITOR_VEHICLE_ACK", "车辆单向监听应答", JT809BusinessType.主链路车辆监管消息)]
        车辆单向监听应答 = 0x1501,
        ///<summary>
        ///车辆拍照应答	
        ///UP_CTRL_MSG_TAKE_PHOTO_ACK
        ///</summary>
        [Description("车辆拍照应答")]
        [JT809BodiesType(typeof(JT809_0x1500_0x1502))]
        [JT809SubBusinessTypeDescription("UP_CTRL_MSG_TAKE_PHOTO_ACK", "车辆拍照应答", JT809BusinessType.主链路车辆监管消息)]
        车辆拍照应答 = 0x1502,
        ///<summary>
        ///下发车辆报文应答消息	
        ///UP_CTRL_MSG_TEXT_INFO_ACK
        ///</summary>
        [Description("下发车辆报文应答消息")]
        [JT809BodiesType(typeof(JT809_0x1500_0x1503))]
        [JT809SubBusinessTypeDescription("UP_CTRL_MSG_TEXT_INFO_ACK", "下发车辆报文应答消息", JT809BusinessType.主链路车辆监管消息)]
        下发车辆报文应答消息 = 0x1503,
        ///<summary>
        ///上报车辆行驶记录应答消息	
        ///UP_CTRL_MSG_TAKE_TRAVEL_ACK
        ///</summary>
        [Description("上报车辆行驶记录应答消息")]
        [JT809BodiesType(typeof(JT809_0x1500_0x1504))]
        [JT809SubBusinessTypeDescription("UP_CTRL_MSG_TAKE_TRAVEL_ACK", "上报车辆行驶记录应答消息", JT809BusinessType.主链路车辆监管消息)]
        上报车辆行驶记录应答消息 = 0x1504,
        ///<summary>
        ///车辆应急接入监管平台应答消息	
        ///UP_CTRL_MSG_EMERGENCY_MONITORING_ACK
        ///</summary>
        [Description("车辆应急接入监管平台应答消息")]
        [JT809BodiesType(typeof(JT809_0x1500_0x1505))]
        [JT809SubBusinessTypeDescription("UP_CTRL_MSG_EMERGENCY_MONITORING_ACK", "车辆应急接入监管平台应答消息", JT809BusinessType.主链路车辆监管消息)]
        车辆应急接入监管平台应答消息 = 0x1505,
        #endregion

        #region 从链路车辆监管消息 DOWN_CTRL_MSG
        ///<summary>
        ///车辆单向监听请求消息	
        ///DOWN_CTRL_MSG_MONITOR_VEHICLE_REQ
        ///</summary>
        [Description("车辆单向监听请求消息")]
        [JT809BodiesType(typeof(JT809_0x9500_0x9501))]
        [JT809SubBusinessTypeDescription("DOWN_CTRL_MSG_MONITOR_VEHICLE_REQ", "车辆单向监听请求消息", JT809BusinessType.从链路车辆监管消息)]
        车辆单向监听请求消息 = 0x9501,
        ///<summary>
        ///车辆拍照请求消息	
        ///DOWN_CTRL_MSG_TAKE_PHOTO_REQ
        ///</summary>
        [Description("车辆拍照请求消息")]
        [JT809BodiesType(typeof(JT809_0x9500_0x9502))]
        [JT809SubBusinessTypeDescription("DOWN_CTRL_MSG_TAKE_PHOTO_REQ", "车辆拍照请求消息", JT809BusinessType.从链路车辆监管消息)]
        车辆拍照请求消息 = 0x9502,
        ///<summary>
        ///下发车辆报文请求	
        ///DOWN_CTRL_MSG_TEXT_INFO
        ///</summary>
        [Description("下发车辆报文请求")]
        [JT809BodiesType(typeof(JT809_0x9500_0x9503))]
        [JT809SubBusinessTypeDescription("DOWN_CTRL_MSG_TEXT_INFO", "下发车辆报文请求", JT809BusinessType.从链路车辆监管消息)]
        下发车辆报文请求 = 0x9503,
        ///<summary>
        ///上报车辆行驶记录请求消息	
        ///DOWN_CTRL_MSG_TAKE_TRAVEL_REQ
        ///</summary>
        [Description("上报车辆行驶记录请求")]
        [JT809BodiesType(typeof(JT809_0x9500_0x9504))]
        [JT809SubBusinessTypeDescription("DOWN_CTRL_MSG_TAKE_TRAVEL_REQ", "上报车辆行驶记录请求消息", JT809BusinessType.从链路车辆监管消息)]
        上报车辆行驶记录请求消息 = 0x9504,
        ///<summary>
        ///车辆应急接入监管平台请求消息	
        ///DOWN_CTRL_MSG_EMERGENCY_MONITORING_REQ
        ///</summary>
        [Description("车辆应急接入监管平台请求消息")]
        [JT809BodiesType(typeof(JT809_0x9500_0x9505))]
        [JT809SubBusinessTypeDescription("DOWN_CTRL_MSG_EMERGENCY_MONITORING_REQ", "车辆应急接入监管平台请求消息", JT809BusinessType.从链路车辆监管消息)]
        车辆应急接入监管平台请求消息 = 0x9505,
        #endregion

        #region 主链路静态信息交换消息 UP_BASE_MSG
        ///<summary>
        ///补报车辆静态信息应答	
        ///UP_BASE_MSG_VEHICLE_ADDED_ACK
        ///</summary>
        [Description("补报车辆静态信息应答")]
        [JT809BodiesType(typeof(JT809_0x1600_0x1601))]
        [JT809SubBusinessTypeDescription("UP_BASE_MSG_VEHICLE_ADDED_ACK", "补报车辆静态信息应答", JT809BusinessType.主链路静态信息交换消息)]
        补报车辆静态信息应答 = 0x1601,
        ///<summary>
        ///补报车辆行驶路线信息应答消息	
        ///UP_BASE_MSG_DRVLINE_ADDED_REQ
        ///</summary>
        [Description("补报车辆行驶路线信息应答消息")]
        [JT809BodiesType(typeof(JT809_0x1600_0x1602))]
        [JT809SubBusinessTypeDescription("UP_BASE_MSG_DRVLINE_ADDED_REQ", "补报车辆行驶路线信息应答消息", JT809BusinessType.主链路静态信息交换消息)]
        补报车辆行驶路线信息应答消息 = 0x1602,
        
        #endregion

        #region 从链路静态信息交换消息 DOWN_BASE_MSG
        ///<summary>
        ///补报车辆静态信息请求消息
        ///DOWN_BASE_MSG_VEHICLE_ADDED
        ///</summary>
        [Description("补报车辆静态信息请求")]
        [JT809BodiesType(typeof(JT809_0x9600_0x9601))]
        [JT809SubBusinessTypeDescription("DOWN_BASE_MSG_VEHICLE_ADDED", "补报车辆静态信息请求消息", JT809BusinessType.从链路静态信息交换消息)]
        补报车辆静态信息请求消息 = 0x9601,
        #endregion
    }
}
