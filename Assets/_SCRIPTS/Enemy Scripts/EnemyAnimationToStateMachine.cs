using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationToStateMachine : MonoBehaviour
{
    public Enemy_AttackState EnemyAttackState;
    
    private void EnemyTriggerAttack()
    {
        EnemyAttackState.EnemyTriggerAttack();
    }

    private void EnemyFinishAttack()
    {
        EnemyAttackState.EnemyFinishAttack();
    }
}
