using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MoveState : Enemy_GroundedState
{
    public Enemy_MoveState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
    {
        
    }

    public override void StateEnter()
    {
        base.StateEnter();
        
        _enemyBase.CoreMovement.SetEntityVelocityX(_enemyData.enemyMovementSpeed * _enemyBase.CoreMovement.EntityFacingDirection);
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        _enemyBase.CoreMovement.SetEntityVelocityX(_enemyData.enemyMovementSpeed * _enemyBase.CoreMovement.EntityFacingDirection);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoEnemyChecks()
    {
        base.DoEnemyChecks();
    }
}
