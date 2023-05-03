using System;
using UnityEngine;

namespace Tomas.Weapons.Components.ComponentData.AttackData
{
    [Serializable]
    public class PlayerWeaponAttackMovement
    {
        [field: SerializeField] public Vector2 PlayerDirection { get; private set; }
        [field: SerializeField] public float PlayerVelocity { get; private set; }
    }
}