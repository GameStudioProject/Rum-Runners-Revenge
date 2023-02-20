using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMoveStateData", menuName = "Data/State Data/Idle State Data")]
public class D_EnemyIdleState : ScriptableObject
{
    public float enemyMinIdleTime = 1f;
    public float enemyMaxIdleTime = 2f;
}
