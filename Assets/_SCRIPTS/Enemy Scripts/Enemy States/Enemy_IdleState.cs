using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_IdleState : Enemy_GroundedState
{
    protected bool _enemyFlipAfterIdle;
    protected bool _isEnemyIdleTimeOver;

    protected float _enemyIdleTime;


    public Enemy_IdleState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
    {
    }

    public override void StateEnter()
    {
        base.StateEnter();
        
        coreMovement.SetEntityVelocityX(0f);
        _isEnemyIdleTimeOver = false;
        
        SetEnemyRandomIdleTime();
    }

    public override void StateExit()
    {
        base.StateExit();

        if (_enemyFlipAfterIdle)
        {
            coreMovement.EntityFlip();
        }
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        coreMovement.SetEntityVelocityX(0f);

        if (Time.time >= _stateStartTime + _enemyIdleTime)
        {
            _isEnemyIdleTimeOver = true;
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
    }

    public void SetEnemyFlipAfterIdle(bool flip)
    {
        _enemyFlipAfterIdle = flip;
    }

    private void SetEnemyRandomIdleTime()
    {
        _enemyIdleTime = Random.Range(_enemyData.enemyMinIdleTime, _enemyData.enemyMaxIdleTime);
    }
}
