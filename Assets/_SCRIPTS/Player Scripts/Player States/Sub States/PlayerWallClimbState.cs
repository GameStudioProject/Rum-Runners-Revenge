using UnityEngine;

public class PlayerWallClimbState : PlayerTouchWallState
{
    private bool _isPlayerOnWall;
    
    public PlayerWallClimbState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void StateEnter()
    {
        base.StateEnter();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        _player.CoreStats.EntityStamina.DecreaseStat(_playerData.playerWallGrabStaminaReduceAmount);
        
        if (!_isExitingPlayerState)
        {
            _player.CoreMovement.SetEntityVelocityY(_playerData.playerWallClimbSpeed);

            if (_player.CoreStats.EntityStamina.StatCurrentValue <= 0)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerInAirState);
            }
            if (_playerYInput != 1 )
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerWallGrabState);
            }
            
            
        }
        
    }
}
