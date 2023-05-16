using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MeleeAttackState : Enemy_AttackState
{
    public Enemy_MeleeAttackState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, Transform enemyAttackPosition) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData, enemyAttackPosition)
    {
        
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

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(_enemyAttackPosition.position, _enemyData.enemyAttackRadius, _enemyData.whatIsPlayer);

        foreach (Collider2D collider in detectedObjects)
        {
            DamageInterface damageable = collider.GetComponent<DamageInterface>();

            if (damageable != null)
            {
                damageable.Damage(_enemyData.enemyAttackDamage);
                
            }

            KnockBackInterface knockbackable = collider.GetComponent<KnockBackInterface>();

            if (knockbackable != null)
            {
                knockbackable.KnockBack(_enemyData.knockBackAngle, _enemyData.knockBackStrength, coreMovement.EntityFacingDirection);
            }
        }
    }

    public override void EnemyFinishAttack()
    {
        base.EnemyFinishAttack();
    }
}
