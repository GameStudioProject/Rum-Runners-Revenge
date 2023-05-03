using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DodgeState : EnemyStates
{
    protected D_EnemyDodgeState _enemyDodgeStateData;

    protected bool _performCloseRangeAction;
    protected bool _isPlayerInMaxAgroRange;
    protected bool _isEnemyGrounded;
    protected bool _isEnemyDodgeOver;
    
    public Enemy_DodgeState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyDodgeState _enemyDodgeStateData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName)
    {
        this._enemyDodgeStateData = _enemyDodgeStateData;
    }

    public override void StateEnter()
    {
        base.StateEnter();

        _isEnemyDodgeOver = false;

        if (collisionSenses.Component.CheckEntityDodgeLandZone)
        {
            movementComponent.Component.SetEntityVelocity(_enemyDodgeStateData.enemyDodgeSpeed, _enemyDodgeStateData.enemyDodgeAngle, -movementComponent.Component.EntityFacingDirection);
        }
        else
        {
            movementComponent.Component.SetEntityVelocity(_enemyDodgeStateData.enemyDodgeSpeed * _enemyDodgeStateData.enemyDodgeSpeedMultiplier, _enemyDodgeStateData.enemyDodgeAngle, movementComponent.Component.EntityFacingDirection);
        }
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (Time.time >= _stateStartTime + _enemyDodgeStateData.enemyDodgeTime && _isEnemyGrounded)
        {
            _isEnemyDodgeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoEnemyChecks()
    {
        base.DoEnemyChecks();

        _performCloseRangeAction = collisionSenses.Component.EnemyCheckPlayerInCloseRangeAction();
        _isPlayerInMaxAgroRange = collisionSenses.Component.EnemyCheckPlayerInMaxAgroRange();

        if (collisionSenses.Component)
        {
            _isEnemyGrounded = collisionSenses.Component.CheckIfEntityGrounded;
        }
    }
}
