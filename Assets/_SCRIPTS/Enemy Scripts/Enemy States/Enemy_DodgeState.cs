using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DodgeState : EnemyStates
{
    protected D_EnemyDodgeState _enemyDodgeStateData;

    protected bool _performCloseRangeAction;
    protected bool _isPlayerInMaxAgroRange;
    protected bool _isEnemyGrounded;
    protected bool _isEnemyDodgeOver;
    
    public Enemy_DodgeState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyDodgeState _enemyDodgeStateData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName)
    {
        this._enemyDodgeStateData = _enemyDodgeStateData;
    }

    public override void StateEnter()
    {
        base.StateEnter();
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoEnemyChecks()
    {
        base.DoEnemyChecks();

        _performCloseRangeAction = _enemyBase.EnemyCheckPlayerInCloseRangeAction();
        _isPlayerInMaxAgroRange = _enemyBase.EnemyCheckPlayerInMaxAgroRange();
        
    }
}
