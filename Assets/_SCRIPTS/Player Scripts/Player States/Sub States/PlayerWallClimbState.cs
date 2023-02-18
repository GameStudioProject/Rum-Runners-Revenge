using UnityEngine;

public class PlayerWallClimbState : PlayerTouchWallState
{
    public PlayerWallClimbState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        _player.SetPlayerVelocityY(_playerData.playerWallClimbSpeed);

        if (_playerYInput != 1 && !_isExitingPlayerState)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerWallGrabState);
        }
    }
}
