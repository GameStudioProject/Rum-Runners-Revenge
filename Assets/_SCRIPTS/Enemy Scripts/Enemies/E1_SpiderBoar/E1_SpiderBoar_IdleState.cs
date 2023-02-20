using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_SpiderBoar_IdleState : Enemy_IdleState
{
    private E1_SpiderBoar _enemySpiderBoar;
    
    public E1_SpiderBoar_IdleState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyIdleState _enemyStateData, E1_SpiderBoar _enemySpiderBoar) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyStateData)
    {
        this._enemySpiderBoar = _enemySpiderBoar;
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
        else if (_isEnemyIdleTimeOver)
        {
            _enemyStateMachine.ChangeEnemyState(_enemySpiderBoar.spiderBoar_MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
