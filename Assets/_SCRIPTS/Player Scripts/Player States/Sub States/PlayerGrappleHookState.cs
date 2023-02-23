using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrappleHookState : PlayerAbilityState
{
    private Vector2 _grappleHookAnchorPoint;
    private Vector2 _grappleHookStartPosition;
    
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

        _isPlayerAbilityDone = false;
        RaycastHit2D hit = Physics2D.Raycast(_player.transform.position, _player.transform.right, _playerData.playerGrappleDistance, CollisionSenses.WhatIsGrappleable);

        if (hit.collider != null)
        {
            _grappleHookAnchorPoint = hit.point;
            _grappleHookStartPosition = _player.transform.position;
        }
        else
        {
            Debug.Log("no anchor point");
        }
        
        _playerData.playerGrappleHook.gameObject.SetActive(true);
        _playerData.playerGrappleHook.transform.position = _grappleHookAnchorPoint;

    }

    public override void StateExit()
    {
        base.StateExit();
        
        _playerData.playerGrappleHook.gameObject.SetActive(false);
        
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        Vector2 direction = _grappleHookAnchorPoint - (Vector2)_player.transform.position;
        float distance = direction.magnitude;
        
        MovementComponent.SetEntityVelocity(_playerData.playerGrappleHookSpeed, direction);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void PlayerAnimationTrigger()
    {
        base.PlayerAnimationTrigger();
    }

    public override void PlayerAnimationFinishTrigger()
    {
        base.PlayerAnimationFinishTrigger();
    }

    public void FindNearestAnchorPoint()
    {
        
    }
}
