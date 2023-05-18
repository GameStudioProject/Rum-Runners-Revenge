using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrappleHookState : PlayerAbilityState
{
    public LineRenderer _grappleLineRenderer;
    public bool _canPlayerGrapple { get; private set; }
    public bool _isPlayerGrappleHooking { get; private set; }
    private Vector2 _playerGrappleTarget;
    private float _distanceToGrappleTarget;
    private Vector2 _grappleDirection;
    private float _maxGrappleDistance;
    private Rigidbody2D _rigidbody;

    public PlayerGrappleHookState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData,
        string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
    }

    public override void StateEnter()
    {
        base.StateEnter();
        
        
        _canPlayerGrapple = false;
        _player.PlayerInputHandler.PlayerUsedGrappleHookInput();
        
        _maxGrappleDistance = _playerData.maxGrappleDistance;

        _grappleLineRenderer = _player.GetComponent<LineRenderer>();
        _rigidbody = _player.GetComponent<Rigidbody2D>();
        
        _rigidbody.velocity = _player.CoreMovement.EntityCurrentVelocity;

        StartGrappleHook(_player.CoreCollisionSenses.CheckForGrappleble);

    }

    public override void StateExit()
    {
        base.StateExit();
        
        _rigidbody.velocity = _player.CoreMovement.EntityCurrentVelocity.normalized * _playerData.playerGrappleExitBoost;
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (!_isExitingPlayerState)
        {
            if (_isPlayerGrappleHooking)
            {
                _distanceToGrappleTarget = Vector2.Distance(_player.transform.position, _playerGrappleTarget);

                if (_distanceToGrappleTarget <= _playerData.playerGrappleHookStopDistance || _player.CoreCollisionSenses.CheckEntityGrappleStuck)
                {
                    StopGrappleHook();
                    return;
                }
                if (_distanceToGrappleTarget > _maxGrappleDistance)
                {
                    StopGrappleHook();
                    return;
                }

                _grappleDirection = (_playerGrappleTarget - (Vector2)_player.transform.position).normalized;

                _player.CoreMovement.SetEntityVelocity(_grappleDirection * _playerData.playerGrappleSpeed);
                
                float movementAmount = _playerData.playerGrappleSpeed * Time.deltaTime;
                Vector2 newPosition = Vector2.MoveTowards(_player.transform.position, _playerGrappleTarget, movementAmount);

                _player.transform.position = newPosition;

                if (_grappleLineRenderer != null)
                {
                    _grappleLineRenderer.SetPosition(0, _player.transform.position);
                    _grappleLineRenderer.SetPosition(1, _playerGrappleTarget);
                }
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
        _grappleLineRenderer.enabled = true;
    }

    public override void PlayerAnimationFinishTrigger()
    {
        base.PlayerAnimationFinishTrigger();
    }

    public void StartGrappleHook(Collider2D[] hitColliders)
    {
        _player.CoreMovement.SetEntityVelocityZero();
        if (hitColliders.Length == 0) 
            return; 

        float closestDistance = float.MaxValue;
        Vector2 closestGrapplePoint = Vector2.zero;
        

        foreach (Collider2D collider in hitColliders)
        {
            Vector2 grapplePoint = collider.ClosestPoint(_player.transform.position);
            float distance = Vector2.Distance(_player.transform.position, grapplePoint);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestGrapplePoint = grapplePoint;
            }
        }

        if (_player.transform.position.y > closestGrapplePoint.y)
        {
            StopGrappleHook();
            _player.PlayerAnimator.SetBool("grappleHook", false);
        }

        _playerGrappleTarget = closestGrapplePoint;
        _grappleDirection = (_playerGrappleTarget - (Vector2)_player.transform.position).normalized;

        if (_grappleDirection.x * _player.CoreMovement.EntityFacingDirection < 0)
        {
            _player.CoreMovement.EntityFlip();
        }
    }


    public void StopGrappleHook()
    {
        _isPlayerGrappleHooking = false;
        _grappleLineRenderer.enabled = false;
        _isPlayerAbilityDone = true;
    }

    public void ResetGrappleHook()
    {
        _canPlayerGrapple = true;
        _distanceToGrappleTarget = float.MaxValue;
    }

    public bool CanPlayerGrapple()
    {
        if (_isPlayerGrappleHooking)
        {
            return false;
        }
        else if (_canPlayerGrapple)
        {
            _canPlayerGrapple = false;
            return true;
        }
        
        return false;
        
    }

}
