using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Metadata
{
    public class JT809ManageMsgSNInform
    {
        /// <summary>
        /// 子业务类型标识
        /// </summary>
        public ushort SubBusinessType { get; set; }
        /// <summary>
        /// 对应得子业务数据类型报文序列号
        /// </summary>
        public uint MsgSN { get; set; }
        /// <summary>
        /// 系统UTC时间
        /// </summary>
        public DateTime Time { get; set; }
    }
}
