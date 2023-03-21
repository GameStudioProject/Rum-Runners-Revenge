using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_Crab : EnemyBase
{
    public E3_Crab_IdleState crab_IdleState { get; private set; }
    public E3_Crab_MoveState crab_MoveState { get; private set; }

    [SerializeField] private D_EnemyIdleState _enemyIdleStateData;
    [SerializeField] private D_EnemyMoveState _enemyMoveStateData;

    public override void Awake()
    {
        base.Awake();

        crab_IdleState = new E3_Crab_IdleState(this, EnemyStateMachine, "idle", _enemyIdleStateData, this);
        crab_MoveState = new E3_Crab_MoveState(this, EnemyStateMachine, "move", _enemyMoveStateData, this);
    }

    private void Start()
    {
        EnemyStateMachine.InitializeState(crab_MoveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}
