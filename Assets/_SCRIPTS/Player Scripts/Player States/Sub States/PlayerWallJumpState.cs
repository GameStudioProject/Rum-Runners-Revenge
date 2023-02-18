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
        
        _player.PlayerJumpState.ResetPlayerJumps();
        _player.SetPlayerVelocity(_playerData.playerWallJumpStrength, _playerData.playerWallJumpAngle, _playerWallJumpDirection);
        _player.CheckIfPlayerShouldFlip(_playerWallJumpDirection);
        _player.PlayerJumpState.DecreasePlayerJumps();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        _player.PlayerAnimator.SetFloat("yVelocity", _player.PlayerCurrentVelocity.y);
        _player.PlayerAnimator.SetFloat("xVelocity", Mathf.Abs(_player.PlayerCurrentVelocity.x));

        if (Time.time >= stateStartTime + _playerData.playerWallJumpTime)
        {
            _isPlayerAbilityDone = true;
        }
    }

    public void FindWallJumpDirection(bool isPlayerTouchingWall)
    {
        if (isPlayerTouchingWall)
        {
            _playerWallJumpDirection = -_player.PlayerFacingDirection;
        }
        else
        {
            _playerWallJumpDirection = _player.PlayerFacingDirection;
        }
    }
}
