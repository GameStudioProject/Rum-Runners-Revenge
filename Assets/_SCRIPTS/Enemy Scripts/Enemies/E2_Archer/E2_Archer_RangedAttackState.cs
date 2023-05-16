using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_Archer_RangedAttackState : Enemy_RangedAttackState
{
    private E2_Archer _archer;


    public E2_Archer_RangedAttackState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, Transform enemyAttackPosition, E2_Archer archer) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData, enemyAttackPosition)
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

        if (_isEnemyAnimationFinished)
        {
            if (_isPlayerInMinAgroRange)
            {
                _enemyStateMachine.ChangeEnemyState(_archer.ArcherPlayerDetectedState);
            }
            else
            {
                _enemyStateMachine.ChangeEnemyState(_archer.ArcherLookForPlayerState);
            }
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

    public override void EnemyTriggerAttack()
    {
        base.EnemyTriggerAttack();
    }

    public override void EnemyFinishAttack()
    {
        base.EnemyFinishAttack();
    }
}
