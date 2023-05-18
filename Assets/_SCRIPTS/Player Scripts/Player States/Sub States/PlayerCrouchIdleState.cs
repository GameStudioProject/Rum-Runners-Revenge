using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchIdleState : PlayerGroundedState
{
    public PlayerCrouchIdleState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void StateEnter()
    {
        base.StateEnter();
        
        _player.CoreMovement.SetEntityVelocityZero();
        _player.SetPlayerHitBoxHeight(_playerData.playerCrouchHitBoxHeight);
    }

    public override void StateExit()
    {
        base.StateExit();
        
        _player.SetPlayerHitBoxHeight(_playerData.playerStandHitBoxHeight);
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (!_isExitingPlayerState)
        {
            if (_xPlayerInput == _player.CoreMovement.EntityFacingDirection && _player.CoreCollisionSenses.CheckIfEntityTouchesWall)
            {
                return;
            }
            
            if (_xPlayerInput != 0)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerCrouchMoveState);
            }
            else if (_yPlayerInput != -1 && !_isPlayerTouchingCeiling)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerIdleState);
            }
        }
    }
}
