using System.Collections;
using System.Collections.Generic;
using Tomas.Weapons;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private PlayerWeapon _playerWeapon;
    
    public PlayerAttackState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName, PlayerWeapon playerWeapon) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        this._playerWeapon = playerWeapon;

        _playerWeapon.OnWeaponExit += ExitWeaponHandler;
    }

    public override void StateEnter()
    {
        base.StateEnter();

        _playerWeapon.WeaponEnter();
    }

    private void ExitWeaponHandler()
    {
        PlayerAnimationFinishTrigger();
        _isPlayerAbilityDone = true;
    }
}
