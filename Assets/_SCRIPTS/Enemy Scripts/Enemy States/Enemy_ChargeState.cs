using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_ChargeState : EnemyStates
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
    
    protected D_EnemyChargeState _enemyChargeStateData;

    protected bool _isPlayerInMinAgroRange;
    protected bool _isEnemyDetectingLedge;
    protected bool _isEnemyDetectingWall;
    protected bool _isEnemyChargeTimeOver;
    protected bool _performEnemyCloseRangeAction;
    
    public Enemy_ChargeState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyChargeState _enemyChargeStateData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName)
    {
        this._enemyChargeStateData = _enemyChargeStateData;
    }


    public override void StateEnter()
    {
        base.StateEnter();

        _isEnemyChargeTimeOver = false;
        MovementComponent?.SetEntityVelocityX(_enemyChargeStateData.enemyChargeSpeed * MovementComponent.EntityFacingDirection);
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        MovementComponent?.SetEntityVelocityX(_enemyChargeStateData.enemyChargeSpeed * MovementComponent.EntityFacingDirection);

        if (Time.time >= _stateStartTime + _enemyChargeStateData.enemyChargeTime)
        {
            _isEnemyChargeTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoEnemyChecks()
    {
        base.DoEnemyChecks();

        if (CollisionSenses)
        {
            _isEnemyDetectingLedge = CollisionSenses.CheckIfEntityTouchesLedgeVertical;
            _isEnemyDetectingWall = CollisionSenses.CheckIfEntityTouchesWall;
        }
        _isPlayerInMinAgroRange = _enemyBase.EnemyCheckPlayerInMinAgroRange();
        _performEnemyCloseRangeAction = _enemyBase.EnemyCheckPlayerInCloseRangeAction();
    }
}
