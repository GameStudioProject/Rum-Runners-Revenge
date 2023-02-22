using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_IdleState : EnemyStates
{
    protected D_EnemyIdleState _enemyStateData;

    protected bool _enemyFlipAfterIdle;
    protected bool _isEnemyIdleTimeOver;
    protected bool _isPlayerInMinAgroRange;

    protected float _enemyIdleTime;
    
    public Enemy_IdleState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyIdleState _enemyStateData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName)
    {
        this._enemyStateData = _enemyStateData;
    }


    public override void StateEnter()
    {
        base.StateEnter();
        
        _core.MovementComponent.SetEntityVelocityX(0f);
        _isEnemyIdleTimeOver = false;
        
        SetEnemyRandomIdleTime();
    }

    public override void StateExit()
    {
        base.StateExit();

        if (_enemyFlipAfterIdle)
        {
            _core.MovementComponent.EntityFlip();
        }
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

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
        
        _isPlayerInMinAgroRange = _enemyBase.EnemyCheckPlayerInMinAgroRange();
    }

    public void SetEnemyFlipAfterIdle(bool flip)
    {
        _enemyFlipAfterIdle = flip;
    }

    private void SetEnemyRandomIdleTime()
    {
        _enemyIdleTime = Random.Range(_enemyStateData.enemyMinIdleTime, _enemyStateData.enemyMaxIdleTime);
    }
}
