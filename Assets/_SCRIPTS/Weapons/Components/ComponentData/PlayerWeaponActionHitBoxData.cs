using UnityEngine;

namespace Tomas.Weapons.Components
{
    public class PlayerWeaponActionHitBoxData : PlayerWeaponComponentData<PlayerWeaponAttackActionHitBox>
    {
        [field: SerializeField] public LayerMask WeaponDetectableLayers { get; private set; }

        public PlayerWeaponActionHitBoxData()
        {
            WeaponComponentDependency = typeof(PlayerWeaponActionHitBox);
        }
    }
}