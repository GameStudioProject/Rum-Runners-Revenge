using System;
using UnityEngine;

namespace Tomas.Weapons
{
    public class PlayerWeaponAnimationHandler : MonoBehaviour
    {
        public event Action OnWeaponFinish;
        
        private void WeaponAnimationFinishedTrigger() => OnWeaponFinish?.Invoke(); //? = null check
        
    }
}