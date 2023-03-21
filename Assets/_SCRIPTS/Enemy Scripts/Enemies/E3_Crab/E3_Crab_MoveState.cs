using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_Crab_MoveState : Enemy_MoveState
{
    private E3_Crab _enemyCrab;
    
    public E3_Crab_MoveState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyMoveState _enemyStateData, E3_Crab _enemyCrab) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyStateData)
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
        
        if (_isEnemyDetectingWall || !_isEnemyDetectingLedge)
        {
            _enemyCrab.crab_IdleState.SetEnemyFlipAfterIdle(true);
            _enemyStateMachine.ChangeEnemyState(_enemyCrab.crab_IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
