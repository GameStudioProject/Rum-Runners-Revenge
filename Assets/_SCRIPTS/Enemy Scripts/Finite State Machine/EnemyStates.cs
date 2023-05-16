using System.Collections;
using System.Collections.Generic;
using Tomas.Core;
using UnityEngine;

public class EnemyStates
{
    
    protected EnemyFiniteStateMachine _enemyStateMachine;
    protected EnemyBase _enemyBase;
    public D_EnemyData _enemyData;
    protected Core _core;
    protected MovementComponent coreMovement;
    protected CollisionSenses coreCollisionSenses;

    public float _stateStartTime { get; protected set; }

    protected string _enemyAnimationBoolName;

    public EnemyStates(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine ,string _enemyAnimationBoolName, D_EnemyData _enemyData)
    {
        this._enemyBase = _enemyBase;
        this._enemyData = _enemyData;
        this._enemyStateMachine = _enemyStateMachine;
        this._enemyAnimationBoolName = _enemyAnimationBoolName;
        _core = this._enemyBase.Core;
        
        coreMovement = _core.GetCoreComponent<MovementComponent>();
        coreCollisionSenses = _core.GetCoreComponent<CollisionSenses>();
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
