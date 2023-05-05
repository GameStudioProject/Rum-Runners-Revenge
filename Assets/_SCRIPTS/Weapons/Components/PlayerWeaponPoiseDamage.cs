using Tomas.Interfaces;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    public class PlayerWeaponPoiseDamage : PlayerWeaponComponent<PlayerWeaponPoiseDamageData, PlayerWeaponAttackPoiseDamage> //implement component data generics that we just created for this component
    {
        private PlayerWeaponActionHitBox _weaponHitBox; // get a reference to our weapon hitbox 

        private void HandleWeaponDetectCollider2D(Collider2D[] collider)
        {
            foreach (var item in collider)
            {
                if (item.TryGetComponent(out PoiseInterface poiseInterface))
                {
                    poiseInterface.PoiseDamage(currentAttackData.PoiseAmount);
                }
            }
        }

        protected override void Start()
        {
            base.Start();

            _weaponHitBox = GetComponent<PlayerWeaponActionHitBox>();

            _weaponHitBox.HitBoxDetectedCollider2D += HandleWeaponDetectCollider2D;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            _weaponHitBox.HitBoxDetectedCollider2D -= HandleWeaponDetectCollider2D;
        }
    }
}