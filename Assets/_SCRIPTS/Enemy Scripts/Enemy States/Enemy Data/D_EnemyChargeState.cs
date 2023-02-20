using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newChargeStateData", menuName = "Data/State Data/Charge State Data")]
public class D_EnemyChargeState : ScriptableObject
{
    public float enemyChargeSpeed = 6f;

    public float enemyChargeTime = 2f;
}
