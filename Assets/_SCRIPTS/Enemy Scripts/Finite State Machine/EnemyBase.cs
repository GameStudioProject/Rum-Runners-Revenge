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
    
    public int EnemyFacingDirection { get; private set; }
    
    public Rigidbody2D EnemyRB { get; private set; }
    public Animator EnemyAnimator { get; private set; }
    public GameObject EnemyAliveGO { get; private set; }
    public EnemyAnimationToStateMachine EnemyAnimationToStateMachine { get; private set; }
    
    public int LastDamageDirection { get; private set; }

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

    public virtual void Start()
    {
        EnemyFacingDirection = 1;
        _enemyCurrentHealth = enemyData.maxHealth;
        _enemyCurrentStunResistance = enemyData.enemyStunResistance;
        
        EnemyAliveGO = transform.Find("Alive").gameObject;
        EnemyRB = EnemyAliveGO.GetComponent<Rigidbody2D>();
        EnemyAnimator = EnemyAliveGO.GetComponent<Animator>();
        EnemyAnimationToStateMachine = EnemyAliveGO.GetComponent<EnemyAnimationToStateMachine>();

        EnemyStateMachine = new EnemyFiniteStateMachine();
    }

    public virtual void Update()
    {
        EnemyStateMachine.CurrentEnemyState.EveryFrameUpdate();
        
        EnemyAnimator.SetFloat("yVelocity", EnemyRB.velocity.y);

        if (Time.time >= _lastDamageTime + enemyData.enemyStunRecoveryTime)
        {
            ResetEnemyStunResistance();
        }
    }

    public virtual void FixedUpdate()
    {
        EnemyStateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        _velocityWorkspace.Set(EnemyFacingDirection * velocity, EnemyRB.velocity.y);
        EnemyRB.velocity = _velocityWorkspace;
    }

    public virtual void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        _velocityWorkspace.Set(angle.x * velocity * direction, angle.y * velocity);
        EnemyRB.velocity = _velocityWorkspace;
    }

    public virtual bool EnemyCheckWall()
    {
        return Physics2D.Raycast(_enemyWallCheck.position, EnemyAliveGO.transform.right, enemyData.wallCheckDistance, enemyData.whatIsGround);
    }

    public virtual bool EnemyCheckLedge()
    {
        return Physics2D.Raycast(_enemyLedgeCheck.position, Vector2.down, enemyData.ledgeCheckDistance, enemyData.whatIsGround);
    }

    public virtual bool EnemyCheckGround()
    {
        return Physics2D.OverlapCircle(_enemyGroundCheck.position, enemyData.groundCheckRadius, enemyData.whatIsGround);
    }

    public virtual bool EnemyCheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(_enemyPlayerCheck.position, EnemyAliveGO.transform.right, enemyData.enemyMinAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool EnemyCheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(_enemyPlayerCheck.position, EnemyAliveGO.transform.right, enemyData.enemyMaxAgroDistance, enemyData.whatIsPlayer);
    }

    public virtual bool EnemyCheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(_enemyPlayerCheck.position, EnemyAliveGO.transform.right, enemyData.enemyCloseRangeActionDistance, enemyData.whatIsPlayer);
    }

    public virtual void EnemyDamageHop(float velocity)
    {
        _velocityWorkspace.Set(EnemyRB.velocity.x, velocity);
        EnemyRB.velocity = _velocityWorkspace;
    }

    public virtual void ResetEnemyStunResistance()
    {
        _isEnemyStunned = false;
        _enemyCurrentStunResistance = enemyData.enemyStunResistance;
    }

    public virtual void Damage(AttackDetails attackDetails)
    {
        _lastDamageTime = Time.time;
        
        _enemyCurrentHealth -= attackDetails.damageAmount;
        _enemyCurrentStunResistance -= attackDetails.stunDamageAmount;
        
        EnemyDamageHop(enemyData.enemyDamageHopSpeed);

        Instantiate(enemyData._enemyHitParticle, EnemyAliveGO.transform.position,
            Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        if (attackDetails.position.x > EnemyAliveGO.transform.position.x)
        {
            LastDamageDirection = -1;
        }
        else
        {
            LastDamageDirection = 1;
        }

        if (_enemyCurrentStunResistance <= 0)
        {
            _isEnemyStunned = true;
        }

        if (_enemyCurrentHealth <= 0)
        {
            _isEnemyDead = true;
        }
    }

    public virtual void EnemyFlip()
    {
        EnemyFacingDirection *= -1;
        EnemyAliveGO.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void OnDrawGizmos()
    { 
        Gizmos.DrawLine(_enemyWallCheck.position, _enemyWallCheck.position + (Vector3)(Vector2.right * EnemyFacingDirection * enemyData.wallCheckDistance));
        Gizmos.DrawLine(_enemyLedgeCheck.position, _enemyLedgeCheck.position + (Vector3)(Vector2.down * enemyData.ledgeCheckDistance));
        
        Gizmos.DrawWireSphere(_enemyPlayerCheck.position + (Vector3)(Vector2.right * EnemyFacingDirection * enemyData.enemyCloseRangeActionDistance), 0.2f);
        Gizmos.DrawWireSphere(_enemyPlayerCheck.position + (Vector3)(Vector2.right * EnemyFacingDirection * enemyData.enemyMinAgroDistance), 0.2f);
        Gizmos.DrawWireSphere(_enemyPlayerCheck.position + (Vector3)(Vector2.right * EnemyFacingDirection *enemyData.enemyMaxAgroDistance), 0.2f);
    }
}
