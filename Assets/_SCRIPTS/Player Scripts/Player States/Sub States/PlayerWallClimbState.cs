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

        coreStats.EntityStamina.DecreaseStat(_playerData.playerWallGrabStaminaReduceAmount);
        
        if (!_isExitingPlayerState)
        {
            coreMovement.SetEntityVelocityY(_playerData.playerWallClimbSpeed);

            if (coreStats.EntityStamina.StatCurrentValue <= 0)
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
