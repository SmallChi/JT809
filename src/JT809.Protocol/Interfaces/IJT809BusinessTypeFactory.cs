using System;

namespace JT809.Protocol.Interfaces
{
    public interface IJT809BusinessTypeFactory
    {
        Type GetBodiesImplTypeByBusinessType(ushort businessType, uint msgGNSSCENTERID);
        IJT809BusinessTypeFactory SetMap<TJT809Bodies>(ushort businessType) 
            where TJT809Bodies : JT809Bodies;
        IJT809BusinessTypeFactory SetMap(ushort businessType,Type bodiesImplType);
        IJT809BusinessTypeFactory ReplaceMap<TJT809Bodies>(ushort businessType)
            where TJT809Bodies : JT809Bodies;
        IJT809BusinessTypeFactory CustomSetMap<TJT809Bodies>(ushort businessType, uint msgGNSSCENTERID)
            where TJT809Bodies : JT809Bodies;
        IJT809BusinessTypeFactory CustomSetMap(ushort businessType,uint msgGNSSCENTERID,Type bodiesImplType);
    }
}
