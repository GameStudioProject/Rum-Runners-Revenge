using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_SpiderBoar : EnemyBase
{
    public E1_SpiderBoar_IdleState spiderBoar_IdleState { get; private set; }
    public E1_SpiderBoar_MoveState spiderBoar_MoveState { get; private set; }
    public E1_SpiderBoar_PlayerDetectedState spiderBoar_PlayerDetectedState { get; private set; }
    public E1_SpiderBoar_ChargeState spiderBoar_ChargeState { get; private set; }
    public E1_SpiderBoar_LookForPlayerState spiderBoar_LookForPlayerState { get; private set; }
    public E1_SpiderBoar_MeleeAttackState spiderBoar_MeleeAttackState { get; private set; }
    public E1_SpiderBoar_StunState spiderBoar_StunState { get; private set; }
    public E1_SpiderBoar_DeadState spiderBoar_DeadState { get; private set; }
    

    [SerializeField] private Transform _enemyMeleeAttackPosition;

    public override void Awake()
    {
        base.Awake();

        spiderBoar_MoveState = new E1_SpiderBoar_MoveState(this, EnemyStateMachine, "move", enemyData, this);
        spiderBoar_IdleState = new E1_SpiderBoar_IdleState(this, EnemyStateMachine, "idle", enemyData, this);
        spiderBoar_PlayerDetectedState = new E1_SpiderBoar_PlayerDetectedState(this, EnemyStateMachine, "playerDetected", enemyData, this);
        spiderBoar_ChargeState = new E1_SpiderBoar_ChargeState(this, EnemyStateMachine, "charge", enemyData, this);
        spiderBoar_LookForPlayerState = new E1_SpiderBoar_LookForPlayerState(this, EnemyStateMachine, "lookForPlayer", enemyData, this);
        spiderBoar_MeleeAttackState = new E1_SpiderBoar_MeleeAttackState(this, EnemyStateMachine, "meleeAttack", enemyData, _enemyMeleeAttackPosition, this);
        spiderBoar_StunState = new E1_SpiderBoar_StunState(this, EnemyStateMachine, "stun", enemyData, this);
        spiderBoar_DeadState = new E1_SpiderBoar_DeadState(this, EnemyStateMachine, "dead", enemyData, this);

        coreStats.EntityPoise.OnCurrentStatValueZero += HandleEnemyPoiseZero;
    }

    private void HandleEnemyPoiseZero()
    {
        EnemyStateMachine.ChangeEnemyState(spiderBoar_StunState);
    }

    private void Start()
    {
        EnemyStateMachine.InitializeState(spiderBoar_MoveState);
    }

    private void OnDestroy()
    {
        coreStats.EntityPoise.OnCurrentStatValueZero -= HandleEnemyPoiseZero;
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        
        Gizmos.DrawWireSphere(_enemyMeleeAttackPosition.position, enemyData.enemyAttackRadius);
    }
}
