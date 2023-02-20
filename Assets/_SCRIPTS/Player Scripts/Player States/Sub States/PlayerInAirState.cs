using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerStates
{
    //Player Input
    private int _playerXInput;
    private bool _playerJumpInput;
    private bool _playerJumpInputStop;
    private bool _playerGrabInput;
    private bool _playerDashInput;
    
    //Player Checks
    private bool _isPlayerGrounded;
    private bool _isPlayerTouchingWall;
    private bool _isPlayerTouchingWallBehind;
    private bool _previousIsTouchingWall;
    private bool _previousIsTouchingWallBack;
    private bool _isPlayerTouchingLedge;
    
    private bool _playerCoyoteTime;
    private bool _playerWallJumpCoyoteTime;
    private bool _isPlayerJumping;

    private float _startPlayerWallJumpCoyoteTime;

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

        _previousIsTouchingWall = false;
        _previousIsTouchingWallBack = false;
        _isPlayerTouchingWall = false;
        _isPlayerTouchingWallBehind = false;
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        CheckPlayerCoyoteTime();
        CheckPlayerWallJumpCoyoteTime();

        _playerXInput = _player.PlayerInputHandler.NormInputX;
        _playerJumpInput = _player.PlayerInputHandler.PlayerJumpInput;
        _playerJumpInputStop = _player.PlayerInputHandler.PlayerJumpInputStop;
        _playerGrabInput = _player.PlayerInputHandler.PlayerGrabInput;
        _playerDashInput = _player.PlayerInputHandler.PlayerDashInput;

        CheckPlayerJumpStrength();

        if (_isPlayerGrounded && _core.MovementComponent.PlayerCurrentVelocity.y < 0.01f)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerLandState);
        }
        else if (_isPlayerTouchingWall && !_isPlayerTouchingLedge && !_isPlayerGrounded)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerLedgeClimbState);
        }
        else if (_playerJumpInput && (_isPlayerTouchingWall || _isPlayerTouchingWallBehind || _playerWallJumpCoyoteTime))
        {
            StopWallJumpCoyoteTime();
            _isPlayerTouchingWall = _core.CollisionSenses.CheckIfPlayerTouchesWall;
            _player.PlayerWallJumpState.FindWallJumpDirection(_isPlayerTouchingWall);
            _playerStateMachine.ChangePlayerState(_player.PlayerWallJumpState);
        }
        else if (_playerJumpInput && _player.PlayerJumpState.CanPlayerJump())
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerJumpState);
        }
        else if (_isPlayerTouchingWall && _playerGrabInput && _isPlayerTouchingLedge)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerWallGrabState);
        }
        else if (_isPlayerTouchingWall && _playerXInput == _core.MovementComponent.PlayerFacingDirection && _core.MovementComponent.PlayerCurrentVelocity.y <= 0)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerWallSlideState);
        }
        else if (_playerDashInput && _player.PlayerDashState.CheckIfPlayerCanDash())
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerDashState);
        }
        else
        {
            _core.MovementComponent.CheckIfPlayerShouldFlip(_playerXInput);
            _core.MovementComponent.SetPlayerVelocityX(_playerData.playerMovementSpeed * _playerXInput);
            
            _player.PlayerAnimator.SetFloat("yVelocity", _core.MovementComponent.PlayerCurrentVelocity.y);
            _player.PlayerAnimator.SetFloat("xVelocity", Mathf.Abs(_core.MovementComponent.PlayerCurrentVelocity.x));
        }
    }

    private void CheckPlayerJumpStrength()
    {
        if (_isPlayerJumping)
        {
            if (_playerJumpInputStop)
            {
                _core.MovementComponent.SetPlayerVelocityY(_core.MovementComponent.PlayerCurrentVelocity.y * _playerData.playerJumpHeightStrength);
                _isPlayerJumping = false;
            }
            else if (_core.MovementComponent.PlayerCurrentVelocity.y <= 0.0f)
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

        _previousIsTouchingWall = _isPlayerTouchingWall;
        _previousIsTouchingWallBack = _isPlayerTouchingWallBehind;

        _isPlayerGrounded = _core.CollisionSenses.CheckIfPlayerGrounded;
        _isPlayerTouchingWall = _core.CollisionSenses.CheckIfPlayerTouchesWall;
        _isPlayerTouchingWallBehind = _core.CollisionSenses.CheckIfPlayerTouchesWallBehind;
        _isPlayerTouchingLedge = _core.CollisionSenses.CheckIfPlayerTouchesLedge;

        if (_isPlayerTouchingWall && !_isPlayerTouchingLedge)
        {
            _player.PlayerLedgeClimbState.SetPlayerDetectedPosition(_player.transform.position);
        }

        if (!_playerWallJumpCoyoteTime && !_isPlayerTouchingWall && !_isPlayerTouchingWallBehind && (_previousIsTouchingWall || _previousIsTouchingWallBack))
        {
            StartWallJumpCoyoteTime();
        }
    }

    private void CheckPlayerCoyoteTime()
    {
        if (_playerCoyoteTime && Time.time > stateStartTime + _playerData.playerCoyoteTime)
        {
            _playerCoyoteTime = false;
            _player.PlayerJumpState.DecreasePlayerJumps();
        }
    }

    private void CheckPlayerWallJumpCoyoteTime()
    {
        if (_playerWallJumpCoyoteTime && Time.time > _startPlayerWallJumpCoyoteTime + _playerData.playerCoyoteTime)
        {
            _playerWallJumpCoyoteTime = false;
        }
    }

    public void StartPlayerCoyoteTime() => _playerCoyoteTime = true;

    public void StartWallJumpCoyoteTime()
    {
        _playerWallJumpCoyoteTime = true;
        _startPlayerWallJumpCoyoteTime = Time.time;

    }

    public void StopWallJumpCoyoteTime() => _playerWallJumpCoyoteTime = false;

    public void SetPlayerJump() => _isPlayerJumping = true;

}
