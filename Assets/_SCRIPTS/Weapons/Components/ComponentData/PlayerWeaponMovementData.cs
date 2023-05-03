using Tomas.Weapons.Components.ComponentData.AttackData;
using UnityEngine;

namespace Tomas.Weapons.Components.ComponentData
{
    public class PlayerWeaponMovementData : PlayerWeaponComponentData
    {
        [field: SerializeField] public PlayerWeaponAttackMovement[] AttackMovementData { get; private set; } 
    }
}