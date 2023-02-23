using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrappleHookState : PlayerAbilityState
{
    private GameObject _grappleHook;
    private Vector2 _grappleHookAnchorPoint;
    
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
        _grappleHook = GameObject.Instantiate(_playerData.playerGrappleHook, _player.transform.position, Quaternion.identity);
        
        Debug.Log("Grappling?");
        
    }

    public override void StateExit()
    {
        base.StateExit();
        
        GameObject.Destroy(_grappleHook);
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        if (Vector2.Distance(_grappleHook.transform.position, _grappleHookAnchorPoint) < 0.1f)
        {
            _isPlayerAbilityDone = true;
        }
        
        Vector2 direction = _grappleHookAnchorPoint - (Vector2)_grappleHook.transform.position;
        _grappleHook.transform.right = direction.normalized;
        MovementComponent.SetEntityVelocity(_playerData.playerGrappleHookSpeed, direction.normalized);
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
        RaycastHit2D[] hits = Physics2D.RaycastAll(_player.transform.position, Vector2.up, 100f, CollisionSenses.WhatIsGrappleable);

        if (hits.Length > 0)
        {
            _grappleHookAnchorPoint = hits[0].point;
            _grappleHook.transform.right = _grappleHookAnchorPoint - (Vector2)_grappleHook.transform.position;
        }
        else
        {
            _isPlayerAbilityDone = true;
        }
    }
}
