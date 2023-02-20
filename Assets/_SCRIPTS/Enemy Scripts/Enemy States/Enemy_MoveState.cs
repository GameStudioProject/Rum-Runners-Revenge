using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MoveState : EnemyStates
{
    protected D_EnemyMoveState _enemyStateData;

    protected bool _isEnemyDetectingWall;
    protected bool _isEnemyDetectingLedge;
    protected bool _isPlayerInMinAgroRange;
    
    public Enemy_MoveState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyMoveState _enemyStateData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName)
    {
        this._enemyStateData = _enemyStateData;
    }


    public override void StateEnter()
    {
        base.StateEnter();
        
        _enemyBase.SetVelocity(_enemyStateData.EnemyMovementSpeed);
        
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoEnemyChecks()
    {
        base.DoEnemyChecks();
        
        _isEnemyDetectingLedge = _enemyBase.EnemyCheckLedge();
        _isEnemyDetectingWall = _enemyBase.EnemyCheckWall();
        _isPlayerInMinAgroRange = _enemyBase.EnemyCheckPlayerInMinAgroRange();
    }
}
