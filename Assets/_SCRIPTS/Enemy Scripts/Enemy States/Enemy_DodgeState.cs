using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DodgeState : Enemy_GroundedState
{
    protected bool _isEnemyDodgeOver;


    public Enemy_DodgeState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
    {
    }

    public override void StateEnter()
    {
        base.StateEnter();

        _isEnemyDodgeOver = false;

        if (coreCollisionSenses.CheckEntityDodgeLandZone)
        {
            coreMovement.SetEntityVelocity(_enemyData.enemyDodgeSpeed, _enemyData.enemyDodgeAngle, -coreMovement.EntityFacingDirection);
        }
        else
        {
            coreMovement.SetEntityVelocity(_enemyData.enemyDodgeSpeed * _enemyData.enemyDodgeSpeedMultiplier, _enemyData.enemyDodgeAngle, coreMovement.EntityFacingDirection);
        }
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (Time.time >= _stateStartTime + _enemyData.enemyDodgeTime && _isEnemyGrounded)
        {
            _isEnemyDodgeOver = true;
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
