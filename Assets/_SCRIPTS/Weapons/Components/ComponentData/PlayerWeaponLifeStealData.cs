using Tomas.Weapons.Components;
using UnityEngine;


public class PlayerWeaponLifeStealData : PlayerWeaponComponentData<PlayerWeaponAttackLifeSteal>
{
    protected override void SetWeaponComponentDependency()
    {
        WeaponComponentDependency = typeof(PlayerWeaponLifeSteal);
    }
}
