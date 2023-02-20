using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class D_EnemyBase : ScriptableObject
{
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

    public GameObject _enemyHitParticle;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
