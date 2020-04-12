using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Metadata
{
    /// <summary>
    /// 车辆静态信息数据体  
    /// </summary>
    public class JT809VehicleStaticInfo_2019
    {
        /// <summary>
        /// 车牌号 必填
        /// 车牌号码中不设分隔符号。所有字母数字连续保存
        /// </summary>
        public string Vin { get; set; }
        /// <summary>
        ///  车牌颜色 必填  应该使用枚举
        /// </summary>
        public string VehicleColor { get; set; }
        /// <summary>
        /// 车辆类型 必填 应该使用枚举
        /// </summary>
        public string VehicleType { get; set; }
        /// <summary>
        /// 运输行业编码 必填 应该使用枚举
        /// </summary>
        public string TransType { get; set; }
        /// <summary>
        /// 车籍地  必填
        /// </summary>
        public string VehicleNationnality { get; set; }
        /// <summary>
        /// 经营范围代码 必填  应该使用枚举
        /// </summary>
        public string BusinessCopeCode { get; set; }
        /// <summary>
        /// 业户ID 非必填  该业户ID为下级平台存储业户信息所采用的ID编号  
        /// </summary>
        public string OwersId { get; set; }
        /// <summary>
        /// 业户名称 必填    运输企业名称
        /// </summary>
        public string OwersName { get; set; }
        /// <summary>
        /// 业户联系电话  非必填  运输企业名称
        /// </summary>
        public string OwersTel { get; set; }
    }
}
