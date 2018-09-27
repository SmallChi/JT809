using JT809.Protocol.Enums;
using JT809.Protocol.JT809Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JT809.Protocol.Test.JT809Extensions
{
    public class JT809BinaryExtensionsTest
    {
        [Fact]
        public void Test1()
        {
            string vno = "粤A12345";
            byte[] bytes = JT809BinaryExtensions.encoding.GetBytes(vno);
            Assert.Equal(7,vno.Length);
            Assert.Equal(8, bytes.Length);
        }

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
    }
}
