using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRangedAttackStateData", menuName = "Data/State Data/Ranged Attack State Data")]
public class D_RangedAttackState : ScriptableObject
{
    public GameObject enemyProjectile;
    public float enemyProjectileDamage = 10f;
    public float enemyProjectileSpeed = 12f;
    public float enemyProjectileTravelDistance;
}
