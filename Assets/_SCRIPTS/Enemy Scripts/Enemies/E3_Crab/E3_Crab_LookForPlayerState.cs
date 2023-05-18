using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_Crab_LookForPlayerState : Enemy_LookForPlayerState
{
    private E3_Crab _enemyCrab;


    public E3_Crab_LookForPlayerState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, E3_Crab enemyCrab) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
    {
        _enemyCrab = enemyCrab;
    }

    public override void StateEnter()
    {
        base.StateEnter();

        Debug.Log("LookForPlayer");
        Debug.Log(_isPlayerInMinAgroRange);
       
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
            _enemyStateMachine.ChangeEnemyState(_enemyCrab.crab_PlayerDetectedState);
        }
        else if (_isAllEnemyTurnsTimeDone)
        {
            _enemyStateMachine.ChangeEnemyState(_enemyCrab.crab_MoveState);
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
