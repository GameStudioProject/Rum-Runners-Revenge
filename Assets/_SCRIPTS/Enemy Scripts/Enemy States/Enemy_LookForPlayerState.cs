using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LookForPlayerState : Enemy_GroundedState
{
    protected bool _turnEnemyImmediately;
    protected bool _isAllEnemyTurnsDone;
    protected bool _isAllEnemyTurnsTimeDone;

    protected float _lastEnemyTurnTime;

    protected int _amountOfEnemyTurnsDone;


    public Enemy_LookForPlayerState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
    {
    }

    public override void StateEnter()
    {
        base.StateEnter();

        _isAllEnemyTurnsDone = false;
        _isAllEnemyTurnsTimeDone = false;

        _lastEnemyTurnTime = _stateStartTime;
        _amountOfEnemyTurnsDone = 0;
        
        _enemyBase.CoreMovement.SetEntityVelocityX(0f);
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        _enemyBase.CoreMovement.SetEntityVelocityX(0f);

        if (_turnEnemyImmediately)
        {
            _enemyBase.CoreMovement.EntityFlip();
            _lastEnemyTurnTime = Time.time;
            _amountOfEnemyTurnsDone++;
            _turnEnemyImmediately = false;
        }
        else if (Time.time >= _lastEnemyTurnTime + _enemyData.enemyTimeBetweenTurns && !_isAllEnemyTurnsDone)
        {
            _enemyBase.CoreMovement.EntityFlip();
            _lastEnemyTurnTime = Time.time;
            _amountOfEnemyTurnsDone++;
        }

        if (_amountOfEnemyTurnsDone >= _enemyData.enemyTurns)
        {
            _isAllEnemyTurnsDone = true;
        }

        if (Time.time >= _lastEnemyTurnTime + _enemyData.enemyTimeBetweenTurns && _isAllEnemyTurnsDone)
        {
            _isAllEnemyTurnsTimeDone = true;
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

    public void TurnEnemyImmediately(bool flip)
    {
        _turnEnemyImmediately = flip;
    }
}
