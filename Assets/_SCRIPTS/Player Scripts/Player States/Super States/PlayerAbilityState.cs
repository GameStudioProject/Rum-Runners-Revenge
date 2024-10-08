using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerStates
{
    protected bool _isPlayerAbilityDone;

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

    private bool _isPlayerGrounded;
    
    public PlayerAbilityState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void StateEnter()
    {
        base.StateEnter();

        _isPlayerAbilityDone = false;
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (_isPlayerAbilityDone)
        {
            if (_isPlayerGrounded && MovementComponent?.EntityCurrentVelocity.y < 0.01f)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerIdleState);
            }
            else
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerInAirState);
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

        if (CollisionSenses)
        {
            _isPlayerGrounded = CollisionSenses.CheckIfEntityGrounded;
            
        }
    }
}
