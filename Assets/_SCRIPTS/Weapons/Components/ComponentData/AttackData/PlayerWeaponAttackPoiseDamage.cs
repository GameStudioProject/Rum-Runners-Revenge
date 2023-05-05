using System;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    [Serializable]
    public class PlayerWeaponAttackPoiseDamage : PlayerWeaponAttackData
    {
        [field: SerializeField] public float PoiseAmount { get; private set; }
    }
}