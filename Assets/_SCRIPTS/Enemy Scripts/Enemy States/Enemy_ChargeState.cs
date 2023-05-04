using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_ChargeState : EnemyStates
{
    protected D_EnemyChargeState _enemyChargeStateData;

    protected bool _isPlayerInMinAgroRange;
    protected bool _isEnemyDetectingLedge;
    protected bool _isEnemyDetectingWall;
    protected bool _isEnemyChargeTimeOver;
    protected bool _performEnemyCloseRangeAction;
    
    public Enemy_ChargeState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyChargeState _enemyChargeStateData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName)
    {
        this._enemyChargeStateData = _enemyChargeStateData;
    }


    public override void StateEnter()
    {
        base.StateEnter();

        _isEnemyChargeTimeOver = false;
        Movement.Component.SetEntityVelocityX(_enemyChargeStateData.enemyChargeSpeed * Movement.Component.EntityFacingDirection);
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        Movement.Component?.SetEntityVelocityX(_enemyChargeStateData.enemyChargeSpeed * Movement.Component.EntityFacingDirection);

        if (Time.time >= _stateStartTime + _enemyChargeStateData.enemyChargeTime)
        {
            _isEnemyChargeTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoEnemyChecks()
    {
        base.DoEnemyChecks();

        if (CollisionSenses.Component)
        {
            _isEnemyDetectingLedge = CollisionSenses.Component.CheckIfEntityTouchesLedgeVertical;
            _isEnemyDetectingWall = CollisionSenses.Component.CheckIfEntityTouchesWall;
        }
        _isPlayerInMinAgroRange = CollisionSenses.Component.EnemyCheckPlayerInMinAgroRange();
        _performEnemyCloseRangeAction = CollisionSenses.Component.EnemyCheckPlayerInCloseRangeAction();
    }
}
