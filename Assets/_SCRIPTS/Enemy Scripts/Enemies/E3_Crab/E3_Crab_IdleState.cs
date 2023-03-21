using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_Crab_IdleState : Enemy_IdleState
{
    private E3_Crab _enemyCrab;
    
    public E3_Crab_IdleState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyIdleState _enemyStateData, E3_Crab _enemyCrab) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyStateData)
    {
        this._enemyCrab = _enemyCrab;
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
        
        if (_isEnemyIdleTimeOver)
        {
            _enemyStateMachine.ChangeEnemyState(_enemyCrab.crab_MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
