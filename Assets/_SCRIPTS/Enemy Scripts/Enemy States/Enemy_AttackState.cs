using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackState : EnemyStates
{
    

    protected Transform _enemyAttackPosition;

    protected bool _isEnemyAnimationFinished;
    protected bool _isPlayerInMinAgroRange;

    public Enemy_AttackState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, Transform _enemyAttackPosition) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName)
    {
        this._enemyAttackPosition = _enemyAttackPosition;
    }

    public override void StateEnter()
    {
        base.StateEnter();

        _enemyBase.EnemyAnimationToStateMachine.EnemyAttackState = this;
        _isEnemyAnimationFinished = false;
        coreMovement.SetEntityVelocityX(0f);
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        coreMovement.SetEntityVelocityX(0f);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoEnemyChecks()
    {
        base.DoEnemyChecks();

        _isPlayerInMinAgroRange = coreCollisionSenses.EnemyCheckPlayerInMinAgroRange();
    }

    public virtual void EnemyTriggerAttack()
    {
        
    }

    public virtual void EnemyFinishAttack()
    {
        _isEnemyAnimationFinished = true;
    }
}
