using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrappleHookState : PlayerAbilityState
{
    public bool canPlayerGrapple { get; private set; }
    private Vector2 playerGrappleTarget;
    private bool isPlayerGrappleHooking;
    private float distanceToGrappleTarget;
    private Vector2 grappleDirection;
    private float grappleTime;
    private float maxGrappleDistance;

    public PlayerGrappleHookState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData,
        string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
    }

    public override void StateEnter()
    {
        base.StateEnter();

        canPlayerGrapple = false;
        _player.PlayerInputHandler.PlayerUsedGrappleHookInput();
        maxGrappleDistance = _playerData.maxGrappleDistance;

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

        if (!_isExitingPlayerState)
        {
            if (isPlayerGrappleHooking)
            {
                distanceToGrappleTarget = Vector2.Distance(_player.transform.position, playerGrappleTarget);

                if (distanceToGrappleTarget <= _playerData.playerGrappleHookStopDistance)
                {
                    StopGrappleHook();
                    return;
                }
                else if (distanceToGrappleTarget > maxGrappleDistance)
                {
                    StopGrappleHook();
                    return;
                }

                grappleDirection = (playerGrappleTarget - (Vector2)_player.transform.position).normalized;

                MovementComponent.SetEntityVelocity(grappleDirection * _playerData.playerGrappleSpeed);
                
                float movementAmount = _playerData.playerGrappleSpeed * Time.deltaTime;
                Vector2 newPosition =
                    Vector2.MoveTowards(_player.transform.position, playerGrappleTarget, movementAmount);

                _player.transform.position = newPosition;
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void PlayerAnimationTrigger()
    {
        base.PlayerAnimationTrigger();
        isPlayerGrappleHooking = true;
    }

    public override void PlayerAnimationFinishTrigger()
    {
        base.PlayerAnimationFinishTrigger();
    }

    public void StartGrappleHook(Collider2D[] hitColliders)
    {
        if (hitColliders.Length == 0) return;
        Vector2 closestPoint = hitColliders[0].ClosestPoint(_player.transform.position);
        playerGrappleTarget = closestPoint;
        grappleDirection = (playerGrappleTarget - (Vector2)_player.transform.position).normalized;

        if (grappleDirection.x * MovementComponent.EntityFacingDirection < 0)
        {
            MovementComponent.EntityFlip();
        }
        
    }

    public void StopGrappleHook()
    {
        isPlayerGrappleHooking = false;
        grappleTime = 0f;
        MovementComponent.SetEntityVelocityZero();
        _isPlayerAbilityDone = true;
    }

    public void ResetGrappleHook()
    {
        canPlayerGrapple = true;
        distanceToGrappleTarget = float.MaxValue;
        grappleTime = 0f;
    }
}
