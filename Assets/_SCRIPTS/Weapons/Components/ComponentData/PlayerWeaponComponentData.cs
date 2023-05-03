using System;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    [Serializable]
    public class PlayerWeaponComponentData
    {
        
    }
    
    [Serializable]
    public class PlayerWeaponComponentData<T> : PlayerWeaponComponentData where T : PlayerWeaponAttackData
    {
        [field: SerializeField] public T[] WeaponAttackData { get; private set; }
    }
}