using Tomas.Weapons.Components;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    public class PlayerWeaponSpriteData : PlayerWeaponComponentData<PlayerWeaponAttackSprites>
    {
        protected override void SetWeaponComponentDependency()
        {
            WeaponComponentDependency = typeof(PlayerWeaponSprite);
        }
    }
}