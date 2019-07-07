using System;

namespace JT809.Protocol.Interfaces
{
    public interface IJT809SubBusinessTypeFactory
    {
        Type GetSubBodiesImplTypeBySubBusinessType(ushort subBusinessType);
        IJT809SubBusinessTypeFactory SetMap<TJT809SubBodies>(ushort subBusinessType) 
            where TJT809SubBodies : JT809SubBodies;
        IJT809SubBusinessTypeFactory SetMap(ushort subBusinessType,Type subBodiesImplType);
        IJT809SubBusinessTypeFactory ReplaceMap<TJT809SubBodies>(ushort subBusinessType)
            where TJT809SubBodies : JT809SubBodies;
        IJT809SubBusinessTypeFactory CustomSetMap<TJT809SubBodies>(ushort subBusinessType)
            where TJT809SubBodies : JT809SubBodies;
        IJT809SubBusinessTypeFactory CustomSetMap(ushort subBusinessType,Type subBodiesImplType);
    }
}
