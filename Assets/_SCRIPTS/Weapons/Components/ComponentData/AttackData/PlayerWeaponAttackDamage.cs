using System;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    [Serializable]
    public class PlayerWeaponAttackDamage : PlayerWeaponAttackData
    {
        [field: SerializeField] public float DamageAmount { get; private set; }
    }
}