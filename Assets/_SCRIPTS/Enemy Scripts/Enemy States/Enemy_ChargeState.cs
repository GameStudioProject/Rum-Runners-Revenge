using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_ChargeState : Enemy_GroundedState
{
    protected bool _isEnemyChargeTimeOver;
    protected bool _performEnemyCloseRangeAction;


    public Enemy_ChargeState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
    {
    }

    public override void StateEnter()
    {
        base.StateEnter();

        _isEnemyChargeTimeOver = false;
        _enemyBase.CoreMovement.SetEntityVelocityX(_enemyData.enemyChargeSpeed * _enemyBase.CoreMovement.EntityFacingDirection);
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        _enemyBase.CoreMovement?.SetEntityVelocityX(_enemyData.enemyChargeSpeed * _enemyBase.CoreMovement.EntityFacingDirection);

        if (Time.time >= _stateStartTime + _enemyData.enemyChargeTime)
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
        
        _performEnemyCloseRangeAction = _enemyBase.CoreCollisionSenses.EnemyCheckPlayerInCloseRangeAction();
    }
}
