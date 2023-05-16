using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_Archer_IdleState : Enemy_IdleState
{
    private E2_Archer _archer;


    public E2_Archer_IdleState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, E2_Archer archer) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
    {
        _archer = archer;
    }

    public override void StateEnter()
    {
        base.StateEnter();
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (_isPlayerInMinAgroRange)
        {
            _enemyStateMachine.ChangeEnemyState(_archer.ArcherPlayerDetectedState);
        }
        else if (_isEnemyIdleTimeOver)
        {
            _enemyStateMachine.ChangeEnemyState(_archer.ArcherMoveState);
        }
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
