using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_Cannon : EnemyBase
{
    public E4_Cannon_MoveState CannonMoveState { get; private set; }
    public E4_Cannon_IdleState CannonIdleState { get; private set; }
    public E4_Cannon_PlayerDetectedState CannonPlayerDetectedState { get; private set; }
    public E4_Cannon_LookForPlayerState CannonLookForPlayerState { get; private set; }
    public E4_Cannon_StunState CannonStunState { get; private set; }
    public E4_Cannon_DeadState CannonDeadState { get; private set; }
    public E4_Cannon_RangedAttackState CannonRangedAttackState { get; private set; }

    [SerializeField] private Transform _rangedAttackPosition;

    public override void Awake()
    {
        base.Awake();
        
        CannonMoveState = new E4_Cannon_MoveState(this, EnemyStateMachine, "move", enemyData, this);
        CannonIdleState = new E4_Cannon_IdleState(this, EnemyStateMachine, "idle", enemyData, this);
        CannonPlayerDetectedState = new E4_Cannon_PlayerDetectedState(this, EnemyStateMachine, "playerDetected", enemyData, this);
        CannonLookForPlayerState = new E4_Cannon_LookForPlayerState(this, EnemyStateMachine, "lookForPlayer", enemyData, this);
        CannonStunState = new E4_Cannon_StunState(this, EnemyStateMachine, "stun", enemyData, this);
        CannonDeadState = new E4_Cannon_DeadState(this, EnemyStateMachine, "dead", enemyData, this);
        CannonRangedAttackState = new E4_Cannon_RangedAttackState(this, EnemyStateMachine, "rangedAttack", enemyData, _rangedAttackPosition,this);
        
        CoreStats.EntityPoise.OnCurrentStatValueZero += HandleEnemyPoiseZero;
    }

    private void HandleEnemyPoiseZero()
    {
        EnemyStateMachine.ChangeEnemyState(CannonStunState);
    }

    private void Start()
    {
        EnemyStateMachine.InitializeState(CannonMoveState);
    }

    private void OnDestroy()
    {
        CoreStats.EntityPoise.OnCurrentStatValueZero -= HandleEnemyPoiseZero;
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}
