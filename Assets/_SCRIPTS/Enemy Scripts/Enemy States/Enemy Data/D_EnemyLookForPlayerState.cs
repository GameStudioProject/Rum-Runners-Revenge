using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newLookForPlayerStateData", menuName = "Data/State Data/Look For Player State Data")]
public class D_EnemyLookForPlayerState : ScriptableObject
{
    public int enemyTurns = 2;
    public float enemyTimeBetweenTurns = 0.75f;
}
