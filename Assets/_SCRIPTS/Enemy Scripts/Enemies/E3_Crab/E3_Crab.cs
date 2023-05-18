using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_Crab : EnemyBase
{
    public E3_Crab_IdleState crab_IdleState { get; private set; }
    public E3_Crab_MoveState crab_MoveState { get; private set; }
    public E3_Crab_PlayerDetectedState crab_PlayerDetectedState {get; private set; }
    public E3_Crab_LookForPlayerState crab_LookForPlayerState { get; private set; } 
    public E3_Crab_MeleeAttack crab_MeleeAttack { get; private set; }
    public E3_Crab_AttackState crab_AttackState { get; private set; }
    public E3_Crab_DeadState crab_DeadState { get; private set; }

    [SerializeField] private Transform _enemyAttackPosition;
    public GameObject player { get; private set; }
    public float attackRadius { get; private set; }

    public float grabRange { get; private set; }

    public override void Awake()
    {
        base.Awake();

        attackRadius = 5;

        grabRange = 3; // Set the desired grab range

        crab_IdleState = new E3_Crab_IdleState(this, EnemyStateMachine, "idle", enemyData, this);
        crab_MoveState = new E3_Crab_MoveState(this, EnemyStateMachine, "move", enemyData, this);
        crab_AttackState = new E3_Crab_AttackState(this, EnemyStateMachine,"attack", enemyData, _enemyAttackPosition ,this);
        crab_MeleeAttack = new E3_Crab_MeleeAttack(this, EnemyStateMachine, "attack1", enemyData, _enemyAttackPosition, this);
        crab_DeadState = new E3_Crab_DeadState(this, EnemyStateMachine, "dead", enemyData, this);
        crab_LookForPlayerState = new E3_Crab_LookForPlayerState(this, EnemyStateMachine, "lookForPlayer", enemyData, this);
        crab_PlayerDetectedState = new E3_Crab_PlayerDetectedState(this, EnemyStateMachine, "playerDetected", enemyData, this);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        EnemyStateMachine.InitializeState(crab_IdleState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }

    // New function to get the grab range
    public float GetGrabRange()
    {
        return grabRange;
    }
}
