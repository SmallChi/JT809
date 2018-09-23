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
        #region 主链路动态信息交换消息 UP_EXG_MSG
        /// <summary>
        /// 上传车辆注册信息
        /// </summary>
        [Description("上传车辆注册信息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1201))]
        UP_EXG_MSG_REGISTER = 0x1201,
        ///<summary>
        ///实时上传车辆定位信息  
        ///</summary>
        [Description("实时上传车辆定位信息")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1202))]
        UP_EXG_MSG_REAL_LOCATION = 0x1202,
        ///<summary>
        ///车辆定位信息自动补报	
        ///</summary>
        [Description("车辆定位信息自动补报")]
        [JT809BodiesType(typeof(JT809_0x1200_0x1203))]
        UP_EXG_MSG_HISTORY_LOCATION = 0x1203,
        ///<summary>
        ///启动车辆定位信息交换应答	
        ///</summary>
        [Description("启动车辆定位信息交换应答")]
        UP_EXG_MSG_RETURN_STARTUP_ACK = 0x1205,
        ///<summary>
        ///结束车辆定位信息交换应答	
        ///</summary>
        [Description("结束车辆定位信息交换应答")]
        UP_EXG_MSG_RETURN_END_ACK = 0x1206,
        ///<summary>
        ///申请交换指定车辆定位信息请求	
        ///</summary>
        [Description("申请交换指定车辆定位信息请求")]
        UP_EXG_MSG_APPLY_FOR_MONITOR_STARTUP = 0x1207,
        ///<summary>
        ///取消交换指定车辆定位信息请求	
        ///</summary>
        [Description("取消交换指定车辆定位信息请求")]
        UP_EXG_MSG_APPLY_FOR_MONITOR_END = 0x1208,
        ///<summary>
        ///补发车辆定位信息请求	
        ///</summary>
        [Description("补发车辆定位信息请求")]
        UP_EXG_MSG_APPLY_HISGNSSDATA_REQ = 0x1209,
        ///<summary>
        ///上报车辆驾驶员身份识别信息应答	
        ///</summary>
        [Description("上报车辆驾驶员身份识别信息应答")]
        UP_EXG_MSG_REPORT_DRIVER_INFO_ACK = 0x120A,
        ///<summary>
        ///上报车辆电子运单应答	
        ///</summary>
        [Description("上报车辆电子运单应答")]
        UP_EXG_MSG_TAKE_EWAYBILL_ACK = 0x120B,
        ///<summary>
        ///主动上报驾驶员身份信息	
        ///</summary>
        [Description("主动上报驾驶员身份信息")]
        UP_EXG_MSG_REPORT_DRIVER_INFO = 0x120C,
        ///<summary>
        ///主动上报车辆电子运单信息	
        ///</summary>
        [Description("主动上报车辆电子运单信息")]
        UP_EXG_MSG_REPORT_EWAYBILL_INFO = 0x120D,
        #endregion

        #region 从链路动态信息交换消息 DOWN_EXG_MSG
        ///<summary>
        ///交换车辆定位信息	
        ///</summary>
        [Description("交换车辆定位信息")]
        DOWN_EXG_MSG_CAR_LOCATION = 0x9202,
        ///<summary>
        ///车辆定位信息交换补发	
        ///</summary>
        [Description("车辆定位信息交换补发")]
        DOWN_EXG_MSG_HISTORY_ARCOSSAREA = 0x9203,
        ///<summary>
        ///交换车辆静态信息	
        ///</summary>
        [Description("交换车辆静态信息")]
        DOWN_EXG_MSG_CAR_INFO = 0x9204,
        ///<summary>
        ///启动车辆定位信息交换请求	
        ///</summary>
        [Description("启动车辆定位信息交换请求")]
        DOWN_EXG_MSG_RETURN_STARTUP = 0x9205,
        ///<summary>
        ///结束车辆定位信息交换请求	
        ///</summary>
        [Description("结束车辆定位信息交换请求")]
        DOWN_EXG_MSG_RETURN_END = 0x9206,
        ///<summary>
        ///申请交换指定车辆定位信息应答	
        ///</summary>
        [Description("申请交换指定车辆定位信息应答")]
        DOWN_EXG_MSG_APPLY_FOR_MONITOR_STARTUP_ACK = 0x9207,
        ///<summary>
        ///取消交换指定车辆定位信息应答	
        ///</summary>
        [Description("取消交换指定车辆定位信息应答")]
        DOWN_EXG_MSG_APPLY_FOR_MONITOR_END_ACK = 0x9208,
        ///<summary>
        ///补发车辆定位信息应答	
        ///</summary>
        [Description("补发车辆定位信息应答")]
        DOWN_EXG_MSG_APPLY_HISGNSSDATA_ACK = 0x9209,
        ///<summary>
        ///上报车辆驾驶员身份识别信息请求	
        ///</summary>
        [Description("上报车辆驾驶员身份识别信息请求")]
        DOWN_EXG_MSG_REPORT_DRIVER_INFO = 0x920A,
        ///<summary>
        ///上报车辆电子运单请求	
        ///</summary>
        [Description("上报车辆电子运单请求")]
        DOWN_EXG_MSG_TAKE_EWAYBILL_REQ = 0x920B,
        #endregion

        #region 主链路平台信息交互消息 UP_PLATFORM_MSG
        ///<summary>
        ///平台查岗应答	
        ///</summary>
        [Description("平台查岗应答")]
        UP_PLATFORM_MSG_POST_QUERY_ACK = 0x1301,
        ///<summary>
        ///下发平台间报文应答	
        ///</summary>
        [Description("下发平台间报文应答")]
        UP_PLATFORM_MSG_INFO_ACK = 0x1302,
        #endregion

        #region 从链路平台信息交互消息 DOWN_PLATFORM_MSG
        ///<summary>
        ///平台查岗请求	
        ///</summary>
        [Description("平台查岗请求")]
        DOWN_PLATFORM_MSG_POST_QUERY_REQ = 0x9301,
        ///<summary>
        ///下发平台间报文请求	
        ///</summary>
        [Description("下发平台间报文请求")]
        DOWN_PLATFORM_MSG_INFO_REQ = 0x9302,
        #endregion

        #region 主链路报警信息交互消息 UP_WARN_MSG
        ///<summary>
        ///报警督办应答	
        ///</summary>
        [Description("报警督办应答")]
        UP_WARN_MSG_URGE_TODO_ACK = 0x1401,
        ///<summary>
        ///上报报警信息	
        ///</summary>
        [Description("上报报警信息")]
        UP_WARN_MSG_ADPT_INFO = 0x1402,
        ///<summary>
        ///主动上报报警处理结果信息	
        ///</summary>
        [Description("主动上报报警处理结果信息")]
        UP_WARN_MSG_ADPT_TODO_INFO = 0x1403,
        #endregion

        #region 从链路报警信息交互消息 DOWN_WARN_MSG
        ///<summary>
        ///报警督办请求	
        ///</summary>
        [Description("报警督办请求")]
        DOWN_WARN_MSG_URGE_TODO_REQ = 0x9401,
        ///<summary>
        ///报警预警	
        ///</summary>
        [Description("报警预警")]
        DOWN_WARN_MSG_INFORM_TIPS = 0x9402,
        ///<summary>
        ///实时交换报警信息 	
        ///</summary>
        [Description("实时交换报警信息")]
        DOWN_WARN_MSG_EXG_INFORM = 0x9403,
        #endregion

        #region 主链路车辆监管消息 UP_CTRL_MSG
        ///<summary>
        ///车辆单向监听应答	
        ///</summary>
        [Description("车辆单向监听应答")]
        UP_CTRL_MSG_MONITOR_VEHICLE_ACK = 0x1501,
        ///<summary>
        ///车辆拍照应答	
        ///</summary>
        [Description("车辆拍照应答")]
        UP_CTRL_MSG_TAKE_PHOTO_ACK = 0x1502,
        ///<summary>
        ///下发车辆报文应答	
        ///</summary>
        [Description("下发车辆报文应答")]
        UP_CTRL_MSG_TEXT_INFO_ACK = 0x1503,
        ///<summary>
        ///上报车辆行驶记录应答	
        ///</summary>
        [Description("上报车辆行驶记录应答")]
        UP_CTRL_MSG_TAKE_TRAVEL_ACK = 0x1504,
        ///<summary>
        ///车辆应急接入监管平台应答消息	
        ///</summary>
        [Description("车辆应急接入监管平台应答消息")]
        UP_CTRL_MSG_EMERGENCY_MONITORING_ACK = 0x1505,
        #endregion

        #region 从链路车辆监管消息 DOWN_CTRL_MSG
        ///<summary>
        ///车辆单向监听请求	
        ///</summary>
        [Description("车辆单向监听请求")]
        DOWN_CTRL_MSG_MONITOR_VEHICLE_REQ = 0x9501,
        ///<summary>
        ///车辆拍照请求	
        ///</summary>
        [Description("车辆拍照请求")]
        DOWN_CTRL_MSG_TAKE_PHOTO_REQ = 0x9502,
        ///<summary>
        ///下发车辆报文请求	
        ///</summary>
        [Description("下发车辆报文请求")]
        DOWN_CTRL_MSG_TEXT_INFO = 0x9503,
        ///<summary>
        ///上报车辆行驶记录请求	
        ///</summary>
        [Description("上报车辆行驶记录请求")]
        DOWN_CTRL_MSG_TAKE_TRAVEL_REQ = 0x9504,
        ///<summary>
        ///车辆应急接入监管平台请求消息	
        ///</summary>
        [Description("车辆应急接入监管平台请求消息")]
        DOWN_CTRL_MSG_EMERGENCY_MONITORING_REQ = 0x9505,
        #endregion

        #region 主链路静态信息交换消息 UP_BASE_MSG
        ///<summary>
        ///补报车辆静态信息应答	
        ///</summary>
        [Description("补报车辆静态信息应答")]
        UP_BASE_MSG_VEHICLE_ADDED_ACK = 0x1601,
        #endregion

        #region 从链路静态信息交换消息 DOWN_BASE_MSG
        ///<summary>
        ///补报车辆静态信息请求	
        ///</summary>
        [Description("补报车辆静态信息请求")]
        DOWN_BASE_MSG_VEHICLE_ADDED = 0x9601,
        #endregion
    }
}
