using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_Cannon_DeadState : Enemy_DeadState
{
    private E4_Cannon _cannon;


    public E4_Cannon_DeadState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, E4_Cannon cannon) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
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
