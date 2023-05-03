using System;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    [Serializable]
    public class PlayerWeaponAttackMovement : PlayerWeaponAttackData
    {
        [field: SerializeField] public Vector2 PlayerDirection { get; private set; }
        [field: SerializeField] public float PlayerVelocity { get; private set; }
    }
}