using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_Archer : EnemyBase
{
    public E2_Archer_MoveState ArcherMoveState { get; private set; }
    public E2_Archer_IdleState ArcherIdleState { get; private set; }
    public E2_Archer_PlayerDetectedState ArcherPlayerDetectedState { get; private set; }
    public E2_Archer_MeleeAttack ArcherMeleeAttack { get; private set; }
    public E2_Archer_LookForPlayerState ArcherLookForPlayerState { get; private set; }
    public E2_Archer_StunState ArcherStunState { get; private set; }
    public E2_Archer_DeadState ArcherDeadState { get; private set; }
    public E2_Archer_DodgeState ArcherDodgeState { get; private set; }
    public E2_Archer_RangedAttackState ArcherRangedAttackState { get; private set; }
    

    [SerializeField] private Transform _meleeAttackPosition;
    [SerializeField] private Transform _rangedAttackPosition;

    public override void Awake()
    {
        base.Awake();
        
        ArcherMoveState = new E2_Archer_MoveState(this, EnemyStateMachine, "move", enemyData, this);
        ArcherIdleState = new E2_Archer_IdleState(this, EnemyStateMachine, "idle", enemyData, this);
        ArcherPlayerDetectedState = new E2_Archer_PlayerDetectedState(this, EnemyStateMachine, "playerDetected", enemyData, this);
        ArcherMeleeAttack = new E2_Archer_MeleeAttack(this, EnemyStateMachine, "meleeAttack", enemyData ,_meleeAttackPosition, this);
        ArcherLookForPlayerState = new E2_Archer_LookForPlayerState(this, EnemyStateMachine, "lookForPlayer", enemyData, this);
        ArcherStunState = new E2_Archer_StunState(this, EnemyStateMachine, "stun", enemyData, this);
        ArcherDeadState = new E2_Archer_DeadState(this, EnemyStateMachine, "dead", enemyData, this);
        ArcherDodgeState = new E2_Archer_DodgeState(this, EnemyStateMachine, "dodge", enemyData, this);
        ArcherRangedAttackState = new E2_Archer_RangedAttackState(this, EnemyStateMachine, "rangedAttack" ,enemyData, _rangedAttackPosition ,this);
        
        CoreStats.EntityPoise.OnCurrentStatValueZero += HandleEnemyPoiseZero;
    }

    private void HandleEnemyPoiseZero()
    {
        EnemyStateMachine.ChangeEnemyState(ArcherStunState);
    }

    private void Start()
    {
        EnemyStateMachine.InitializeState(ArcherMoveState);
    }

    private void OnDestroy()
    {
        CoreStats.EntityPoise.OnCurrentStatValueZero -= HandleEnemyPoiseZero;
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        
        Gizmos.DrawWireSphere(_meleeAttackPosition.position, enemyData.enemyAttackRadius);
    }
}
