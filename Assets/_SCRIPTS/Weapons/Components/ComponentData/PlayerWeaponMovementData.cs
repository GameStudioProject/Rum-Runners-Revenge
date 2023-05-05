using Tomas.Weapons.Components;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    public class PlayerWeaponMovementData : PlayerWeaponComponentData<PlayerWeaponAttackMovement>
    {
        public PlayerWeaponMovementData()
        {
            WeaponComponentDependency = typeof(PlayerWeaponMovement);
        }
    }
}