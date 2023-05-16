using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RangedAttackState : Enemy_AttackState
{
    protected GameObject _enemyProjectile;
    protected Projectile _projectileScript;


    public Enemy_RangedAttackState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, Transform enemyAttackPosition) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData, enemyAttackPosition)
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

        _enemyProjectile = GameObject.Instantiate(_enemyData.enemyProjectile, _enemyAttackPosition.position, _enemyAttackPosition.rotation);
        _projectileScript = _enemyProjectile.GetComponent<Projectile>();
        _projectileScript.ShootProjectile(_enemyData.enemyProjectileSpeed, _enemyData.enemyProjectileTravelDistance, _enemyData.enemyProjectileDamage);
    }

    public override void EnemyFinishAttack()
    {
        base.EnemyFinishAttack();
    }
}
