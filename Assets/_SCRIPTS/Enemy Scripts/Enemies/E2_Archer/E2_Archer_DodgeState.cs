using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_Archer_DodgeState : Enemy_DodgeState
{
    private E2_Archer _archer;


    public E2_Archer_DodgeState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, E2_Archer archer) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
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

        if (_isEnemyDodgeOver)
        {
            if (_isPlayerInMaxAgroRange && _performCloseRangeAction)
            {
                _enemyStateMachine.ChangeEnemyState(_archer.ArcherMeleeAttack);
            }
            else if (_isPlayerInMaxAgroRange && !_performCloseRangeAction)
            {
                _enemyStateMachine.ChangeEnemyState(_archer.ArcherRangedAttackState);
            }
            else if (!_isPlayerInMaxAgroRange)
            {
                _archer.ArcherLookForPlayerState.TurnEnemyImmediately(true);
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
}
