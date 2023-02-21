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

    [SerializeField] private D_EnemyMoveState _archerMoveStateData;
    [SerializeField] private D_EnemyIdleState _archerIdleStateData;
    [SerializeField] private D_EnemyPlayerDetectedState _archerPlayerDetectedStateData;
    [SerializeField] private D_EnemyMeleeAttackState _archerMeleeAttackStateData;
    [SerializeField] private D_EnemyLookForPlayerState _archerLookForPlayerStateData;
    [SerializeField] private D_EnemyStunState _archerStunStateData;
    [SerializeField] private D_EnemyDeadState _archerDeadStateData;
    [SerializeField] public D_EnemyDodgeState _archerDodgeStateData;
    [SerializeField] private D_RangedAttackState _archerRangedAttackStateData;

    [SerializeField] private Transform _meleeAttackPosition;
    [SerializeField] private Transform _rangedAttackPosition;

    public override void Start()
    {
        base.Start();
        
        ArcherMoveState = new E2_Archer_MoveState(this, EnemyStateMachine, "move", _archerMoveStateData, this);
        ArcherIdleState = new E2_Archer_IdleState(this, EnemyStateMachine, "idle", _archerIdleStateData, this);
        ArcherPlayerDetectedState = new E2_Archer_PlayerDetectedState(this, EnemyStateMachine, "playerDetected", _archerPlayerDetectedStateData, this);
        ArcherMeleeAttack = new E2_Archer_MeleeAttack(this, EnemyStateMachine, "meleeAttack", _meleeAttackPosition, _archerMeleeAttackStateData, this);
        ArcherLookForPlayerState = new E2_Archer_LookForPlayerState(this, EnemyStateMachine, "lookForPlayer", _archerLookForPlayerStateData, this);
        ArcherStunState = new E2_Archer_StunState(this, EnemyStateMachine, "stun", _archerStunStateData, this);
        ArcherDeadState = new E2_Archer_DeadState(this, EnemyStateMachine, "dead", _archerDeadStateData, this);
        ArcherDodgeState = new E2_Archer_DodgeState(this, EnemyStateMachine, "dodge", _archerDodgeStateData, this);
        ArcherRangedAttackState = new E2_Archer_RangedAttackState(this, EnemyStateMachine, "rangedAttack",_rangedAttackPosition, _archerRangedAttackStateData, this);

        EnemyStateMachine.InitializeState(ArcherMoveState);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if (_isEnemyDead)
        {
            EnemyStateMachine.ChangeEnemyState(ArcherDeadState);
        }
        else if (_isEnemyStunned && EnemyStateMachine.CurrentEnemyState != ArcherStunState)
        {
            EnemyStateMachine.ChangeEnemyState(ArcherStunState);
        }
        else if (EnemyCheckPlayerInMinAgroRange())
        {
            EnemyStateMachine.ChangeEnemyState(ArcherRangedAttackState);
        }
        else if (!EnemyCheckPlayerInMinAgroRange())
        {
            ArcherLookForPlayerState.TurnEnemyImmediately(true);
            EnemyStateMachine.ChangeEnemyState(ArcherLookForPlayerState);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        
        Gizmos.DrawWireSphere(_meleeAttackPosition.position, _archerMeleeAttackStateData.enemyAttackRadius);
    }
}
