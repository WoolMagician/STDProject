using UnityEngine;

public interface IPowerUP : IData
{
    void ApplyPowerUP(IData data, IHasPowerUPs poweredUpObject);
}

// Forse � meglio tipizzare?
//public interface IPowerUP<T> where T : IData
//{
//    void ApplyPowerUP(T data);
//}