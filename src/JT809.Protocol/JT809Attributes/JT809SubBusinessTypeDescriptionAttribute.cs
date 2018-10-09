using JT809.Protocol.JT809Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class JT809SubBusinessTypeDescriptionAttribute : Attribute
    {
        public JT809BusinessType BusinessType { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public JT809SubBusinessTypeDescriptionAttribute(string code,string name, JT809BusinessType businessType)
        {
            Code = code;
            Name = name;
            BusinessType = businessType;
        }
    }
}
