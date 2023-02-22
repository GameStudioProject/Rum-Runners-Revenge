using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBase : MonoBehaviour
{
    public EnemyFiniteStateMachine EnemyStateMachine;
    
    public D_EnemyBase enemyData;
    public Animator EnemyAnimator { get; private set; }
    public EnemyAnimationToStateMachine EnemyAnimationToStateMachine { get; private set; }
    
    public int LastDamageDirection { get; private set; }
    
    public Core Core { get; private set; }

    [SerializeField] private Transform _enemyWallCheck;
    [SerializeField] private Transform _enemyLedgeCheck;
    [SerializeField] private Transform _enemyPlayerCheck;
    [SerializeField] private Transform _enemyGroundCheck;

    private float _enemyCurrentHealth;
    private float _enemyCurrentStunResistance;
    private float _lastDamageTime;


    private Vector2 _velocityWorkspace;

    protected bool _isEnemyStunned;
    protected bool _isEnemyDead;

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
        
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
        
        EnemyAnimator.SetFloat("yVelocity", Core.MovementComponent.Rigidbody.velocity.y);

        if (Time.time >= _lastDamageTime + enemyData.enemyStunRecoveryTime)
        {
            ResetEnemyStunResistance();
        }
    }

    public virtual void FixedUpdate()
    {
        EnemyStateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public virtual bool EnemyCheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(_enemyPlayerCheck.position, transform.right, enemyData.enemyMinAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool EnemyCheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(_enemyPlayerCheck.position, transform.right, enemyData.enemyMaxAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool EnemyCheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(_enemyPlayerCheck.position, transform.right, enemyData.enemyCloseRangeActionDistance, enemyData.whatIsPlayer);
    }

    public virtual void EnemyDamageHop(float velocity)
    {
        _velocityWorkspace.Set(Core.MovementComponent.Rigidbody.velocity.x, velocity);
        Core.MovementComponent.Rigidbody.velocity = _velocityWorkspace;
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
            Gizmos.DrawLine(_enemyWallCheck.position, _enemyWallCheck.position + (Vector3)(Vector2.right * Core.MovementComponent.EntityFacingDirection * enemyData.wallCheckDistance));
            Gizmos.DrawLine(_enemyLedgeCheck.position, _enemyLedgeCheck.position + (Vector3)(Vector2.down * enemyData.ledgeCheckDistance));
        
            Gizmos.DrawWireSphere(_enemyPlayerCheck.position + (Vector3)(Vector2.right * Core.MovementComponent.EntityFacingDirection * enemyData.enemyCloseRangeActionDistance), 0.2f);
            Gizmos.DrawWireSphere(_enemyPlayerCheck.position + (Vector3)(Vector2.right * Core.MovementComponent.EntityFacingDirection * enemyData.enemyMinAgroDistance), 0.2f);
            Gizmos.DrawWireSphere(_enemyPlayerCheck.position + (Vector3)(Vector2.right * Core.MovementComponent.EntityFacingDirection *enemyData.enemyMaxAgroDistance), 0.2f);
        }
        
    }
}
