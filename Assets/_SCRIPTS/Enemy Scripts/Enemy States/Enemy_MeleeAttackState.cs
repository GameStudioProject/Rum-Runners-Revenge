using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MeleeAttackState : Enemy_AttackState
{
    protected D_EnemyMeleeAttackState _enemyMeleeAttackStateData;

    protected AttackDetails _attackDetails;

    public Enemy_MeleeAttackState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, Transform _enemyAttackPosition, D_EnemyMeleeAttackState _enemyMeleeAttackStateData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyAttackPosition)
    {
        this._enemyMeleeAttackStateData = _enemyMeleeAttackStateData;
    }

    public override void StateEnter()
    {
        base.StateEnter();

        _attackDetails.damageAmount = _enemyMeleeAttackStateData.enemyAttackDamage;
        _attackDetails.position = _enemyBase.transform.position;
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

    public override void EnemyTriggerAttack()
    {
        base.EnemyTriggerAttack();

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(_enemyAttackPosition.position, _enemyMeleeAttackStateData.enemyAttackRadius, _enemyMeleeAttackStateData.whatIsPlayer);

        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.SendMessage("Damage", _attackDetails);
        }
    }

    public override void EnemyFinishAttack()
    {
        base.EnemyFinishAttack();
    }
}
