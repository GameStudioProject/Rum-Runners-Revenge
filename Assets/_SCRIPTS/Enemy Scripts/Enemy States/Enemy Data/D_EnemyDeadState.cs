using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDeadStateData", menuName = "Data/State Data/Dead State Data")]
public class D_EnemyDeadState : ScriptableObject
{
    public GameObject _enemyDeathChunkParticle;
    public GameObject _enemyDeathBloodParticle;
}
