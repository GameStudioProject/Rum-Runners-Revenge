using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RangedAttackState : Enemy_AttackState
{
    protected D_RangedAttackState _enemyRangedAttackStateData;

    protected GameObject _enemyProjectile;
    protected Projectile _projectileScript;
    
    public Enemy_RangedAttackState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, Transform _enemyAttackPosition, D_RangedAttackState _enemyRangedAttackStateData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyAttackPosition)
    {
        this._enemyRangedAttackStateData = _enemyRangedAttackStateData;
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

        _enemyProjectile = GameObject.Instantiate(_enemyRangedAttackStateData.enemyProjectile, _enemyAttackPosition.position, _enemyAttackPosition.rotation);
        _projectileScript = _enemyProjectile.GetComponent<Projectile>();
        _projectileScript.ShootProjectile(_enemyRangedAttackStateData.enemyProjectileSpeed, _enemyRangedAttackStateData.enemyProjectileTravelDistance, _enemyRangedAttackStateData.enemyProjectileDamage);
    }

    public override void EnemyFinishAttack()
    {
        base.EnemyFinishAttack();
    }
}
