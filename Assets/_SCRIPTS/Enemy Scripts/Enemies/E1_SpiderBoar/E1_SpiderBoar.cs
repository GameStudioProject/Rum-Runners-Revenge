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

    [SerializeField] private D_EnemyIdleState _enemyIdleStateData;
    [SerializeField] private D_EnemyMoveState _enemyMoveStateData;
    [SerializeField] private D_EnemyPlayerDetectedState _enemyPlayerDetectedStateData;
    [SerializeField] private D_EnemyChargeState _enemyChargeStateData;
    [SerializeField] private D_EnemyLookForPlayerState _enemyLookForPlayerStateData;
    [SerializeField] private D_EnemyMeleeAttackState _enemyMeleeAttackStateData;
    [SerializeField] private D_EnemyStunState _enemyStunStateData;
    [SerializeField] private D_EnemyDeadState _enemyDeadStateData;

    [SerializeField] private Transform _enemyMeleeAttackPosition;

    public override void Awake()
    {
        base.Awake();

        spiderBoar_MoveState = new E1_SpiderBoar_MoveState(this, EnemyStateMachine, "move", _enemyMoveStateData, this);
        spiderBoar_IdleState = new E1_SpiderBoar_IdleState(this, EnemyStateMachine, "idle", _enemyIdleStateData, this);
        spiderBoar_PlayerDetectedState = new E1_SpiderBoar_PlayerDetectedState(this, EnemyStateMachine, "playerDetected", _enemyPlayerDetectedStateData, this);
        spiderBoar_ChargeState = new E1_SpiderBoar_ChargeState(this, EnemyStateMachine, "charge", _enemyChargeStateData, this);
        spiderBoar_LookForPlayerState = new E1_SpiderBoar_LookForPlayerState(this, EnemyStateMachine, "lookForPlayer", _enemyLookForPlayerStateData, this);
        spiderBoar_MeleeAttackState = new E1_SpiderBoar_MeleeAttackState(this, EnemyStateMachine, "meleeAttack", _enemyMeleeAttackPosition, _enemyMeleeAttackStateData, this);
        spiderBoar_StunState = new E1_SpiderBoar_StunState(this, EnemyStateMachine, "stun", _enemyStunStateData, this);
        spiderBoar_DeadState = new E1_SpiderBoar_DeadState(this, EnemyStateMachine, "dead", _enemyDeadStateData, this);
        
    }

    private void Start()
    {
        EnemyStateMachine.InitializeState(spiderBoar_MoveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        
        Gizmos.DrawWireSphere(_enemyMeleeAttackPosition.position, _enemyMeleeAttackStateData.enemyAttackRadius);
    }
}
