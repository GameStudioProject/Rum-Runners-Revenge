using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DeadState : EnemyStates
{
    protected D_EnemyDeadState _enemyDeadStateData;

    public Enemy_DeadState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyDeadState _enemyDeadStateData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName)
    {
        this._enemyDeadStateData = _enemyDeadStateData;
    }

    public override void StateEnter()
    {
        base.StateEnter();

        GameObject.Instantiate(_enemyDeadStateData._enemyDeathBloodParticle, _enemyBase.transform.position, _enemyDeadStateData._enemyDeathBloodParticle.transform.rotation);
        GameObject.Instantiate(_enemyDeadStateData._enemyDeathChunkParticle, _enemyBase.transform.position, _enemyDeadStateData._enemyDeathChunkParticle.transform.rotation);
        
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
