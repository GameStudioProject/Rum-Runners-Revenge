using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (_xPlayerInput != 0)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerMoveState);
        }
        else if (_isPlayerAnimationFinished)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerIdleState);
        }
    }


}
