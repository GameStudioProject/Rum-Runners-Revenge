using UnityEngine;

public class PlayerWallSlideState : PlayerTouchWallState
{
    public PlayerWallSlideState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        _player.SetPlayerVelocityY(-_playerData.playerWallSlideSpeed);

        if (_playerGrabInput && _playerYInput == 0 && !_isExitingPlayerState)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerWallGrabState);
        }
    }
}
