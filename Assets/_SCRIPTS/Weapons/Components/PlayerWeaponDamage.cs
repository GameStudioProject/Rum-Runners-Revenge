using UnityEngine;

namespace Tomas.Weapons.Components
{
    public class PlayerWeaponDamage : PlayerWeaponComponent<PlayerWeaponAttackDamageData, PlayerWeaponAttackDamage>
    {
        private PlayerWeaponActionHitBox _weaponHitBox;
        
        private void HandleWeaponDetectCollider2D(Collider2D[] weaponColliders)
        {
            foreach (var item in weaponColliders)
            {
                if (item.TryGetComponent(out DamageInterface damageInterface))
                {
                    damageInterface.Damage(currentAttackData.DamageAmount);
                }
            }
        }

        protected override void Awake()
        {
            base.Awake();

            _weaponHitBox = GetComponent<PlayerWeaponActionHitBox>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _weaponHitBox.HitBoxDetectedCollider2D += HandleWeaponDetectCollider2D;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _weaponHitBox.HitBoxDetectedCollider2D -= HandleWeaponDetectCollider2D;
        }
    }
}