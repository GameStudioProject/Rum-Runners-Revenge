using System;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    public abstract class PlayerWeaponComponent : MonoBehaviour //can't attach
    {
        protected PlayerWeapon _playerWeapon;

        protected bool _isWeaponAttackActive;
        
        protected virtual void Awake()
        {
            _playerWeapon = GetComponent<PlayerWeapon>();
        }

        protected virtual void WeaponComponentHandleEnter()
        {
            _isWeaponAttackActive = true;
        }

        protected virtual void WeaponComponentHandleExit()
        {
            _isWeaponAttackActive = false;
        }

        protected virtual void OnEnable()
        {
            _playerWeapon.OnWeaponEnter += WeaponComponentHandleEnter;
            _playerWeapon.OnWeaponExit += WeaponComponentHandleExit;
        }

        protected virtual void OnDisable()
        {
            _playerWeapon.OnWeaponEnter -= WeaponComponentHandleEnter;
            _playerWeapon.OnWeaponExit -= WeaponComponentHandleExit;
        }
    }
}