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
        coreMovement.SetEntityVelocityX(_enemyChargeStateData.enemyChargeSpeed * coreMovement.EntityFacingDirection);
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        coreMovement?.SetEntityVelocityX(_enemyChargeStateData.enemyChargeSpeed * coreMovement.EntityFacingDirection);

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

        if (coreCollisionSenses)
        {
            _isEnemyDetectingLedge = coreCollisionSenses.CheckIfEntityTouchesLedgeVertical;
            _isEnemyDetectingWall = coreCollisionSenses.CheckIfEntityTouchesWall;
        }
        _isPlayerInMinAgroRange = coreCollisionSenses.EnemyCheckPlayerInMinAgroRange();
        _performEnemyCloseRangeAction = coreCollisionSenses.EnemyCheckPlayerInCloseRangeAction();
    }
}
