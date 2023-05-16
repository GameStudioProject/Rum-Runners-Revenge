using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DeadState : EnemyStates
{
    public Enemy_DeadState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
    {
    }

    public override void StateEnter()
    {
        base.StateEnter();

        GameObject.Instantiate(_enemyData.enemyDeathBloodParticle, _enemyBase.transform.position, _enemyData.enemyDeathBloodParticle.transform.rotation);
        GameObject.Instantiate(_enemyData.enemyDeathChunkParticle, _enemyBase.transform.position, _enemyData.enemyDeathChunkParticle.transform.rotation);
        
        _enemyBase.gameObject.SetActive(false);
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
