using System;
using UnityEngine;
using Tomas.Utilities;


namespace Tomas.Weapons
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private int _numberOfAttacks;
        [SerializeField] private float _attackCounterResetCooldown;

        public int AttackCounter
        {
            get => _attackCounter;
            private set => _attackCounter = value >= _numberOfAttacks ? 0 : value;
        }
        
        public event Action OnWeaponExit;
        
        private Animator _weaponAnimator;
        private GameObject _weaponBaseGameObject;

        private PlayerWeaponAnimationHandler _playerWeaponEventHandler;

        private int _attackCounter;

        private Timer _attackCounterResetTimer;
        
        public void WeaponEnter()
        { 
            print($"{transform.name} enter");
            
            _attackCounterResetTimer.StopTimer();
            
            _weaponAnimator.SetBool("active", true);
            _weaponAnimator.SetInteger("counter", AttackCounter);
            
        }

        private void WeaponExit()
        {
            _weaponAnimator.SetBool("active", false);

            AttackCounter++;
            _attackCounterResetTimer.StartTimer();
            
            OnWeaponExit?.Invoke();
        }

        private void Awake()
        {
            _weaponBaseGameObject = transform.Find("Base").gameObject;
            _weaponAnimator = _weaponBaseGameObject.GetComponent<Animator>();

            _playerWeaponEventHandler = _weaponBaseGameObject.GetComponent<PlayerWeaponAnimationHandler>();

            _attackCounterResetTimer = new Timer(_attackCounterResetCooldown);
        }

        private void Update()
        {
            _attackCounterResetTimer.TimerTick();
        }

        private void ResetWeaponAttackCounter() => AttackCounter = 0;

        private void OnEnable()
        {
            _playerWeaponEventHandler.OnWeaponFinish += WeaponExit;
            _attackCounterResetTimer.OnTimerDone += ResetWeaponAttackCounter;
        }

        private void OnDisable()
        {
            _playerWeaponEventHandler.OnWeaponFinish -= WeaponExit;
            _attackCounterResetTimer.OnTimerDone -= ResetWeaponAttackCounter;
        }
    }
}