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
        _core.MovementComponent.SetEntityVelocityX(_enemyChargeStateData.enemyChargeSpeed * _core.MovementComponent.EntityFacingDirection);
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

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
        
        _isPlayerInMinAgroRange = _enemyBase.EnemyCheckPlayerInMinAgroRange();
        _isEnemyDetectingLedge = _core.CollisionSenses.CheckIfEntityTouchesLedgeVertical;
        _isEnemyDetectingWall = _core.CollisionSenses.CheckIfEntityTouchesWall;

        _performEnemyCloseRangeAction = _enemyBase.EnemyCheckPlayerInCloseRangeAction();
    }
}
