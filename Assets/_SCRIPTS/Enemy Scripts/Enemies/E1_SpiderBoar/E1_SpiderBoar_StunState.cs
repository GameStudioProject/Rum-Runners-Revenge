using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_SpiderBoar_StunState : Enemy_StunState
{
    private E1_SpiderBoar _enemySpiderBoar;


    public E1_SpiderBoar_StunState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, E1_SpiderBoar enemySpiderBoar) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
    {
        _enemySpiderBoar = enemySpiderBoar;
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

        if (_isEnemyStunTimeOver)
        {
            if (_performEnemyCloseRangeAction)
            {
                _enemyStateMachine.ChangeEnemyState(_enemySpiderBoar.spiderBoar_MeleeAttackState);
            }
            else if (_isPlayerInMinAgroRange)
            {
                _enemyStateMachine.ChangeEnemyState(_enemySpiderBoar.spiderBoar_ChargeState);
            }
            else
            {
                _enemySpiderBoar.spiderBoar_LookForPlayerState.TurnEnemyImmediately(true);
                _enemyStateMachine.ChangeEnemyState(_enemySpiderBoar.spiderBoar_LookForPlayerState);
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
