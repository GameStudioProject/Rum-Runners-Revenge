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
        _player.CoreMovement?.SetEntityVelocity(_playerData.playerWallJumpStrength, _playerData.playerWallJumpAngle, _playerWallJumpDirection);
        _player.CoreMovement?.CheckIfEntityShouldFlip(_playerWallJumpDirection);
        _player.PlayerJumpState.DecreasePlayerJumps();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        _player.PlayerAnimator.SetFloat("yVelocity", _player.CoreMovement.EntityCurrentVelocity.y);
        _player.PlayerAnimator.SetFloat("xVelocity", Mathf.Abs(_player.CoreMovement.EntityCurrentVelocity.x));

        if (Time.time >= stateStartTime + _playerData.playerWallJumpTime)
        {
            _isPlayerAbilityDone = true;
        }
    }

    public void FindWallJumpDirection(bool isPlayerTouchingWall)
    {
        if (isPlayerTouchingWall)
        {
            _playerWallJumpDirection = -_player.CoreMovement.EntityFacingDirection;
        }
        else
        {
            _playerWallJumpDirection = _player.CoreMovement.EntityFacingDirection;
        }
    }
}
