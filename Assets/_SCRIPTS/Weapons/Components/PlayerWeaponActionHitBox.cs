using System;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    public class PlayerWeaponActionHitBox : PlayerWeaponComponent<PlayerWeaponActionHitBoxData, PlayerWeaponAttackActionHitBox>
    {
        public event Action<Collider2D[]> HitBoxDetectedCollider2D;
        
        private MovementComponent _coreMovement;

        private Vector2 _hitBoxOffset;

        private Collider2D[] _hitBoxDetected;

        private void HandleAttackAction()
        {
            _hitBoxOffset.Set(transform.position.x + (currentAttackData.WeaponHitBox.center.x * _coreMovement.EntityFacingDirection), transform.position.y + currentAttackData.WeaponHitBox.center.y);

            _hitBoxDetected = Physics2D.OverlapBoxAll(_hitBoxOffset, currentAttackData.WeaponHitBox.size, 0f, weaponComponentData.WeaponDetectableLayers);

            if (_hitBoxDetected.Length == 0)
            {
                return;
            }
            
            HitBoxDetectedCollider2D?.Invoke(_hitBoxDetected);
        }

        protected override void Start()
        {
            base.Start();

            _coreMovement = Core.GetCoreComponent<MovementComponent>();
            
            eventHandler.OnWeaponAttackAction += HandleAttackAction;
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();

            eventHandler.OnWeaponAttackAction -= HandleAttackAction;
        }

        private void OnDrawGizmosSelected()
        {
            if (weaponComponentData == null)
            {
                return;
            }

            foreach (var item in weaponComponentData.WeaponAttackData)
            {
                if (!item.Debug)
                {
                    continue;
                }
                Gizmos.DrawWireCube(transform.position + (Vector3)item.WeaponHitBox.center, item.WeaponHitBox.size);
            }
        }
    }
}