using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiniteStateMachine
{
    public EnemyStates CurrentEnemyState { get; private set; }

    public void InitializeState(EnemyStates enemyStartingState)
    {
        CurrentEnemyState = enemyStartingState;
        CurrentEnemyState.StateEnter();
    }

    public void ChangeEnemyState(EnemyStates newEnemyState)
    {
        CurrentEnemyState.StateExit();
        CurrentEnemyState = newEnemyState;
        CurrentEnemyState.StateEnter();
    }
}
