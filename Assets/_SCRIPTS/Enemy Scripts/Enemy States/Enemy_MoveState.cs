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
        
        _core.MovementComponent.SetEntityVelocityX(_enemyStateData.EnemyMovementSpeed * _core.MovementComponent.EntityFacingDirection);
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        _core.MovementComponent.SetEntityVelocityX(_enemyStateData.EnemyMovementSpeed * _core.MovementComponent.EntityFacingDirection);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoEnemyChecks()
    {
        base.DoEnemyChecks();
        
        _isEnemyDetectingLedge = _core.CollisionSenses.CheckIfEntityTouchesLedgeVertical;
        _isEnemyDetectingWall = _core.CollisionSenses.CheckIfEntityTouchesWall;
        _isPlayerInMinAgroRange = _enemyBase.EnemyCheckPlayerInMinAgroRange();
    }
}
