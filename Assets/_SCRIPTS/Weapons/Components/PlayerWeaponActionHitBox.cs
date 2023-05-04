using System;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    public class PlayerWeaponActionHitBox : PlayerWeaponComponent<PlayerWeaponActionHitBoxData, PlayerWeaponAttackActionHitBox>
    {
        private event Action<Collider2D[]> _hitBoxDetectedCollider2D;
        
        private CoreAccessComponent<MovementComponent> _coreMovement;

        private Vector2 _hitBoxOffset;

        private Collider2D[] _hitBoxDetected;

        private void HandleAttackAction()
        {
            _hitBoxOffset.Set(transform.position.x + (currentAttackData.WeaponHitBox.center.x * _coreMovement.Component.EntityFacingDirection), transform.position.y + currentAttackData.WeaponHitBox.center.y);

            _hitBoxDetected = Physics2D.OverlapBoxAll(_hitBoxOffset, currentAttackData.WeaponHitBox.size, 0f, weaponComponentData.WeaponDetectableLayers);

            if (_hitBoxDetected.Length == 0)
            {
                return;
            }
            
            _hitBoxDetectedCollider2D?.Invoke(_hitBoxDetected);

            foreach (var item in _hitBoxDetected)
            {
                Debug.Log(item.name);
            }
        }

        protected override void Start()
        {
            base.Start();

            _coreMovement = new CoreAccessComponent<MovementComponent>(Core);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            eventHandler.OnWeaponAttackAction += HandleAttackAction;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

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