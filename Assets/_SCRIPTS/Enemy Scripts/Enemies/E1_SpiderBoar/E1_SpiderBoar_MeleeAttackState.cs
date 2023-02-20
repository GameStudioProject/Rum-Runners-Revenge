using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_SpiderBoar_MeleeAttackState : Enemy_MeleeAttackState
{
    private E1_SpiderBoar _enemySpiderBoar;
    
    public E1_SpiderBoar_MeleeAttackState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, Transform _enemyAttackPosition, D_EnemyMeleeAttackState _enemyMeleeAttackStateData, E1_SpiderBoar _enemySpiderBoar) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyAttackPosition, _enemyMeleeAttackStateData)
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

        if (_isEnemyAnimationFinished)
        {
            if (_isPlayerInMinAgroRange)
            {
                _enemyStateMachine.ChangeEnemyState(_enemySpiderBoar.spiderBoar_PlayerDetectedState);
            }
            else
            {
                _enemyStateMachine.ChangeEnemyState(_enemySpiderBoar.spiderBoar_LookForPlayerState);
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

    public override void EnemyTriggerAttack()
    {
        base.EnemyTriggerAttack();
    }

    public override void EnemyFinishAttack()
    {
        base.EnemyFinishAttack();
    }
}
