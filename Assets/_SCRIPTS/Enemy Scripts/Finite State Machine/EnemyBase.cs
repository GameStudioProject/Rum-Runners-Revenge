using System;
using System.Collections;
using System.Collections.Generic;
using Tomas.Core;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(EnemyAnimationToStateMachine))]
public class EnemyBase : MonoBehaviour
{
    
    
    public EnemyFiniteStateMachine EnemyStateMachine;
    public D_EnemyData enemyData;
    public Animator EnemyAnimator { get; private set; }
    public EnemyAnimationToStateMachine EnemyAnimationToStateMachine { get; private set; }
    
    public int LastDamageDirection { get; private set; }
    
    public Core Core { get; private set; }

    private float _enemyCurrentHealth;
    private float _enemyCurrentStunResistance;
    private float _lastDamageTime;


    private Vector2 _velocityWorkspace;

    protected bool _isEnemyStunned;
    protected bool _isEnemyDead;

    protected StatsComponent coreStats;
    protected MovementComponent coreMovement;
    protected CollisionSenses coreCollisionSenses;

    public virtual void Awake()
    {
         Core = GetComponentInChildren<Core>();

         coreMovement = Core.GetCoreComponent<MovementComponent>();
         coreCollisionSenses = Core.GetCoreComponent<CollisionSenses>();
         coreStats = Core.GetCoreComponent<StatsComponent>();
         
        coreCollisionSenses.EnemyBase = this;
        
        _enemyCurrentHealth = enemyData.maxHealth;
        _enemyCurrentStunResistance = enemyData.enemyStunResistance;
        
        EnemyAnimator = GetComponent<Animator>();
        EnemyAnimationToStateMachine = GetComponent<EnemyAnimationToStateMachine>();

        EnemyStateMachine = new EnemyFiniteStateMachine();
    }

    public virtual void Update()
    {
        Core.EveryFrameUpdate();
        
        EnemyStateMachine.CurrentEnemyState.EveryFrameUpdate();
        
        EnemyAnimator.SetFloat("yVelocity", coreMovement.Rigidbody.velocity.y);

        if (Time.time >= _lastDamageTime + enemyData.enemyStunRecoveryTime)
        {
            ResetEnemyStunResistance();
        }
    }

    public virtual void FixedUpdate()
    {
        EnemyStateMachine.CurrentEnemyState.PhysicsUpdate();
    }
    
    public virtual void ResetEnemyStunResistance()
    {
        _isEnemyStunned = false;
        _enemyCurrentStunResistance = enemyData.enemyStunResistance;
    }

    public virtual void OnDrawGizmos()
    {
        if (Core != null)
        {
            Gizmos.DrawLine(coreCollisionSenses.EntityWallCheck.position, coreCollisionSenses.EntityWallCheck.position + (Vector3)(Vector2.right * coreMovement.EntityFacingDirection * enemyData.wallCheckDistance));
            Gizmos.DrawLine(coreCollisionSenses.EntityLedgeCheckVertical.position, coreCollisionSenses.EntityLedgeCheckVertical.position + (Vector3)(Vector2.down * enemyData.ledgeCheckDistance));
        
            Gizmos.DrawWireSphere(coreCollisionSenses.EntityPlayerCheck.position + (Vector3)(Vector2.right * coreMovement.EntityFacingDirection * enemyData.enemyCloseRangeActionDistance), 0.2f);
            Gizmos.DrawWireSphere(coreCollisionSenses.EntityPlayerCheck.position + (Vector3)(Vector2.right * coreMovement.EntityFacingDirection * enemyData.enemyMinAgroDistance), 0.2f);
            Gizmos.DrawWireSphere(coreCollisionSenses.EntityPlayerCheck.position + (Vector3)(Vector2.right * coreMovement.EntityFacingDirection *enemyData.enemyMaxAgroDistance), 0.2f);
        }
        
    }
    
}
