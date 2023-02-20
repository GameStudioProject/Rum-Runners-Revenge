using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_SpiderBoar_DeadState : Enemy_DeadState
{
    private E1_SpiderBoar _enemySpiderBoar;
    
    public E1_SpiderBoar_DeadState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyDeadState _enemyDeadStateData, E1_SpiderBoar _enemySpiderBoar) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyDeadStateData)
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
