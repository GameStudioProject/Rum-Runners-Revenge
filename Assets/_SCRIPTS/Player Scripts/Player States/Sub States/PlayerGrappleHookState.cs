using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrappleHookState : PlayerAbilityState
{
    private Vector2 _playerGrappleTarget;
    private Vector2 _direction;
    private bool _isPlayerGrappleHooking;
    private float _distanceToGrappleTarget;
    

    public PlayerGrappleHookState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void PerformPlayerChecks()
    {
        base.PerformPlayerChecks();
    }

    public override void StateEnter()
    {
        base.StateEnter();
        
        StartGrappleHook(CollisionSenses.CheckForGrappleble);
        
    }

    public override void StateExit()
    {
        base.StateExit();
        //MovementComponent.SetEntityVelocityZero();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (_isPlayerGrappleHooking)
        {
            _direction = (CollisionSenses.EntityGrappleCheck.position - _player.transform.position).normalized;
            _distanceToGrappleTarget = Vector2.Distance(_player.transform.position, _playerGrappleTarget);

            if (_distanceToGrappleTarget <= _playerData.playerGrappleHookStopDistance)
            {
                StopGrappleHook();
                _player.transform.position = _playerGrappleTarget;
                MovementComponent.SetEntityVelocityZero();
                return;
            }

            MovementComponent.SetEntityVelocity(_direction);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void StartGrappleHook(Collider2D[] hitColliders)
    {
        if (hitColliders.Length > 0)
        {
            _isPlayerGrappleHooking = true;
            Vector2 closestPoint = hitColliders[0].ClosestPoint(_player.transform.position);
            _playerGrappleTarget = closestPoint;
        }
    }

    public void StopGrappleHook()
    {
        _isPlayerGrappleHooking = false;
    }
}
