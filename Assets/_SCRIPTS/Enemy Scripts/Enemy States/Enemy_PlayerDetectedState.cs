using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PlayerDetectedState : EnemyStates
{
    protected MovementComponent MovementComponent
    {
        get => _movementComponent ??= _core.GetCoreComponent<MovementComponent>();
    }
    protected CollisionSenses CollisionSenses
    {
        get => _collisionSenses ??= _core.GetCoreComponent<CollisionSenses>();
    }
    
    private MovementComponent _movementComponent;
    private CollisionSenses _collisionSenses;
    
    protected D_EnemyPlayerDetectedState _enemyStateData;

    protected bool _isPlayerInMinAgroRange;
    protected bool _isPlayerInMaxAgroRange;
    protected bool _performEnemyCloseRangeAction;
    protected bool _performEnemyLongRangeAction;
    protected bool _isEnemyDetectingLedge;
    
    public Enemy_PlayerDetectedState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyPlayerDetectedState _enemyStateData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName)
    {
        this._enemyStateData = _enemyStateData;
    }

    public override void StateEnter()
    {
        base.StateEnter();

        _performEnemyLongRangeAction = false;
        MovementComponent?.SetEntityVelocityX(0f);
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        MovementComponent?.SetEntityVelocityX(0f);

        if (Time.time >= _stateStartTime + _enemyStateData.enemyLongRangeActionTime)
        {
            _performEnemyLongRangeAction = true;
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
        _isPlayerInMaxAgroRange = _enemyBase.EnemyCheckPlayerInMaxAgroRange();
        if (CollisionSenses)
        {
            _isEnemyDetectingLedge = CollisionSenses.CheckIfEntityTouchesLedgeVertical;
        }

        _performEnemyCloseRangeAction = _enemyBase.EnemyCheckPlayerInCloseRangeAction();
    }
}
