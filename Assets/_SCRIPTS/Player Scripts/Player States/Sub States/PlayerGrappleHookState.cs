using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrappleHookState : PlayerAbilityState
{
    public bool CanPlayerGrapple { get; private set; }
    
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

        CanPlayerGrapple = false;
        _player.PlayerInputHandler.PlayerUsedGrappleHookInput();

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
            if (_isPlayerGrappleHooking)
            {
                _distanceToGrappleTarget = Vector2.Distance(_player.transform.position, _playerGrappleTarget);

                if (_distanceToGrappleTarget <= _playerData.playerGrappleHookStopDistance)
                {
                    StopGrappleHook();
                    return;
                }

                _grappleDirection = (_playerGrappleTarget - (Vector2)_player.transform.position).normalized;
            
                MovementComponent.SetEntityVelocity(_grappleDirection * _playerData.playerGrappleSpeed);
            
                // Calculate the movement amount using MoveTowards
                float movementAmount = _playerData.playerGrappleSpeed * Time.deltaTime;
                Vector2 newPosition = Vector2.MoveTowards(_player.transform.position, _playerGrappleTarget, movementAmount);

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
        _isPlayerGrappleHooking = true;
    }

    public override void PlayerAnimationFinishTrigger()
    {
        base.PlayerAnimationFinishTrigger();
        
        
    }

    public void StartGrappleHook(Collider2D[] hitColliders)
    {
        if (hitColliders.Length > 0)
        {
            Vector2 closestPoint = hitColliders[0].ClosestPoint(_player.transform.position);
            _playerGrappleTarget = closestPoint;
            _grappleDirection = (_playerGrappleTarget - (Vector2)_player.transform.position).normalized;
            
            if (_grappleDirection.x * MovementComponent.EntityFacingDirection < 0)
            {
                // Flip the player towards the grapple point
                MovementComponent.EntityFlip();
            }
        }
    }

    public void StopGrappleHook()
    {
        _isPlayerGrappleHooking = false;
        _grappleTime = 0f;
        MovementComponent.SetEntityVelocityZero();
        _isPlayerAbilityDone = true;
    }

    public void ResetGrappleHook()
    {
        CanPlayerGrapple = true;
    }
}

