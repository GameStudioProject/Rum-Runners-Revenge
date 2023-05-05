using System;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    [Serializable]
    public class PlayerWeaponAttackKnockBack : PlayerWeaponAttackData
    {
        [field: SerializeField] public Vector2 KnockBackAngle { get; private set; }
        [field: SerializeField] public float KnockBackStrength { get; private set; }
    }
}