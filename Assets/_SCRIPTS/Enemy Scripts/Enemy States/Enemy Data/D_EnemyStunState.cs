using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newStunStateData", menuName = "Data/State Data/Stun State Data")]
public class D_EnemyStunState : ScriptableObject
{
    public float enemyStunTime = 3f;

    public float enemyStunKnockbackTime = 0.3f;
    public float enemyStunKnockbackSpeed = 20f;
    public Vector2 enemyStunKnockbackAngle;
}
