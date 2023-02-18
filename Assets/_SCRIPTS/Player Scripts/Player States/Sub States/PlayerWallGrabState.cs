using UnityEngine;

public class PlayerWallGrabState : PlayerTouchWallState
{
    private Vector2 _playerHoldPosition;
    
    public PlayerWallGrabState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void StateEnter()
    {
        base.StateEnter();

        _playerHoldPosition = _player.transform.position;

        PlayerHoldPosition();
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        PlayerHoldPosition();

        if (_playerYInput > 0)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerWallClimbState);
        }
        else if (_playerYInput < 0 || !_playerGrabInput)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerWallSlideState);
        }
    }

    private void PlayerHoldPosition()
    {
        _player.transform.position = _playerHoldPosition;
        
        _player.SetPlayerVelocityX(0f);
        _player.SetPlayerVelocityY(0f);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void PerformPlayerChecks()
    {
        base.PerformPlayerChecks();
    }
}
