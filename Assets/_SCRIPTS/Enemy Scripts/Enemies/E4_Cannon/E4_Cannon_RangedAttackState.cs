using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class E4_Cannon_RangedAttackState : Enemy_RangedAttackState
{
    private E4_Cannon _cannon;


    public E4_Cannon_RangedAttackState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, Transform enemyAttackPosition, E4_Cannon cannon) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData, enemyAttackPosition)
    {
        _cannon = cannon;
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
                _enemyStateMachine.ChangeEnemyState(_cannon.CannonPlayerDetectedState);
            }
            else
            {
                _enemyStateMachine.ChangeEnemyState(_cannon.CannonLookForPlayerState);
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
