using UnityEngine;

public class PlayerWallJumpState : PlayerAbilityState
{
    private int _playerWallJumpDirection;
    
    public PlayerWallJumpState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
    }

    public override void StateEnter()
    {
        base.StateEnter();
        
        
        _player.PlayerInputHandler.PlayerUsedJumpInput();
        _player.PlayerJumpState.ResetPlayerJumps();
        _core.MovementComponent.SetEntityVelocity(_playerData.playerWallJumpStrength, _playerData.playerWallJumpAngle, _playerWallJumpDirection);
        _core.MovementComponent.CheckIfEntityShouldFlip(_playerWallJumpDirection);
        _player.PlayerJumpState.DecreasePlayerJumps();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        _player.PlayerAnimator.SetFloat("yVelocity", _core.MovementComponent.EntityCurrentVelocity.y);
        _player.PlayerAnimator.SetFloat("xVelocity", Mathf.Abs(_core.MovementComponent.EntityCurrentVelocity.x));

        if (Time.time >= stateStartTime + _playerData.playerWallJumpTime)
        {
            _isPlayerAbilityDone = true;
        }
    }

    public void FindWallJumpDirection(bool isPlayerTouchingWall)
    {
        if (isPlayerTouchingWall)
        {
            _playerWallJumpDirection = -_core.MovementComponent.EntityFacingDirection;
        }
        else
        {
            _playerWallJumpDirection = _core.MovementComponent.EntityFacingDirection;
        }
    }
}
