using System;

namespace JT809.Protocol.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class JT809BodiesTypeAttribute : Attribute
    {
        public JT809BodiesTypeAttribute(Type jT809BodiesType)
        {
            JT809BodiesType = jT809BodiesType;
        }
        public Type JT809BodiesType { get;}
    }
}
