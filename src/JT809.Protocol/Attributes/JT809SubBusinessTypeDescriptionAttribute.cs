using JT809.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class JT809SubBusinessTypeDescriptionAttribute : Attribute
    {
        public ushort BusinessType { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public JT809SubBusinessTypeDescriptionAttribute(string code,string name, JT809BusinessType businessType)
        {
            Code = code;
            Name = name;
            BusinessType = (ushort)businessType;
        }

        public JT809SubBusinessTypeDescriptionAttribute(string code, string name, ushort businessType)
        {
            Code = code;
            Name = name;
            BusinessType = businessType;
        }
    }
}
