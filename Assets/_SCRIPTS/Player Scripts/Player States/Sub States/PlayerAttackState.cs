using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapon _playerWeapon;

    private int _playerXInput;

    private float _weaponVelocityToSet;
    
    private bool _setPlayerVelocity;
    private bool _shouldPlayerFlip;
    
    public PlayerAttackState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void StateEnter()
    {
        base.StateEnter();

        _setPlayerVelocity = false;
        
        _playerWeapon.EnterWeapon();
    }

    public override void StateExit()
    {
        base.StateExit();
        
        _playerWeapon.ExitWeapon();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        _playerXInput = _player.PlayerInputHandler.NormInputX;

        if (_shouldPlayerFlip)
        {
            MovementComponent?.CheckIfEntityShouldFlip(_playerXInput);
        }

        if (_setPlayerVelocity)
        {
            MovementComponent?.SetEntityVelocityX(_weaponVelocityToSet * MovementComponent.EntityFacingDirection);
        }
    }

    public void SetPlayerWeapon(Weapon weapon)
    {
        _playerWeapon = weapon;
        weapon.InitializeWeapon(this, _core);
    }

    public void SetPlayerVelocity(float velocity)
    {
        MovementComponent?.SetEntityVelocityX(velocity * MovementComponent.EntityFacingDirection);

        _weaponVelocityToSet = velocity;
        _setPlayerVelocity = true;
    }

    public void SetPlayerFlipCheck(bool value)
    {
        _shouldPlayerFlip = value;
    }

    #region Animation Triggers

    public override void PlayerAnimationFinishTrigger()
    {
        base.PlayerAnimationFinishTrigger();

        _isPlayerAbilityDone = true;
    }

    #endregion
}
