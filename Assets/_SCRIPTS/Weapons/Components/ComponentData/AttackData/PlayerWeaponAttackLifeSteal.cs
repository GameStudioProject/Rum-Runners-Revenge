using System;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    [Serializable]
    public class PlayerWeaponAttackLifeSteal : PlayerWeaponAttackData
    {
        [field: SerializeField] public float LifeStealAmount { get; private set; }
    }
}