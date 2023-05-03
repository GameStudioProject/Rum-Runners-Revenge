using Tomas.Weapons.Components.ComponentData;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    public class PlayerWeaponMovement : PlayerWeaponComponent
    {
        private MovementComponent _playerCoreMovement;

        private MovementComponent PlayerCoreMovement =>_playerCoreMovement ? _playerCoreMovement : Core.GetCoreComponent<MovementComponent>();

        private PlayerWeaponMovementData _weaponMovementData;
        
        private void HandleWeaponStartMovement()
        {
            var currentAttackData = _weaponMovementData.AttackMovementData[_playerWeapon.AttackCounter];
            
            PlayerCoreMovement.SetEntityVelocity(currentAttackData.PlayerVelocity, currentAttackData.PlayerDirection, PlayerCoreMovement.EntityFacingDirection);
        }

        private void HandleWeaponStopMovement()
        {
            PlayerCoreMovement.SetEntityVelocityZero();
        }

        protected override void Awake()
        {
            base.Awake();

            _weaponMovementData = _playerWeapon.WeaponData.GetData<PlayerWeaponMovementData>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            eventHandler.OnWeaponStartMovement += HandleWeaponStartMovement;
            eventHandler.OnWeaponStopMovement += HandleWeaponStopMovement;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            
            eventHandler.OnWeaponStartMovement -= HandleWeaponStartMovement;
            eventHandler.OnWeaponStopMovement -= HandleWeaponStopMovement;
        }
    }
}