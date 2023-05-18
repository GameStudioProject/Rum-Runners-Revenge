using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_Crab_MeleeAttack : Enemy_MeleeAttackState
{
    private E3_Crab _enemyCrab;

    private float _throwForce = 10f;

    float distanceToPlayer;


    public E3_Crab_MeleeAttack(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, Transform enemyAttackPosition, E3_Crab enemyCrab) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData, enemyAttackPosition)
    {
        _enemyCrab = enemyCrab;
    }

    public override void StateEnter()
    {
        base.StateEnter();

        Debug.Log("MELLEATTACK");
     
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        //if (_isPlayerInMinAgroRange)
        //{
        //    _enemyStateMachine.ChangeEnemyState(_enemyCrab.crab_PlayerDetectedState);
        //}
        //else
        //{
        //    _enemyStateMachine.ChangeEnemyState(_enemyCrab.crab_LookForPlayerState);
        //}
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

        if (_enemyCrab.player) 
        {
            
            distanceToPlayer = Vector2.Distance(_enemyBase.transform.position, _enemyCrab.player.transform.position);

            if (distanceToPlayer <= _enemyCrab.GetGrabRange())
            {
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(_enemyCrab.transform.position, _enemyCrab.attackRadius);
                foreach (Collider2D hitCollider in hitColliders)
                {
                    if (hitCollider.CompareTag("Player"))
                    {

                        

                        DamageInterface damageable = hitCollider.GetComponent<DamageInterface>();

                        damageable?.Damage(10);

                    }
                }
                GrabPlayer();

            } else
            {
                _enemyStateMachine.ChangeEnemyState(_enemyCrab.crab_AttackState);
            }
        } 
    }

    private void GrabPlayer()
    {

        Vector2 throwDirection = (_enemyCrab.player.transform.position - _enemyBase.transform.position).normalized;
        Vector2 launchDirection = new Vector2(throwDirection.x * 2f, throwDirection.y + 0.7f);

        Rigidbody2D playerRigidbody = _enemyCrab.player.GetComponent<Rigidbody2D>();
        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.AddForce(launchDirection * _throwForce, ForceMode2D.Impulse);
    }
}
