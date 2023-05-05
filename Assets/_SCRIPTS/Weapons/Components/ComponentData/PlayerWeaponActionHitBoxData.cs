using UnityEngine;

namespace Tomas.Weapons.Components
{
    public class PlayerWeaponActionHitBoxData : PlayerWeaponComponentData<PlayerWeaponAttackActionHitBox>
    {
        [field: SerializeField] public LayerMask WeaponDetectableLayers { get; private set; }

        protected override void SetWeaponComponentDependency()
        {
            WeaponComponentDependency = typeof(PlayerWeaponActionHitBox);
        }
    }
}