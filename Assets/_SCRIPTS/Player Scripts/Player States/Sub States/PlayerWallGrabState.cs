using UnityEngine;

public class PlayerWallGrabState : PlayerTouchWallState
{
    private Vector2 _playerHoldPosition;
    public bool CanPlayerWallGrab { get; private set; }

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
        
        _player.CoreStats.EntityStamina.DecreaseStat(_playerData.playerWallGrabStaminaReduceAmount) ;

        if (!_isExitingPlayerState)
        {
            
            _player.CoreMovement.SetEntityVelocityX(0f);
            _player.CoreMovement.SetEntityVelocityY(-_playerData.playerWallGrabSlideSpeed);

            if (_player.CoreStats.EntityStamina.StatCurrentValue <= 0)
            {
                _player.PlayerInputHandler.PlayerUsedWallGrabInput();
                _playerStateMachine.ChangePlayerState(_player.PlayerInAirState);
            }
            else if (_playerYInput > 0)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerWallClimbState);
            }
            else if (_playerYInput < 0 || !_playerGrabInput)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerWallSlideState);
            }
        }
        
    }
    
    private void PlayerHoldPosition()
    {
        _player.transform.position = _playerHoldPosition;
        
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void PerformPlayerChecks()
    {
        base.PerformPlayerChecks();
    }

    public bool CheckIfPlayerCanWallGrab()
    {
        if (CanPlayerWallGrab)
        {
            CanPlayerWallGrab = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetPlayerWallGrab()
    {
        CanPlayerWallGrab = true;
    }
}
