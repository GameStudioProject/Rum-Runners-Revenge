using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates
{
    protected EnemyFiniteStateMachine _enemyStateMachine;
    protected EnemyBase _enemyBase;
    protected Core _core;

    public float _stateStartTime { get; protected set; }

    protected string _enemyAnimationBoolName;

    public EnemyStates(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName)
    {
        this._enemyBase = _enemyBase;
        this._enemyStateMachine = _enemyStateMachine;
        this._enemyAnimationBoolName = _enemyAnimationBoolName;
        _core = this._enemyBase.Core;
    }

    public virtual void StateEnter()
    {
        _stateStartTime = Time.time;
        _enemyBase.EnemyAnimator.SetBool(_enemyAnimationBoolName, true);
        DoEnemyChecks();
    }

    public virtual void StateExit()
    {
        _enemyBase.EnemyAnimator.SetBool(_enemyAnimationBoolName, false);
    }

    public virtual void EveryFrameUpdate()
    {
        
    }

    public virtual void PhysicsUpdate()
    {
        DoEnemyChecks();
    }

    public virtual void DoEnemyChecks()
    {
        
    }
}
