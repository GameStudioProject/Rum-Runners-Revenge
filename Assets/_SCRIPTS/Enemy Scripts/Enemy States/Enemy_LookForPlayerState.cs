using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LookForPlayerState : EnemyStates
{
    protected D_EnemyLookForPlayerState _enemyLookForPlayerStateData;

    protected bool _turnEnemyImmediately;
    protected bool _isPlayerInMinAgroRange;
    protected bool _isAllEnemyTurnsDone;
    protected bool _isAllEnemyTurnsTimeDone;

    protected float _lastEnemyTurnTime;

    protected int _amountOfEnemyTurnsDone;
    
    public Enemy_LookForPlayerState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyLookForPlayerState _enemyLookForPlayerStateData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName)
    {
        this._enemyLookForPlayerStateData = _enemyLookForPlayerStateData;
    }

    public override void StateEnter()
    {
        base.StateEnter();

        _isAllEnemyTurnsDone = false;
        _isAllEnemyTurnsTimeDone = false;

        _lastEnemyTurnTime = _stateStartTime;
        _amountOfEnemyTurnsDone = 0;
        
        _core.MovementComponent.SetEntityVelocityX(0f);
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        _core.MovementComponent.SetEntityVelocityX(0f);

        if (_turnEnemyImmediately)
        {
            _core.MovementComponent.EntityFlip();
            _lastEnemyTurnTime = Time.time;
            _amountOfEnemyTurnsDone++;
            _turnEnemyImmediately = false;
        }
        else if (Time.time >= _lastEnemyTurnTime + _enemyLookForPlayerStateData.enemyTimeBetweenTurns && !_isAllEnemyTurnsDone)
        {
            _core.MovementComponent.EntityFlip();
            _lastEnemyTurnTime = Time.time;
            _amountOfEnemyTurnsDone++;
        }

        if (_amountOfEnemyTurnsDone >= _enemyLookForPlayerStateData.enemyTurns)
        {
            _isAllEnemyTurnsDone = true;
        }

        if (Time.time >= _lastEnemyTurnTime + _enemyLookForPlayerStateData.enemyTimeBetweenTurns && _isAllEnemyTurnsDone)
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

        _isPlayerInMinAgroRange = _enemyBase.EnemyCheckPlayerInMinAgroRange();
    }

    public void TurnEnemyImmediately(bool flip)
    {
        _turnEnemyImmediately = flip;
    }
}
