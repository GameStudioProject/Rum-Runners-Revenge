using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerStates
{
    private int _playerXInput;
    private bool _isPlayerGrounded;
    private bool _isPlayerTouchingWall;
    private bool _playerJumpInput;
    private bool _playerJumpInputStop;
    private bool _playerCoyoteTime;
    private bool _isPlayerJumping;
    private bool _playerGrabInput;

    public PlayerInAirState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void StateEnter()
    {
        base.StateEnter();
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        CheckPlayerCoyoteTime();

        _playerXInput = _player.PlayerInputHandler.NormInputX;
        _playerJumpInput = _player.PlayerInputHandler.PlayerJumpInput;
        _playerJumpInputStop = _player.PlayerInputHandler.PlayerJumpInputStop;
        _playerGrabInput = _player.PlayerInputHandler.PlayerGrabInput;

        CheckPlayerJumpStrength();

        if (_isPlayerGrounded && _player.PlayerCurrentVelocity.y < 0.01f)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerLandState);
        }
        else if (_playerJumpInput && _player.PlayerJumpState.CanPlayerJump())
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerJumpState);
        }
        else if (_isPlayerTouchingWall && _playerGrabInput)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerWallGrabState);
        }
        else if (_isPlayerTouchingWall && _playerXInput == _player.PlayerFacingDirection && _player.PlayerCurrentVelocity.y <= 0)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerWallSlideState);
        }
        else
        {
            _player.CheckIfPlayerShouldFlip(_playerXInput);
            _player.SetPlayerVelocityX(_playerData.playerMovementSpeed * _playerXInput);
            
            _player.PlayerAnimator.SetFloat("yVelocity", _player.PlayerCurrentVelocity.y);
            _player.PlayerAnimator.SetFloat("xVelocity", Mathf.Abs(_player.PlayerCurrentVelocity.x));
        }
    }

    private void CheckPlayerJumpStrength()
    {
        if (_isPlayerJumping)
        {
            if (_playerJumpInputStop)
            {
                _player.SetPlayerVelocityY(_player.PlayerCurrentVelocity.y * _playerData.playerJumpHeightStrength);
                _isPlayerJumping = false;
            }
            else if (_player.PlayerCurrentVelocity.y <= 0.0f)
            {
                _isPlayerJumping = false;
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void PerformPlayerChecks()
    {
        base.PerformPlayerChecks();

        _isPlayerGrounded = _player.CheckIfPlayerGrounded();
        _isPlayerTouchingWall = _player.CheckIfPlayerTouchesWall();
    }

    private void CheckPlayerCoyoteTime()
    {
        if (_playerCoyoteTime && Time.time > stateStartTime + _playerData.playerCoyoteTime)
        {
            _playerCoyoteTime = false;
            _player.PlayerJumpState.DecreasePlayerJumps();
        }
    }

    public void StartPlayerCoyoteTime() => _playerCoyoteTime = true;

    public void SetPlayerJump() => _isPlayerJumping = true;

}
