using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_StunState : EnemyStates
{
    protected D_EnemyStunState _enemyStunStateData;

    protected bool _isEnemyStunTimeOver;
    protected bool _isEnemyGrounded;
    protected bool _isEnemyMovementStopped;
    protected bool _performEnemyCloseRangeAction;
    protected bool _isPlayerInMinAgroRange;
    
    public Enemy_StunState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyStunState _enemyStunStateData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName)
    {
        this._enemyStunStateData = _enemyStunStateData;
    }

    public override void StateEnter()
    {
        base.StateEnter();

        _isEnemyStunTimeOver = false;
        _isEnemyMovementStopped = false;
        coreMovement.SetEntityVelocity(_enemyStunStateData.enemyStunKnockbackSpeed, _enemyStunStateData.enemyStunKnockbackAngle, _enemyBase.LastDamageDirection);
    }

    public override void StateExit()
    {
        base.StateExit();
        
        _enemyBase.ResetEnemyStunResistance();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (Time.time >= _stateStartTime + _enemyStunStateData.enemyStunTime)
        {
            _isEnemyStunTimeOver = true;
        }

        if (_isEnemyGrounded && Time.time >= _stateStartTime + _enemyStunStateData.enemyStunKnockbackTime && !_isEnemyMovementStopped)
        {
            _isEnemyMovementStopped = true;
            coreMovement.SetEntityVelocityX(0f);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoEnemyChecks()
    {
        base.DoEnemyChecks();

        if (coreCollisionSenses)
        {
            _isEnemyGrounded = coreCollisionSenses.CheckIfEntityGrounded;
            _performEnemyCloseRangeAction = coreCollisionSenses.EnemyCheckPlayerInCloseRangeAction();
            _isPlayerInMinAgroRange = coreCollisionSenses.EnemyCheckPlayerInMinAgroRange();
        }
    }
}
