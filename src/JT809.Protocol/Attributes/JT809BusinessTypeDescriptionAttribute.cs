using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class JT809BusinessTypeDescriptionAttribute : Attribute
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public JT809BusinessTypeDescriptionAttribute(string code,string name)
        {
            Code = code;
            Name = name;
        }
    }
}
