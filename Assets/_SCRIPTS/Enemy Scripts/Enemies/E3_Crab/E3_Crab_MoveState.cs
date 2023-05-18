using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_Crab_MoveState : Enemy_MoveState
{
    private E3_Crab _enemyCrab;
    private float distance;


    public E3_Crab_MoveState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, E3_Crab enemyCrab) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
    {
        _enemyCrab = enemyCrab;
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
        if (_enemyCrab.player)
        {
            distance = Vector2.Distance(_enemyCrab.transform.position, _enemyCrab.player.transform.position);
        }
        if (distance <= 5)
        {
            _enemyStateMachine.ChangeEnemyState(_enemyCrab.crab_PlayerDetectedState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
