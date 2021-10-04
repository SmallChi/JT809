using JT808.Protocol.Formatters;
using JT809.Protocol.Configs;
using JT809.Protocol.Enums;
using JT809.Protocol.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JT809.Protocol
{
    public interface IJT809Config
    {
        string ConfigId { get; }
        /// <summary>
        /// 消息流水号
        /// </summary>
        IJT809MsgSNDistributed MsgSNDistributed { get; set; }
        /// <summary>
        /// 头部选项
        /// </summary>
        JT809HeaderOptions HeaderOptions { get; set; }
        /// <summary>
        /// 统一编码
        /// </summary>
        Encoding Encoding { get; set; }
        /// <summary>
        /// 跳过校验码
        /// 测试的时候需要手动修改值，避免验证
        /// 默认：false
        /// </summary>
        bool SkipCRCCode { get; set; }
        /// <summary>
        /// 加密接口
        /// </summary>
        IJT809Encrypt Encrypt { get; set; }
        /// <summary>
        /// 加密选项
        /// </summary>
        JT809EncryptOptions EncryptOptions { get; set; }
        IJT809BusinessTypeFactory BusinessTypeFactory { get; set; }
        IJT809SubBusinessTypeFactory SubBusinessTypeFactory { get; set; }
        IJT809FormatterFactory FormatterFactory { get; set; }
        JT809Version Version { get; set; }
        /// <summary>
        /// JT808回调消息分析器处理
        /// </summary>
        Dictionary<ushort, JT808AnalyzeCallback> AnalyzeCallbacks { get; set; }
        /// <summary>
        /// 全局注册外部程序集
        /// </summary>
        /// <param name="externalAssemblies"></param>
        /// <returns></returns>
        IJT809Config Register(params Assembly[] externalAssemblies);
    }
}
