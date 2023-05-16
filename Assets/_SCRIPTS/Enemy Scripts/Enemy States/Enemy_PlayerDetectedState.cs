using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PlayerDetectedState : Enemy_GroundedState
{
    
    protected bool _performEnemyCloseRangeAction;
    protected bool _performEnemyLongRangeAction;


    public Enemy_PlayerDetectedState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
    {
        
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

        if (Time.time >= _stateStartTime + _enemyData.enemyLongRangeActionTime)
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
        
        _performEnemyCloseRangeAction = coreCollisionSenses.EnemyCheckPlayerInCloseRangeAction();
    }
}
