using UnityEngine;

namespace Tomas.Weapons.Components
{
    public class PlayerWeaponKnockBack : PlayerWeaponComponent<PlayerWeaponKnockBackData, PlayerWeaponAttackKnockBack>
    {
        private PlayerWeaponActionHitBox weaponHitbox;

        private MovementComponent coreMovement;

        private void HandleWeaponDetectedCollider2D(Collider2D[] colliders)
        {
            foreach (var item in colliders)
            {
                if (item.TryGetComponent(out KnockBackInterface knockBackInterface)) //look for a specific component on a specific component the out keyword means that this knockback variable is now an object in this class that we can work with 
                {
                    knockBackInterface.KnockBack(currentAttackData.KnockBackAngle, currentAttackData.KnockBackStrength, coreMovement.EntityFacingDirection);
                }
            }
        }

        protected override void Start()
        {
            base.Start();

            weaponHitbox = GetComponent<PlayerWeaponActionHitBox>();

            weaponHitbox.HitBoxDetectedCollider2D += HandleWeaponDetectedCollider2D;

            coreMovement = Core.GetCoreComponent<MovementComponent>();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            weaponHitbox.HitBoxDetectedCollider2D -= HandleWeaponDetectedCollider2D;
        }
    }
}