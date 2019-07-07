using JT809.Protocol;
using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System;
using System.Collections.Generic;

namespace JT808.Protocol.Internal
{
    internal class JT809SubBusinessTypeFactory : IJT809SubBusinessTypeFactory
    {
        private readonly Dictionary<ushort, Type> map;
        internal JT809SubBusinessTypeFactory()
        {
            map = new Dictionary<ushort, Type>();
            InitMap();
        }

        private void InitMap()
        {
            foreach (var item in Enum.GetNames(typeof(JT809SubBusinessType)))
            {
                JT809SubBusinessType subBusinessType = item.ToEnum<JT809SubBusinessType>();
                if (!map.ContainsKey((ushort)subBusinessType))
                {
                    JT809BodiesTypeAttribute jT809BodiesTypeAttribute = subBusinessType.GetAttribute<JT809BodiesTypeAttribute>();
                    if (jT809BodiesTypeAttribute != null)
                    {                
                        map.Add((ushort)subBusinessType, jT809BodiesTypeAttribute.JT809BodiesType);
                    }
                }
            }
        }

        public Type GetSubBodiesImplTypeBySubBusinessType(ushort subBusinessType)
        {
            return map.TryGetValue(subBusinessType, out Type type) ? type : null;
        }

        public IJT809SubBusinessTypeFactory SetMap<TJT809SubBodies>(ushort subBusinessType) 
            where TJT809SubBodies : JT809SubBodies
        {
            if (!map.ContainsKey(subBusinessType))
            {
                map.Add(subBusinessType, typeof(TJT809SubBodies));
            }
            return this;
        }

        public IJT809SubBusinessTypeFactory SetMap(ushort subBusinessType, Type subBodiesImplType)
        {
            if (!map.ContainsKey(subBusinessType))
            {
                map.Add(subBusinessType, subBodiesImplType);
            }
            return this;
        }

        public IJT809SubBusinessTypeFactory ReplaceMap<TJT809SubBodies>(ushort subBusinessType) where TJT809SubBodies : JT809SubBodies
        {
            if (!map.ContainsKey(subBusinessType))
            {
                map.Add(subBusinessType, typeof(TJT809SubBodies));
            }
            else
            {
                map[subBusinessType] = typeof(TJT809SubBodies);
            }
            return this;
        }

        public IJT809SubBusinessTypeFactory CustomSetMap<TJT809SubBodies>(ushort subBusinessType) where TJT809SubBodies : JT809SubBodies
        {
            if (!map.ContainsKey(subBusinessType))
            {
                map.Add(subBusinessType, typeof(TJT809SubBodies));
            }
            else
            {
                map[subBusinessType] = typeof(TJT809SubBodies);
            }
            return this;
        }

        public IJT809SubBusinessTypeFactory CustomSetMap(ushort subBusinessType, Type subBodiesImplType)
        {
            if (!map.ContainsKey(subBusinessType))
            {
                map.Add(subBusinessType, subBodiesImplType);
            }
            return this;
        }
    }
}
