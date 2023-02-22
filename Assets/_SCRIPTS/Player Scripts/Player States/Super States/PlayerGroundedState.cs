using UnityEngine;

public class PlayerGroundedState : PlayerStates
{
    protected int _xPlayerInput;
    protected int _yPlayerInput;

    protected bool _isPlayerTouchingCeiling;

    protected MovementComponent MovementComponent
    {
        get => _movement ??= _core.GetCoreComponent<MovementComponent>();
    }
    private MovementComponent _movement;
    
    private CollisionSenses CollisionSenses
    {
        get => _collisionSenses ??= _core.GetCoreComponent<CollisionSenses>();
    }
    
    private CollisionSenses _collisionSenses;

    private bool _playerJumpInput;
    private bool _playerGrabInput;
    private bool _isPlayerGrounded;
    private bool _isPlayerTouchingWall;
    private bool _isPlayerTouchingLedge;
    private bool _playerDashInput;
    
    public PlayerGroundedState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void StateEnter()
    {
        base.StateEnter();
        
        _player.PlayerJumpState.ResetPlayerJumps();
        _player.PlayerDashState.ResetPlayerDash();
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void PerformPlayerChecks()
    {
        base.PerformPlayerChecks();

        if (CollisionSenses)
        {
            _isPlayerGrounded = CollisionSenses.CheckIfEntityGrounded;
            _isPlayerTouchingWall =CollisionSenses.CheckIfEntityTouchesWall;
            _isPlayerTouchingLedge = CollisionSenses.CheckIfEntityTouchesLedgeHorizontal;
            _isPlayerTouchingCeiling = CollisionSenses.CheckForCeiling;
        }
    }
}
