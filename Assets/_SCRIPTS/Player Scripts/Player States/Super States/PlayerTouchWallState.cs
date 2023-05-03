using UnityEngine;

public class PlayerTouchWallState : PlayerStates
{
    protected bool _isPlayerGrounded;
    protected bool _isPlayerTouchingWall;
    protected bool _playerGrabInput;
    protected bool _playerJumpInput;
    protected bool _isPlayerTouchingLedge;
    protected int _playerXInput;
    protected int _playerYInput;
    
    public PlayerTouchWallState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
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

        _playerXInput = _player.PlayerInputHandler.NormInputX;
        _playerYInput = _player.PlayerInputHandler.NormInputY;
        _playerGrabInput = _player.PlayerInputHandler.PlayerGrabInput;
        _playerJumpInput = _player.PlayerInputHandler.PlayerJumpInput;

        if (_playerJumpInput)
        {
            _player.PlayerWallJumpState.FindWallJumpDirection(_isPlayerTouchingWall);
            _playerStateMachine.ChangePlayerState(_player.PlayerWallJumpState);
        }
        else if (_isPlayerGrounded && !_playerGrabInput)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerIdleState);
        }
        else if (!_isPlayerTouchingWall || (_playerXInput != movementComponent.Component.EntityFacingDirection && !_playerGrabInput))
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerInAirState);
        }
        else if (_isPlayerTouchingWall && !_isPlayerTouchingLedge)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerLedgeClimbState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void PerformPlayerChecks()
    {
        base.PerformPlayerChecks();

        if (collisionSenses.Component)
        {
            _isPlayerGrounded = collisionSenses.Component.CheckIfEntityGrounded;
            _isPlayerTouchingWall = collisionSenses.Component.CheckIfEntityTouchesWall;
            _isPlayerTouchingLedge = collisionSenses.Component.CheckIfEntityTouchesLedgeHorizontal;
        }

        if (_isPlayerTouchingWall && !_isPlayerTouchingLedge)
        {
            _player.PlayerLedgeClimbState.SetPlayerDetectedPosition(_player.transform.position);
        }
    }
}
