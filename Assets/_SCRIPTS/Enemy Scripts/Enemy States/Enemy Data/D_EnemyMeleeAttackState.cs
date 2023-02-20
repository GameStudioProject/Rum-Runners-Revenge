using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeAttackStateData", menuName = "Data/State Data/Melee Attack State Data")]
public class D_EnemyMeleeAttackState : ScriptableObject
{
    public float enemyAttackRadius = 0.5f;
    public float enemyAttackDamage = 10f;

    public LayerMask whatIsPlayer;
}
