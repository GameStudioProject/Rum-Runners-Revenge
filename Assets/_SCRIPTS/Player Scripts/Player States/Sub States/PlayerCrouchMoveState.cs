using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchMoveState : PlayerGroundedState
{
    public PlayerCrouchMoveState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void StateEnter()
    {
        base.StateEnter();
        
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
            coreMovement.SetEntityVelocityX(_playerData.playerCrouchMoveSpeed * coreMovement.EntityFacingDirection);
            coreMovement.CheckIfEntityShouldFlip(_xPlayerInput);
            
            
            
            if (_xPlayerInput == 0 || coreCollisionSenses.CheckIfEntityTouchesWall)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerCrouchIdleState);
            }
            else if (_yPlayerInput != -1 && !_isPlayerTouchingCeiling)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerMoveState);
            }
        }
    }
}
