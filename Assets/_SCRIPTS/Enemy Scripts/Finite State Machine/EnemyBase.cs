using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBase : MonoBehaviour
{
    protected CoreAccessComponent<MovementComponent> movementComponent;
    protected CoreAccessComponent<CollisionSenses> collisionSenses;
    
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
        movementComponent = new CoreAccessComponent<MovementComponent>(Core);
        collisionSenses = new CoreAccessComponent<CollisionSenses>(Core);
        
        collisionSenses.Component.EnemyBase = this;
        
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
        
        EnemyAnimator.SetFloat("yVelocity", movementComponent.Component.Rigidbody.velocity.y);

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
            Gizmos.DrawLine(collisionSenses.Component.EntityWallCheck.position, collisionSenses.Component.EntityWallCheck.position + (Vector3)(Vector2.right * movementComponent.Component.EntityFacingDirection * enemyData.wallCheckDistance));
            Gizmos.DrawLine(collisionSenses.Component.EntityLedgeCheckVertical.position, collisionSenses.Component.EntityLedgeCheckVertical.position + (Vector3)(Vector2.down * enemyData.ledgeCheckDistance));
        
            Gizmos.DrawWireSphere(collisionSenses.Component.EntityPlayerCheck.position + (Vector3)(Vector2.right * movementComponent.Component.EntityFacingDirection * enemyData.enemyCloseRangeActionDistance), 0.2f);
            Gizmos.DrawWireSphere(collisionSenses.Component.EntityPlayerCheck.position + (Vector3)(Vector2.right * movementComponent.Component.EntityFacingDirection * enemyData.enemyMinAgroDistance), 0.2f);
            Gizmos.DrawWireSphere(collisionSenses.Component.EntityPlayerCheck.position + (Vector3)(Vector2.right * movementComponent.Component.EntityFacingDirection *enemyData.enemyMaxAgroDistance), 0.2f);
        }
        
    }
}
