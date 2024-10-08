using UnityEngine;

public class PlayerLedgeClimbState : PlayerStates
{
    protected MovementComponent MovementComponent
    {
        get => _movementComponent ??= _core.GetCoreComponent<MovementComponent>();
    }
    protected CollisionSenses CollisionSenses
    {
        get => _collisionSenses ??= _core.GetCoreComponent<CollisionSenses>();
    }
    
    private MovementComponent _movementComponent;
    private CollisionSenses _collisionSenses;
    
    private Vector2 _playerDetectedPosition;
    private Vector2 _cornerPosition;
    private Vector2 _playerStartPosition;
    private Vector2 _playerStopPosition;
    private Vector2 _velocityWorkspace;

    private bool _isPlayerHanging;
    private bool _isPlayerClimbing;
    private bool _playerJumpInput;
    private bool _isPlayerTouchingCeiling;

    private int _playerXInput;
    private int _playerYInput;
    
    public PlayerLedgeClimbState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public void SetPlayerDetectedPosition(Vector2 position) => _playerDetectedPosition = position;
    
    public override void StateEnter()
    {
        base.StateEnter();
        
        MovementComponent?.SetEntityVelocityZero();
        _player.transform.position = _playerDetectedPosition;
        _cornerPosition = FindCornerPosition();
        
        _playerStartPosition.Set(_cornerPosition.x - (MovementComponent.EntityFacingDirection * _playerData.playerStartOffset.x), _cornerPosition.y - _playerData.playerStartOffset.y);
        _playerStopPosition.Set(_cornerPosition.x + (MovementComponent.EntityFacingDirection * _playerData.playerStopOffset.x), _cornerPosition.y + _playerData.playerStopOffset.y);

        _player.transform.position = _playerStartPosition;
    }

    public override void StateExit()
    {
        base.StateExit();

        _isPlayerHanging = false;

        if (_isPlayerClimbing)
        {
            _player.transform.position = _playerStopPosition;
            _isPlayerClimbing = false;
        }
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (_isPlayerAnimationFinished)
        {
            if (_isPlayerTouchingCeiling)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerCrouchIdleState);
            }
            else
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerIdleState);
            }
        }
        else
        {
            _playerXInput = _player.PlayerInputHandler.NormInputX;
            _playerYInput = _player.PlayerInputHandler.NormInputY;
            _playerJumpInput = _player.PlayerInputHandler.PlayerJumpInput;
            
            MovementComponent?.SetEntityVelocityZero();
            _player.transform.position = _playerStartPosition;
            
            

            if (_playerXInput == MovementComponent?.EntityFacingDirection && _isPlayerHanging && !_isPlayerClimbing)
            {
                CheckForClimbSpace();
                _isPlayerClimbing = true;
                _player.PlayerAnimator.SetBool("climbLedge", true);
            
            }
            else if (_playerYInput == -1 && _isPlayerHanging && !_isPlayerClimbing)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerInAirState);
            }
            else if (_playerJumpInput && !_isPlayerClimbing)
            {
                _player.PlayerWallJumpState.FindWallJumpDirection(true);
                _playerStateMachine.ChangePlayerState(_player.PlayerWallJumpState);
            }
        }

        
    }

    public override void PlayerAnimationTrigger()
    {
        base.PlayerAnimationTrigger();

        _isPlayerHanging = true;
    }

    public override void PlayerAnimationFinishTrigger()
    {
        base.PlayerAnimationFinishTrigger();
        
        _player.PlayerAnimator.SetBool("climbLedge", false);
    }

    private void CheckForClimbSpace()
    {
        _isPlayerTouchingCeiling =
            Physics2D.Raycast(
                _cornerPosition + (Vector2.up * 0.015f) + (Vector2.right * MovementComponent.EntityFacingDirection * 0.015f),
                Vector2.up, _playerData.playerStandHitBoxHeight, CollisionSenses.WhatIsGround);
        
        _player.PlayerAnimator.SetBool("isTouchingCeiling", _isPlayerTouchingCeiling);
    }
    
    private Vector2 FindCornerPosition()
    {
        RaycastHit2D xHit = Physics2D.Raycast(CollisionSenses.EntityWallCheck.position, Vector2.right * MovementComponent.EntityFacingDirection, CollisionSenses.EntityWallCheckDistance, CollisionSenses.WhatIsGround);
        float xDistance = xHit.distance;
        _velocityWorkspace.Set((xDistance + 0.015f) * MovementComponent.EntityFacingDirection, 0f);
        RaycastHit2D yHit = Physics2D.Raycast(CollisionSenses.EntityLedgeCheckHorizontal.position + (Vector3)(_velocityWorkspace), Vector2.down, CollisionSenses.EntityLedgeCheckHorizontal.position.y - CollisionSenses.EntityWallCheck.position.y + 0.015f, CollisionSenses.WhatIsGround);
        float yDistance = yHit.distance;
        
        _velocityWorkspace.Set(CollisionSenses.EntityWallCheck.position.x + (xDistance * MovementComponent.EntityFacingDirection), CollisionSenses.EntityLedgeCheckHorizontal.position.y - yDistance);
        return _velocityWorkspace;
    }
}
