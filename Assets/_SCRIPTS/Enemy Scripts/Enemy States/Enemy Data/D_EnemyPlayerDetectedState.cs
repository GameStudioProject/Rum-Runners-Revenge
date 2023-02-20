using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "newPlayerDetectedStateData", menuName = "Data/State Data/Player Detected State Data")]
public class D_EnemyPlayerDetectedState : ScriptableObject
{
    [FormerlySerializedAs("enemyActionTime")] public float enemyLongRangeActionTime = 1.5f;
}
