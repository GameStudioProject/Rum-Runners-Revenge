using UnityEngine;

public class PlayerGroundedState : PlayerStates
{
    protected int _xPlayerInput;
    protected int _yPlayerInput;

    protected bool _isPlayerTouchingCeiling;

    private bool _playerJumpInput;
    private bool _playerGrabInput;
    private bool _isPlayerGrounded;
    private bool _isPlayerTouchingWall;
    private bool _isPlayerTouchingLedge;
    private bool _playerDashInput;
    private bool _playerGrappleHookInput;
    
    public PlayerGroundedState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void StateEnter()
    {
        base.StateEnter();
        
        _player.PlayerJumpState.ResetPlayerJumps();
        _player.PlayerDashState.ResetPlayerDash();
        _player.PlayerGrappleHookState.ResetGrappleHook();
        _player.PlayerWallGrabState.ResetPlayerWallGrab();
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        _xPlayerInput = _player.PlayerInputHandler.NormInputX;
        _yPlayerInput = _player.PlayerInputHandler.NormInputY;
        _playerJumpInput = _player.PlayerInputHandler.PlayerJumpInput;
        _playerGrabInput = _player.PlayerInputHandler.PlayerGrabInput;
        _playerDashInput = _player.PlayerInputHandler.PlayerDashInput;
        _playerGrappleHookInput = _player.PlayerInputHandler.PlayerGrappleHookInput;
        

        if (_player.PlayerInputHandler.PlayerAttackInputs[(int)PlayerCombatInputs.primary] && !_isPlayerTouchingCeiling)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerPrimaryAttackState);
        }
        else if (_player.PlayerInputHandler.PlayerAttackInputs[(int)PlayerCombatInputs.secondary] && !_isPlayerTouchingCeiling)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerSecondaryAttackState);
        }
        else if (_playerJumpInput && _player.PlayerJumpState.CanPlayerJump() && !_isPlayerTouchingCeiling)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerJumpState);
        }
        else if (!_isPlayerGrounded)
        {
            _player.PlayerInAirState.StartPlayerCoyoteTime();
            _playerStateMachine.ChangePlayerState(_player.PlayerInAirState);
        }
        else if (_isPlayerTouchingWall && _playerGrabInput && _isPlayerTouchingLedge)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerWallGrabState);
        }
        else if (_playerDashInput && _player.PlayerDashState.CheckIfPlayerCanDash() && !_isPlayerTouchingCeiling)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerDashState);
        }
        else if (_playerGrappleHookInput && _player.PlayerGrappleHookState.CanPlayerGrapple() && _playerStateMachine.PlayerCurrentState != _player.PlayerMoveState)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerGrappleHookState);
        }
        

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void PerformPlayerChecks()
    {
        base.PerformPlayerChecks();

        if (_player.CoreCollisionSenses)
        {
            _isPlayerGrounded = _player.CoreCollisionSenses.CheckIfEntityGrounded;
            _isPlayerTouchingWall = _player.CoreCollisionSenses.CheckIfEntityTouchesWall;
            _isPlayerTouchingLedge = _player.CoreCollisionSenses.CheckIfEntityTouchesLedgeHorizontal;
            _isPlayerTouchingCeiling = _player.CoreCollisionSenses.CheckForCeiling;
        }
    }
}
