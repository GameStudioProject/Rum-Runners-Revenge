using Tomas.Weapons.Components;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    public class PlayerWeaponMovement : PlayerWeaponComponent<PlayerWeaponMovementData, PlayerWeaponAttackMovement>
    {
        private MovementComponent _playerCoreMovement;

        private MovementComponent PlayerCoreMovement =>_playerCoreMovement ? _playerCoreMovement : Core.GetCoreComponent<MovementComponent>();
        
        
        private void HandleWeaponStartMovement()
        {
            PlayerCoreMovement.SetEntityVelocity(currentAttackData.PlayerVelocity, currentAttackData.PlayerDirection, PlayerCoreMovement.EntityFacingDirection);
        }

        private void HandleWeaponStopMovement()
        {
            PlayerCoreMovement.SetEntityVelocityZero();
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