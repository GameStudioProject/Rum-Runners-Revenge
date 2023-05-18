using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_Cannon_StunState : Enemy_StunState
{
    private E4_Cannon _cannon;


    public E4_Cannon_StunState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, E4_Cannon cannon) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
    {
        _cannon = cannon;
    }

    public override void StateEnter()
    {
        base.StateEnter();
        
        Debug.Log("Cannon stun state entered");
    }

    public override void StateExit()
    {
        base.StateExit();
        
        Debug.Log("cannon state exit");
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (_isEnemyStunTimeOver)
        {
            if (_isPlayerInMinAgroRange)
            {
                _enemyStateMachine.ChangeEnemyState(_cannon.CannonPlayerDetectedState);
            }
            else
            {
                _enemyStateMachine.ChangeEnemyState(_cannon.CannonLookForPlayerState);
            }
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
