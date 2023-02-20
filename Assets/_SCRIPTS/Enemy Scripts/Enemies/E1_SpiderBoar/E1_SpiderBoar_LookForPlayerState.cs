using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_SpiderBoar_LookForPlayerState : Enemy_LookForPlayerState
{
    private E1_SpiderBoar _enemySpiderBoar;
    
    public E1_SpiderBoar_LookForPlayerState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyLookForPlayerState _enemyLookForPlayerStateData, E1_SpiderBoar _enemySpiderBoar) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyLookForPlayerStateData)
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
        else if (_isAllEnemyTurnsTimeDone)
        {
            _enemyStateMachine.ChangeEnemyState(_enemySpiderBoar.spiderBoar_MoveState);
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
