using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JT809.Protocol.Test.JT809Extensions
{
    public class JT809BinaryExtensionsTest
    {
        [Fact]
        public void Test2()
        {
            var jT808_Alarms = JT809EnumExtensions.GetEnumTypes<JT808_Alarm>(24, 32);
            var jT808_Alarms1 = JT809EnumExtensions.GetEnumTypes<JT808_Alarm>(5, 32);
            var jT808_Alarms2 = JT809EnumExtensions.GetEnumTypes<JT808_Alarm>(16, 32);
            var jT808_Alarms3 = JT809EnumExtensions.GetEnumTypes<JT808_Alarm>(18, 32);
            var jT808_Alarms4 = JT809EnumExtensions.GetEnumTypes<JT808_Alarm>(31, 32);
            var jT808_Alarms5= JT809EnumExtensions.GetEnumTypes<JT808_Alarm>(8388609, 32);
        }


        [Fact]
        public void Test3()
        {
            var jT808_Status = JT809EnumExtensions.GetEnumTypes<JT808_Status>(24, 32);
            var jT808_Status1 = JT809EnumExtensions.GetEnumTypes<JT808_Status>(5, 32);
            var jT808_Status2 = JT809EnumExtensions.GetEnumTypes<JT808_Status>(16, 32);
            var jT808_Status3 = JT809EnumExtensions.GetEnumTypes<JT808_Status>(18, 32);
            var jT808_Status4 = JT809EnumExtensions.GetEnumTypes<JT808_Status>(31, 32);
            var jT808_Status5 = JT809EnumExtensions.GetEnumTypes<JT808_Status>(8388609, 32);
        }

        [Fact]
        public void Test4()
        {
            var jT808_Status5 = JT809EnumExtensions.GetEnumTypes<JT808_Status>(8388609, 32);
        }

        [Fact]
        public void Test5()
        {
            var jT808_Status5 = JT809EnumExtensions.GetEnumTypes<JT808_Status>(8388609, 32,false);
        }       
        [Fact]
        public void Test6()
        {
            JT809BodiesTypeAttribute jT809BodiesTypeAttribute = JT809BusinessType.接收车辆定位信息数量通知消息.GetAttribute<JT809BodiesTypeAttribute>();
            JT809BodiesTypeAttribute jT809BodiesTypeAttribute1 = JT809BusinessType.发送车辆定位信息数据量通知消息_2019.GetAttribute<JT809BodiesTypeAttribute>();
        }
    }
}
