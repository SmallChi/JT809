using System.ComponentModel;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 业务数据类型标识
    /// 数据交换一协议规定的业务数据类型名称和标识常量定义见表 73。业务数据类型标识的命名规则如下:
    /// a) 上级平台向下级平台发送的请求消息，一般以“DOWN_”开头，以后缀_REQ 结尾;而下级平台向上级平台发送的请求消息一般以“UP_”开头，以后缀_REQ 结尾;
    /// b) 当上下级平台之间有应答消息情况下，应答消息可继续沿用对应的请求消息开头标识符，而通过后缀 RSP 来标识结尾。
    /// </summary>
    public enum BusinessType : ushort
    {
        #region 链路管理类
        ///<summary>
        ///主链路登录请求消息  
        ///</summary>
        [Description("主链路登录请求消息")]
        UP_CONNECT_REQ = 0x1001,
        ///<summary>
        ///主链路登录应答消息  
        ///</summary>
        [Description("主链路登录应答消息")]
        UP_CONNECT_RSP = 0x1002,
        ///<summary>
        ///主链路注销请求消息  
        ///</summary>
        [Description("主链路注销请求消息")]
        UP_DISCONNECT_REQ = 0x1003,
        ///<summary>
        ///主链路注销应答消息  
        ///</summary>
        [Description("主链路注销应答消息")]
        UP_DISCONNECT_RSP = 0x1004,
        ///<summary>
        ///主链路连接保持请求消息  
        ///</summary>
        [Description("主链路连接保持请求消息")]
        UP_LINKTEST_REQ = 0x1005,
        ///<summary>
        ///主链路连接保持应答消息  
        ///</summary>
        [Description("主链路连接保持应答消息")]
        UP_LINKTEST_RSP = 0x1006,
        ///<summary>
        ///主链路断开通知消息  
        ///</summary>
        [Description("主链路断开通知消息")]
        UP_DISCONNECT_INFORM = 0x1007,
        ///<summary>
        ///下级平台主动关闭链路通知消息  
        ///</summary>
        [Description("下级平台主动关闭链路通知消息")]
        UP_CLOSELINK_INFORM = 0x1008,
        ///<summary>
        ///从链路连接请求消息  
        ///</summary>
        [Description("从链路连接请求消息")]
        DOWN_CONNECT_REQ = 0x9001,
        ///<summary>
        ///从链路连接应答消息  
        ///</summary>
        [Description("从链路连接应答消息")]
        DOWN_CONNECT_RSP = 0x9002,
        ///<summary>
        ///从链路注销请求消息  
        ///</summary>
        [Description("从链路注销请求消息")]
        DOWN_DISCONNECT_REQ = 0x9003,
        ///<summary>
        ///从链路注销应答消息  
        ///</summary>
        [Description("从链路注销应答消息")]
        DOWN_DISCONNECT_RSP = 0x9004,
        ///<summary>
        ///从链路连接保持请求消息  
        ///</summary>
        [Description("从链路连接保持请求消息")]
        DOWN_LINKTEST_REQ = 0x9005,
        ///<summary>
        ///从链路连接保持应答消息  
        ///</summary>
        [Description("从链路连接保持应答消息")]
        DOWN_LINKTEST_RSP = 0x9006,
        ///<summary>
        ///从链路断开通知消息  
        ///</summary>
        [Description("从链路断开通知消息")]
        DOWN_DISCONNECT_INFORM = 0x9007,
        ///<summary>
        ///上级平台主动关闭链路通知消息  
        ///</summary>
        [Description("上级平台主动关闭链路通知消息")]
        DOWN_CLOSELINK_INFORM = 0x9008,
        #endregion
        #region 信息统计类
        ///<summary>
        ///接收定位信息数量通知消息  
        ///</summary>
        [Description("接收定位信息数量通知消息")]
        DOWN_TOTAL_RECV_BACK_MSG = 0x9101,
        #endregion
        #region 车辆动态信息交换
        ///<summary>
        ///主链路动态信息交换消息  
        ///</summary>
        [Description("主链路动态信息交换消息")]
        UP_EXG_MSG = 0x1200,
        ///<summary>
        ///从链路动态信息交换消息  
        ///</summary>
        [Description("从链路动态信息交换消息")]
        DOWN_EXG_MSG = 0x9200,
        #endregion
        #region 平台间信息交互类
        ///<summary>
        ///主链路平台间信息交互消息  
        ///</summary>
        [Description("主链路平台间信息交互消息")]
        UP_PLATFORM_MSG = 0x1300,
        ///<summary>
        ///从链路平台间信息交互消息  
        ///</summary>
        [Description("从链路平台间信息交互消息")]
        DOWN_PLATFORM_MSG = 0x9300,
        #endregion
        #region 车辆报警信息交互类
        ///<summary>
        ///主链路报警信息交互消息  
        ///</summary>
        [Description("主链路报警信息交互消息")]
        UP_WARN_MSG = 0x1400,
        ///<summary>
        ///从链路报警信息交互消息  
        ///</summary>
        [Description("从链路报警信息交互消息")]
        DOWN_WARN_MSG = 0x9400,
        #endregion
        #region 车辆监管类 
        ///<summary>
        ///主链路车辆监管消息  
        ///</summary>
        [Description("主链路车辆监管消息")]
        UP_CTRL_MSG = 0x1500,
        ///<summary>
        ///从链路车辆监管消息  
        ///</summary>
        [Description("从链路车辆监管消息")]
        DOWN_CTRL_MSG = 0x9500,
        #endregion
        #region 车辆静态信息交换类
        ///<summary>
        ///主链路静态信息交换消息  
        ///</summary>
        [Description("主链路静态信息交换消息")]
        UP_BASE_MSG = 0x1600,
        ///<summary>
        ///从链路静态信息交换消息  
        ///</summary>
        [Description("从链路静态信息交换消息")]
        DOWN_BASE_MSG = 0x9600,
        #endregion
    }
}
