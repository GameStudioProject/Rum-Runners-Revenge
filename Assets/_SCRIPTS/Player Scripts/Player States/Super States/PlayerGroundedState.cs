using UnityEngine;

public class PlayerGroundedState : PlayerStates
{
    protected int _xPlayerInput;

    private bool _playerJumpInput;
    private bool _isPlayerGrounded;
    
    public PlayerGroundedState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void StateEnter()
    {
        base.StateEnter();
        
        _player.PlayerJumpState.ResetPlayerJumps();
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        _xPlayerInput = _player.PlayerInputHandler.NormInputX;
        _playerJumpInput = _player.PlayerInputHandler.PlayerJumpInput;

        if (_playerJumpInput && _player.PlayerJumpState.CanPlayerJump())
        {
            _player.PlayerInputHandler.PlayerUsedJumpInput();
            _playerStateMachine.ChangePlayerState(_player.PlayerJumpState);
        }
        else if (!_isPlayerGrounded)
        {
            _player.PlayerInAirState.StartPlayerCoyoteTime();
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
    }
}
