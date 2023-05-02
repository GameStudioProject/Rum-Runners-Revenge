using System;
using UnityEngine;

namespace Tomas.Weapons
{
    public class PlayerWeapon : MonoBehaviour
    {
        public event Action OnWeaponExit;
        
        private Animator _weaponAnimator;
        private GameObject _weaponBaseGameObject;

        private PlayerWeaponAnimationHandler _playerWeaponEventHandler;
        
        public void WeaponEnter()
        { 
            print($"{transform.name} enter");
            
            _weaponAnimator.SetBool("active", true);
            
        }

        private void WeaponExit()
        {
            _weaponAnimator.SetBool("active", false);
            
            OnWeaponExit?.Invoke();
        }

        private void Awake()
        {
            _weaponBaseGameObject = transform.Find("Base").gameObject;
            _weaponAnimator = _weaponBaseGameObject.GetComponent<Animator>();

            _playerWeaponEventHandler = _weaponBaseGameObject.GetComponent<PlayerWeaponAnimationHandler>();
        }

        private void OnEnable()
        {
            _playerWeaponEventHandler.OnWeaponFinish += WeaponExit;
        }

        private void OnDisable()
        {
            _playerWeaponEventHandler.OnWeaponFinish -= WeaponExit;
        }
    }
}