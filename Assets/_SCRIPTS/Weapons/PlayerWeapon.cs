using System;
using UnityEngine;
using Unity.VisualScripting;
using Timer = Tomas.Utilities.Timer;
using Tomas.Core;
using Tomas.Weapons;


public class PlayerWeapon : MonoBehaviour
    {
        
        [SerializeField] private float _attackCounterResetCooldown;
        
        public PlayerWeaponDataSO WeaponData { get; private set; }

        public int AttackCounter
        {
            get => _attackCounter;
            private set => _attackCounter = value >= WeaponData.NumberOfAttacks ? 0 : value;
        }

        public event Action OnWeaponEnter;
        public event Action OnWeaponExit;
        
        private Animator _weaponAnimator;
        public GameObject BaseWeaponGameObject { get; private set; }
        public GameObject WeaponSpriteGameObject { get; private set; }

        public PlayerWeaponAnimationHandler PlayerWeaponEventHandler { get; private set; }
        
        public Core Core { get; private set; }

        private int _attackCounter;

        private Timer _attackCounterResetTimer;
        
        public void WeaponEnter()
        { 
            print($"{transform.name} enter");
            
            _attackCounterResetTimer.StopTimer();
            
            _weaponAnimator.SetBool("active", true);
            _weaponAnimator.SetInteger("counter", AttackCounter);
            
            OnWeaponEnter?.Invoke();
            
        }

        public void SetCore(Core core)
        {
            Core = core;
        }

        public void SetWeaponData(PlayerWeaponDataSO data)
        {
            WeaponData = data;
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
            BaseWeaponGameObject = transform.Find("Base").gameObject;
            WeaponSpriteGameObject = transform.Find("WeaponSprite").gameObject;
            _weaponAnimator = BaseWeaponGameObject.GetComponent<Animator>();

            PlayerWeaponEventHandler = BaseWeaponGameObject.GetComponent<PlayerWeaponAnimationHandler>();

            _attackCounterResetTimer = new Timer(_attackCounterResetCooldown);
        }

        

        private void Update()
        {
            _attackCounterResetTimer.TimerTick();
        }

        private void ResetWeaponAttackCounter() => AttackCounter = 0;

        private void OnEnable()
        {
            PlayerWeaponEventHandler.OnWeaponFinish += WeaponExit;
            _attackCounterResetTimer.OnTimerDone += ResetWeaponAttackCounter;
        }

        private void OnDisable()
        {
            PlayerWeaponEventHandler.OnWeaponFinish -= WeaponExit;
            _attackCounterResetTimer.OnTimerDone -= ResetWeaponAttackCounter;
        }
    }