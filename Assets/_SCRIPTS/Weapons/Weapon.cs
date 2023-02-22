using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected SO_WeaponData _playerWeaponData;
    
    protected Animator _baseAnimator;
    protected Animator _weaponAnimator;

    protected PlayerAttackState _playerAttackState;

    protected Core _core;

    protected int _playerAttackCounter;

    protected virtual void Awake()
    {
        _baseAnimator = transform.Find("Base").GetComponent<Animator>();
        _weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();
        
        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        if (_playerAttackCounter >= _playerWeaponData.amountOfAttacks)
        {
            _playerAttackCounter = 0;
        }
        
        _baseAnimator.SetBool("attack", true);
        _weaponAnimator.SetBool("attack", true);
        
        _baseAnimator.SetInteger("attackCounter", _playerAttackCounter);
        _weaponAnimator.SetInteger("attackCounter", _playerAttackCounter);
    }

    public virtual void ExitWeapon()
    {
        _baseAnimator.SetBool("attack", false);
        _weaponAnimator.SetBool("attack", false);

        _playerAttackCounter++;
        
        gameObject.SetActive(false);
    }

    #region Animation Triggers

    public virtual void AnimationFinishTrigger()
    {
        _playerAttackState.PlayerAnimationFinishTrigger();
    }

    public virtual void AnimationStartMovementTrigger()
    {
        _playerAttackState.SetPlayerVelocity(_playerWeaponData.weaponMovementSpeed[_playerAttackCounter]);
    }

    public virtual void AnimationStopMovementTrigger()
    {
        _playerAttackState.SetPlayerVelocity(0f);
    }

    public virtual void AnimationTurnOffPlayerFlipTrigger()
    {
        _playerAttackState.SetPlayerFlipCheck(false);
    }

    public virtual void AnimationTurnOnPlayerFlipTrigger()
    {
        _playerAttackState.SetPlayerFlipCheck(true);
    }

    public virtual void AnimationPlayerActionTrigger()
    {
        
    }

    #endregion

    public void InitializeWeapon(PlayerAttackState state, Core core)
    {
        _playerAttackState = state;
        _core = core;
    }
}
