using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_Archer_MoveState : Enemy_MoveState
{
    private E2_Archer _archer;
    
    public E2_Archer_MoveState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyMoveState _enemyStateData, E2_Archer _archer) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyStateData)
    {
        this._archer = _archer;
    }

    public override void StateEnter()
    {
        base.StateEnter();
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (_isPlayerInMinAgroRange)
        {
            _enemyStateMachine.ChangeEnemyState(_archer.ArcherPlayerDetectedState);
        }
        else if (_isEnemyDetectingWall || !_isEnemyDetectingLedge)
        {
            _archer.ArcherIdleState.SetEnemyFlipAfterIdle(true);
            _enemyStateMachine.ChangeEnemyState(_archer.ArcherIdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoEnemyChecks()
    {
        base.DoEnemyChecks();
    }
}
