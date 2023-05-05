using Tomas.Weapons.Components;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    public class PlayerWeaponMovementData : PlayerWeaponComponentData<PlayerWeaponAttackMovement>
    {
        protected override void SetWeaponComponentDependency()
        {
            WeaponComponentDependency = typeof(PlayerWeaponMovement);
        }
    }
}