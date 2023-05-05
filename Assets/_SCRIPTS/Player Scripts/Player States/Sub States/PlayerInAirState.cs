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
    private bool _playerGrappleHookInput;
    
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
        _playerGrappleHookInput = _player.PlayerInputHandler.PlayerGrappleHookInput;

        CheckPlayerJumpStrength();

        if (_player.PlayerInputHandler.PlayerAttackInputs[(int)PlayerCombatInputs.primary])
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerPrimaryAttackState);
        }
        else if (_player.PlayerInputHandler.PlayerAttackInputs[(int)PlayerCombatInputs.secondary])
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerSecondaryAttackState);
        }
        else if (_isPlayerGrounded && coreMovement?.EntityCurrentVelocity.y < 0.01f)
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
            _isPlayerTouchingWall = coreCollisionSenses.CheckIfEntityTouchesWall;
            _player.PlayerWallJumpState.FindWallJumpDirection(_isPlayerTouchingWall);
            _playerStateMachine.ChangePlayerState(_player.PlayerWallJumpState);
        }
        else if (_playerJumpInput && _player.PlayerJumpState.CanPlayerJump())
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerJumpState);
        }
        else if (_isPlayerTouchingWall && _playerGrabInput && _isPlayerTouchingLedge && _player.PlayerWallGrabState.CheckIfPlayerCanWallGrab())
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerWallGrabState);
        }
        else if (_isPlayerTouchingWall && _playerXInput == coreMovement?.EntityFacingDirection && coreMovement?.EntityCurrentVelocity.y <= 0)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerWallSlideState);
        }
        else if (_playerDashInput && _player.PlayerDashState.CheckIfPlayerCanDash())
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerDashState);
        }
        else if (_playerGrappleHookInput && _player.PlayerGrappleHookState.CanPlayerGrapple())
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerGrappleHookState);
        }

        else
        {
            coreMovement?.CheckIfEntityShouldFlip(_playerXInput);
            coreMovement?.SetEntityVelocityX(_playerData.playerMovementSpeed * _playerXInput);
            
            _player.PlayerAnimator.SetFloat("yVelocity", coreMovement.EntityCurrentVelocity.y);
            _player.PlayerAnimator.SetFloat("xVelocity", Mathf.Abs(coreMovement.EntityCurrentVelocity.x));
        }
    }

    private void CheckPlayerJumpStrength()
    {
        if (_isPlayerJumping)
        {
            if (_playerJumpInputStop)
            {
                coreMovement?.SetEntityVelocityY(coreMovement.EntityCurrentVelocity.y * _playerData.playerJumpHeightStrength);
                _isPlayerJumping = false;
            }
            else if (coreMovement?.EntityCurrentVelocity.y <= 0.0f)
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

        if (coreCollisionSenses)
        {
            _isPlayerGrounded = coreCollisionSenses.CheckIfEntityGrounded;
            _isPlayerTouchingWall = coreCollisionSenses.CheckIfEntityTouchesWall;
            _isPlayerTouchingWallBehind = coreCollisionSenses.CheckIfEntityTouchesWallBehind;
            _isPlayerTouchingLedge = coreCollisionSenses.CheckIfEntityTouchesLedgeHorizontal;
        }

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
