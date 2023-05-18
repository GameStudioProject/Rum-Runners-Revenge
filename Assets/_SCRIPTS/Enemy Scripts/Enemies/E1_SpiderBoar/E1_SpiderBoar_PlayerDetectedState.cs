using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_SpiderBoar_PlayerDetectedState : Enemy_PlayerDetectedState
{
    private E1_SpiderBoar _enemySpiderBoar;


    public E1_SpiderBoar_PlayerDetectedState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, E1_SpiderBoar enemySpiderBoar) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
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

        if (_performEnemyCloseRangeAction)
        {
            _enemyStateMachine.ChangeEnemyState(_enemySpiderBoar.spiderBoar_MeleeAttackState);
        }
        else if (_performEnemyLongRangeAction)
        {
            _enemyStateMachine.ChangeEnemyState(_enemySpiderBoar.spiderBoar_ChargeState);
        }
        else if (!_isPlayerInMaxAgroRange)
        {
            _enemyStateMachine.ChangeEnemyState(_enemySpiderBoar.spiderBoar_LookForPlayerState);
        }
        else if (!_isEnemyDetectingLedge)
        {
            _enemyBase.CoreMovement?.EntityFlip();
            _enemyStateMachine.ChangeEnemyState(_enemySpiderBoar.spiderBoar_MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
