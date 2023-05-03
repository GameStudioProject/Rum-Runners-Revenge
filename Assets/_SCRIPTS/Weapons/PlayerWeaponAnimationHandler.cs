using System;
using UnityEngine;

namespace Tomas.Weapons
{
    public class PlayerWeaponAnimationHandler : MonoBehaviour
    {
        public event Action OnWeaponFinish;
        public event Action OnWeaponStartMovement;
        public event Action OnWeaponStopMovement;
        public event Action OnWeaponAttackAction;
        
        private void WeaponAnimationFinishedTrigger() => OnWeaponFinish?.Invoke(); //? = null check
        private void WeaponStartMovementTrigger() => OnWeaponStartMovement?.Invoke();
        private void WeaponStopMovementTrigger() => OnWeaponStopMovement?.Invoke();
        private void AttackActionTrigger() => OnWeaponAttackAction?.Invoke();

    }
}