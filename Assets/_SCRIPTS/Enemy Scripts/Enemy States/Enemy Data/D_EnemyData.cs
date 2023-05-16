using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Enemy Data")]
public class D_EnemyData : ScriptableObject
{
    [Header("Enemy Base Data")]
    public float maxHealth = 30f;
    public float enemyDamageHopSpeed = 10f;
    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;
    public float groundCheckRadius = 0.3f;
    public float enemyMinAgroDistance = 3f;
    public float enemyMaxAgroDistance = 4f;
    public float enemyStunResistance = 3f;
    public float enemyStunRecoveryTime = 2f;
    public float enemyCloseRangeActionDistance = 1f;
    public GameObject enemyHitParticle;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
    
    [Header("Enemy Idle Data")]
    public float enemyMinIdleTime = 1f;
    public float enemyMaxIdleTime = 2f;
    
    [Header("Enemy Move Data")]
    public float enemyMovementSpeed = 3f;
    
    [Header("Enemy Dodge Data")]
    public float enemyDodgeSpeed = 10f;
    public float enemyDodgeSpeedMultiplier = 0.5f;
    public float enemyDodgeTime = 0.2f;
    public float enemyDodgeCooldown = 2f;
    public Vector2 enemyDodgeAngle;
    
    [Header("Enemy Charge Data")]
    public float enemyChargeSpeed = 6f;
    public float enemyChargeTime = 2f;
    
    [Header("Enemy Look For Player Data")]
    public int enemyTurns = 2;
    public float enemyTimeBetweenTurns = 0.75f;
    
    [Header("Enemy Player Detected Data")]
    public float enemyLongRangeActionTime = 1.5f;
    
    [Header("Enemy Ranged Attack Data")]
    public GameObject enemyProjectile;
    public float enemyProjectileDamage = 10f;
    public float enemyProjectileSpeed = 12f;
    public float enemyProjectileTravelDistance;
    
    [Header("Enemy Melee Attack Data")]
    public float enemyAttackRadius = 0.5f;
    public float enemyAttackDamage = 10f;
    public Vector2 knockBackAngle = Vector2.one;
    public float knockBackStrength = 10f;
    
    [Header("Enemy Stun Data")]
    public float enemyStunTime = 3f;
    public float enemyStunKnockBackTime = 0.3f;
    public float enemyStunKnockBackSpeed = 20f;
    public Vector2 enemyStunKnockBackAngle;
    
    [Header("enemy Dead Data")]
    public GameObject enemyDeathChunkParticle;
    public GameObject enemyDeathBloodParticle;
    
    
    
}
