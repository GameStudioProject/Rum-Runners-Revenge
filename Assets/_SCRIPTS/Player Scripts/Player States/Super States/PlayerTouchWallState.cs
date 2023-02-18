using UnityEngine;

public class PlayerTouchWallState : PlayerStates
{
    protected bool _isPlayerGrounded;
    protected bool _isPlayerTouchingWall;
    protected bool _playerGrabInput;
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

        if (_isPlayerGrounded && !_playerGrabInput)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerIdleState);
        }
        else if (!_isPlayerTouchingWall || (_playerXInput != _player.PlayerFacingDirection && !_playerGrabInput))
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerInAirState);
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
}
