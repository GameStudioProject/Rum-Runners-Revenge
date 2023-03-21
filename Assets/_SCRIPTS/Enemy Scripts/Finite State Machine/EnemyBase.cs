using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBase : MonoBehaviour
{
    protected MovementComponent MovementComponent
    {
        get => _movementComponent ??= Core.GetCoreComponent<MovementComponent>();
    }

    protected CollisionSenses CollisionSenses
    {
        get => _collisionSenses ??= Core.GetCoreComponent<CollisionSenses>();
    }

    private MovementComponent _movementComponent;
    private CollisionSenses _collisionSenses;
    
    public EnemyFiniteStateMachine EnemyStateMachine;
    
    public D_EnemyBase enemyData;
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

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
        CollisionSenses.EnemyBase = this;
        
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
        
        EnemyAnimator.SetFloat("yVelocity", MovementComponent.Rigidbody.velocity.y);

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
            Gizmos.DrawLine(CollisionSenses.EntityWallCheck.position, CollisionSenses.EntityWallCheck.position + (Vector3)(Vector2.right * MovementComponent?.EntityFacingDirection * enemyData.wallCheckDistance));
            Gizmos.DrawLine(CollisionSenses.EntityLedgeCheckVertical.position, CollisionSenses.EntityLedgeCheckVertical.position + (Vector3)(Vector2.down * enemyData.ledgeCheckDistance));
        
            Gizmos.DrawWireSphere(CollisionSenses.EntityPlayerCheck.position + (Vector3)(Vector2.right * MovementComponent?.EntityFacingDirection * enemyData.enemyCloseRangeActionDistance), 0.2f);
            Gizmos.DrawWireSphere(CollisionSenses.EntityPlayerCheck.position + (Vector3)(Vector2.right * MovementComponent?.EntityFacingDirection * enemyData.enemyMinAgroDistance), 0.2f);
            Gizmos.DrawWireSphere(CollisionSenses.EntityPlayerCheck.position + (Vector3)(Vector2.right * MovementComponent?.EntityFacingDirection *enemyData.enemyMaxAgroDistance), 0.2f);
        }
        
    }
}
