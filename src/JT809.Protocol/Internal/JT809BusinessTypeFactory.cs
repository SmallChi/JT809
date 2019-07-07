using JT809.Protocol;
using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System;
using System.Collections.Generic;

namespace JT808.Protocol.Internal
{
    internal class JT809BusinessTypeFactory : IJT809BusinessTypeFactory
    {
        private readonly Dictionary<ushort, Type> map;

        private readonly Dictionary<uint, Dictionary<ushort, Type>> customMap;

        internal JT809BusinessTypeFactory()
        {
            map = new Dictionary<ushort, Type>();
            customMap = new Dictionary<uint, Dictionary<ushort, Type>>();
            InitMap();
        }

        private void InitMap()
        {
            foreach (var item in Enum.GetNames(typeof(JT809BusinessType)))
            {
                JT809BusinessType businessType = item.ToEnum<JT809BusinessType>();
                if (!map.ContainsKey((ushort)businessType))
                {
                    JT809BodiesTypeAttribute jT809BodiesTypeAttribute = businessType.GetAttribute<JT809BodiesTypeAttribute>();
                    if (jT809BodiesTypeAttribute != null)
                    {                
                        map.Add((ushort)businessType, jT809BodiesTypeAttribute.JT809BodiesType);
                    }
                }
            }
        }

        public Type GetBodiesImplTypeByBusinessType(ushort businessType,  uint msgGNSSCENTERID)
        {
            //判断有无自定义消息Id类型
            if (customMap.TryGetValue(msgGNSSCENTERID, out var dict))
            {
                if (dict != null)
                {
                    return dict.TryGetValue(businessType, out Type bodiesImptType)? bodiesImptType:null;
                }
            }
            return map.TryGetValue(businessType, out Type type) ? type : null;
        }

        public IJT809BusinessTypeFactory SetMap<TJT809Bodies>(ushort businessType) 
            where TJT809Bodies : JT809Bodies
        {
            if (!map.ContainsKey(businessType))
            {
                map.Add(businessType, typeof(TJT809Bodies));
            }
            return this;
        }

        public IJT809BusinessTypeFactory SetMap(ushort businessType, Type bodiesImplType)
        {
            if (!map.ContainsKey(businessType))
            {
                map.Add(businessType, bodiesImplType);
            }
            return this;
        }

        public IJT809BusinessTypeFactory ReplaceMap<TJT809Bodies>(ushort businessType) where TJT809Bodies : JT809Bodies
        {
            if (!map.ContainsKey(businessType))
            {
                map.Add(businessType, typeof(TJT809Bodies));
            }
            else
            {
                map[businessType] = typeof(TJT809Bodies);
            }
            return this;
        }

        public IJT809BusinessTypeFactory CustomSetMap<TJT809Bodies>(ushort businessType, uint msgGNSSCENTERID) where TJT809Bodies : JT809Bodies
        {
                if (!customMap.TryGetValue(msgGNSSCENTERID, out var dict))
                {
                    if (dict == null)
                    {
                        Dictionary<ushort, Type> tmp = new Dictionary<ushort, Type>();
                        tmp.Add(businessType, typeof(TJT809Bodies));
                        customMap.Add(businessType, tmp);
                    }
                    else
                    {
                        if (!dict.ContainsKey(businessType))
                        {
                            dict.Add(businessType, typeof(TJT809Bodies));
                        }
                    }
                }
            return this;
        }

        public IJT809BusinessTypeFactory CustomSetMap(ushort businessType, uint msgGNSSCENTERID, Type bodiesImplType)
        {
            if (!customMap.TryGetValue(msgGNSSCENTERID, out var dict))
            {
                if (dict == null)
                {
                    Dictionary<ushort, Type> tmp = new Dictionary<ushort, Type>();
                    tmp.Add(businessType, bodiesImplType);
                    customMap.Add(businessType, tmp);
                }
                else
                {
                    if (!dict.ContainsKey(businessType))
                    {
                        dict.Add(businessType, bodiesImplType);
                    }
                }
            }
            return this;
        }
    }
}
