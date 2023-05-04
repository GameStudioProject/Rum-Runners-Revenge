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
        
        Movement.Component.SetEntityVelocityX(_enemyStateData.EnemyMovementSpeed * Movement.Component.EntityFacingDirection);
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        Movement.Component.SetEntityVelocityX(_enemyStateData.EnemyMovementSpeed * Movement.Component.EntityFacingDirection);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoEnemyChecks()
    {
        base.DoEnemyChecks();

        if (CollisionSenses.Component)
        {
            _isEnemyDetectingLedge = CollisionSenses.Component.CheckIfEntityTouchesLedgeVertical;
            _isEnemyDetectingWall = CollisionSenses.Component.CheckIfEntityTouchesWall;
        }
        
        _isPlayerInMinAgroRange = CollisionSenses.Component.EnemyCheckPlayerInMinAgroRange();
    }
}
