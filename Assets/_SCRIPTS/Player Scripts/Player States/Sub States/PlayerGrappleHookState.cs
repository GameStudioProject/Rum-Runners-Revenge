using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrappleHookState : PlayerAbilityState
{
    private Vector2 _playerGrappleTarget;
    private bool _isPlayerGrappleHooking;
    private float _distanceToGrappleTarget;
    private Vector2 _grappleDirection;
    private float _grappleTime;
    
    public PlayerGrappleHookState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
    }

    public override void StateEnter()
    {
        base.StateEnter();
        StartGrappleHook(CollisionSenses.CheckForGrappleble);
    }

    public override void StateExit()
    {
        base.StateExit();
        MovementComponent.SetEntityVelocityZero();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        Debug.Log("Velocity: " + MovementComponent.EntityCurrentVelocity);


        if (_isPlayerGrappleHooking)
        {
            _distanceToGrappleTarget = Vector2.Distance(_player.transform.position, _playerGrappleTarget);

            if (_distanceToGrappleTarget <= _playerData.playerGrappleHookStopDistance)
            {
                StopGrappleHook();
                return;
            }

            _grappleTime += Time.deltaTime;

            if (_grappleTime >= _playerData.playerGrappleHookDuration)
            {
                StopGrappleHook();
                return;
            }

            float lerpTime = _grappleTime / _playerData.playerGrappleHookDuration;
            Vector2 newPosition = Vector2.Lerp(_player.transform.position, _playerGrappleTarget, lerpTime);

            _grappleDirection = (newPosition - (Vector2)_player.transform.position).normalized;
            MovementComponent.SetEntityVelocity(_grappleDirection * _playerData.playerGrappleSpeed);
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
            _grappleDirection = (_playerGrappleTarget - (Vector2)_player.transform.position).normalized;
        }
    }

    public void StopGrappleHook()
    {
        _isPlayerGrappleHooking = false;
        _grappleTime = 0f;
        MovementComponent.SetEntityVelocityZero();
    }
}

