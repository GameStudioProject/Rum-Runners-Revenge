using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PlayerDetectedState : EnemyStates
{
    protected D_EnemyPlayerDetectedState _enemyStateData;

    protected bool _isPlayerInMinAgroRange;
    protected bool _isPlayerInMaxAgroRange;
    protected bool _performEnemyCloseRangeAction;
    protected bool _performEnemyLongRangeAction;
    protected bool _isEnemyDetectingLedge;
    
    public Enemy_PlayerDetectedState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyPlayerDetectedState _enemyStateData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName)
    {
        this._enemyStateData = _enemyStateData;
    }

    public override void StateEnter()
    {
        base.StateEnter();

        _performEnemyLongRangeAction = false;
        coreMovement.SetEntityVelocityX(0f);
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        coreMovement.SetEntityVelocityX(0f);

        if (Time.time >= _stateStartTime + _enemyStateData.enemyLongRangeActionTime)
        {
            _performEnemyLongRangeAction = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoEnemyChecks()
    {
        base.DoEnemyChecks();
        
        _isPlayerInMinAgroRange = coreCollisionSenses.EnemyCheckPlayerInMinAgroRange();
        _isPlayerInMaxAgroRange = coreCollisionSenses.EnemyCheckPlayerInMaxAgroRange();
        if (coreCollisionSenses)
        {
            _isEnemyDetectingLedge = coreCollisionSenses.CheckIfEntityTouchesLedgeVertical;
        }

        _performEnemyCloseRangeAction = coreCollisionSenses.EnemyCheckPlayerInCloseRangeAction();
    }
}
