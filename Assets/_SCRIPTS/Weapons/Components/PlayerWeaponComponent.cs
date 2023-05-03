using System;
using Tomas.Weapons.Components;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    public abstract class PlayerWeaponComponent : MonoBehaviour //can't attach
    {
        protected PlayerWeapon _playerWeapon;

        protected PlayerWeaponAnimationHandler eventHandler;
        protected Core Core => _playerWeapon.Core;

        protected bool _isWeaponAttackActive;
        
        protected virtual void Awake()
        {
            _playerWeapon = GetComponent<PlayerWeapon>();

            eventHandler = GetComponentInChildren<PlayerWeaponAnimationHandler>();
        }

        protected virtual void Start()
        {
            
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

    public abstract class PlayerWeaponComponent<T1, T2> : PlayerWeaponComponent where T1 : PlayerWeaponComponentData<T2> where T2 : PlayerWeaponAttackData
    {
        protected T1 weaponComponentData;
        protected T2 currentAttackData;

        protected override void WeaponComponentHandleEnter()
        {
            base.WeaponComponentHandleEnter();

            currentAttackData = weaponComponentData.WeaponAttackData[_playerWeapon.AttackCounter];
        }

        protected override void Awake()
        {
            base.Awake();

            weaponComponentData = _playerWeapon.WeaponData.GetData<T1>();
        }
    }
}