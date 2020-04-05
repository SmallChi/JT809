using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JT809.Protocol.Test.JT1078
{
    public static class JT1078DependencyInjectionExtensions
    {
        public static IJT809Builder AddJT1078Configure(this IJT809Builder builder)
        {
            builder.Config.Register(Assembly.GetExecutingAssembly());
            builder.Config.BusinessTypeFactory.SetMap<JT808_JT1078_0x1700>();
            //#warning 不知道是不是jt1078协议的809结构有问题，先按交换的格式（少了数据交换的头部）
            builder.Config.SubBusinessTypeFactory.SetMap<JT808_JT1078_0x1700_0x1701>();
            return builder;
        }
    }
}
