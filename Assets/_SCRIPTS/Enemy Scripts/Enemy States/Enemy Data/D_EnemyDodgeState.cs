using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDodgeStateData", menuName = "Data/State Data/Dodge State Data")]
public class D_EnemyDodgeState : ScriptableObject
{
    public float enemyDodgeSpeed = 10f;
    public float enemyDodgeSpeedMultiplier = 0.5f;
    public float enemyDodgeTime = 0.2f;
    public float enemyDodgeCooldown = 2f;
    public Vector2 enemyDodgeAngle;
}
