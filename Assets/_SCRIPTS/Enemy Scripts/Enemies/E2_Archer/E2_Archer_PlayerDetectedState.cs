using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_Archer_PlayerDetectedState : Enemy_PlayerDetectedState
{
    private E2_Archer _archer;

    public E2_Archer_PlayerDetectedState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyPlayerDetectedState _enemyStateData, E2_Archer _archer) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyStateData)
    {
        this._archer = _archer;
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

        if (_performEnemyCloseRangeAction)
        {
            _enemyStateMachine.ChangeEnemyState(_archer.ArcherMeleeAttack);
        }
        else if (!_isPlayerInMaxAgroRange)
        {
            _enemyStateMachine.ChangeEnemyState(_archer.ArcherLookForPlayerState);
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
