using UnityEngine;

public class PlayerWallClimbState : PlayerTouchWallState
{
    

    public PlayerWallClimbState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (!_isExitingPlayerState)
        {
            MovementComponent?.SetEntityVelocityY(_playerData.playerWallClimbSpeed);

            if (Time.time >= stateStartTime + _playerData.playerWallClimbTime)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerInAirState);
            }
            if (_playerYInput != 1)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerWallGrabState);
            }
        }
        
    }
}
