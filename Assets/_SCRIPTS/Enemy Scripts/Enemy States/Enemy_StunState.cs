using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_StunState : Enemy_GroundedState
{
    protected bool _isEnemyStunTimeOver;
    protected bool _isEnemyMovementStopped;
    protected bool _performEnemyCloseRangeAction;


    public Enemy_StunState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
    {
        
    }

    public override void StateEnter()
    {
        base.StateEnter();

        _isEnemyStunTimeOver = false;
        _isEnemyMovementStopped = false;
        coreMovement.SetEntityVelocity(_enemyData.enemyStunKnockBackSpeed, _enemyData.enemyStunKnockBackAngle, _enemyBase.LastDamageDirection);
    }

    public override void StateExit()
    {
        base.StateExit();
        
        _enemyBase.ResetEnemyStunResistance();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (Time.time >= _stateStartTime + _enemyData.enemyStunTime)
        {
            _isEnemyStunTimeOver = true;
        }

        if (_isEnemyGrounded && Time.time >= _stateStartTime + _enemyData.enemyStunKnockBackTime && !_isEnemyMovementStopped)
        {
            _isEnemyMovementStopped = true;
            coreMovement.SetEntityVelocityX(0f);
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
            
            _performEnemyCloseRangeAction = coreCollisionSenses.EnemyCheckPlayerInCloseRangeAction();
            
        }
    }
}
