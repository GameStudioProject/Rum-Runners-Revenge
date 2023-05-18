using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_Crab_AttackState : Enemy_AttackState
{
    private E3_Crab _enemyCrab;

    private float distance;

    private StatsComponent statsComponent;


    public E3_Crab_AttackState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, Transform enemyAttackPosition, E3_Crab enemyCrab) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData, enemyAttackPosition)
    {
        _enemyCrab = enemyCrab;
    }

    public override void StateEnter()
    {
        base.StateEnter();

        statsComponent = GameObject.FindWithTag("Player").GetComponentInChildren<StatsComponent>();

       

        Debug.Log("HELLO FROM ATTACK STATE");
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        if (_enemyCrab.player)
        {
            distance = Vector2.Distance(_enemyCrab.transform.position, _enemyCrab.player.transform.position);

            if (distance >= 8)
            {
                _enemyStateMachine.ChangeEnemyState(_enemyCrab.crab_LookForPlayerState);
            }
            else if (distance <= 3)
            {
                _enemyStateMachine.ChangeEnemyState(_enemyCrab.crab_MeleeAttack);
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

        // Check for player in the attack area
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(_enemyCrab.transform.position, _enemyCrab.attackRadius);
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {

                Debug.Log("Enemy attacked!");

                DamageInterface damageable = hitCollider.GetComponent<DamageInterface>();

                damageable?.Damage(10);

            }
        }



    }


    public void Damage(float _damageAmount)
    {
        
    }
}

