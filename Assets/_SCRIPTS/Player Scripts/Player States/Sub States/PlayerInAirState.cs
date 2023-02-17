using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerStates
{
    private int _playerXInput;
    private bool _isPlayerGrounded;

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

        _playerXInput = _player.PlayerInputHandler.NormInputX;

        if (_isPlayerGrounded && _player.PlayerCurrentVelocity.y < 0.01f)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerLandState);
        }
        else
        {
            _player.CheckIfPlayerShouldFlip(_playerXInput);
            _player.SetPlayerVelocityX(_playerData.playerMovementSpeed * _playerXInput);
            
            _player.PlayerAnimator.SetFloat("yVelocity", _player.PlayerCurrentVelocity.y);
            _player.PlayerAnimator.SetFloat("xVelocity", Mathf.Abs(_player.PlayerCurrentVelocity.x));
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
