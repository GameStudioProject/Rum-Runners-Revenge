using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MeleeAttackState : Enemy_AttackState
{
    protected D_EnemyMeleeAttackState _enemyMeleeAttackStateData;

    public Enemy_MeleeAttackState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, Transform _enemyAttackPosition, D_EnemyMeleeAttackState _enemyMeleeAttackStateData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyAttackPosition)
    {
        this._enemyMeleeAttackStateData = _enemyMeleeAttackStateData;
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
            DamageInterface damageable = collider.GetComponent<DamageInterface>();

            if (damageable != null)
            {
                damageable.Damage(_enemyMeleeAttackStateData.enemyAttackDamage);
                
            }

            KnockBackInterface knockbackable = collider.GetComponent<KnockBackInterface>();

            if (knockbackable != null)
            {
                knockbackable.KnockBack(_enemyMeleeAttackStateData.knockbackAngle, _enemyMeleeAttackStateData.knockbackStrength, coreMovement.EntityFacingDirection);
            }
        }
    }

    public override void EnemyFinishAttack()
    {
        base.EnemyFinishAttack();
    }
}
