using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_SpiderBoar_MoveState : Enemy_MoveState
{
    private E1_SpiderBoar _enemySpiderBoar;


    public E1_SpiderBoar_MoveState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, E1_SpiderBoar enemySpiderBoar) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
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

        if (_isPlayerInMinAgroRange)
        {
            _enemyStateMachine.ChangeEnemyState(_enemySpiderBoar.spiderBoar_PlayerDetectedState);
        }
        else if (_isEnemyDetectingWall || !_isEnemyDetectingLedge)
        {
            _enemySpiderBoar.spiderBoar_IdleState.SetEnemyFlipAfterIdle(true);
            _enemyStateMachine.ChangeEnemyState(_enemySpiderBoar.spiderBoar_IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
