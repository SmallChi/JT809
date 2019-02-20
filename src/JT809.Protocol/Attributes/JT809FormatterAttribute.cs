using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public  sealed  class JT809FormatterAttribute:Attribute
    {
        public Type FormatterType { get; private set; }

        public object[] Arguments { get; private set; }

        public JT809FormatterAttribute(Type formatterType)
        {
            this.FormatterType = formatterType;
        }

        public JT809FormatterAttribute(Type formatterType, params object[] arguments)
        {
            this.FormatterType = formatterType;
            this.Arguments = arguments;
        }
    }
}
