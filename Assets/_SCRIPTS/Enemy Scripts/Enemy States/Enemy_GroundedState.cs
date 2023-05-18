using UnityEngine;


public class Enemy_GroundedState : EnemyStates
{
    protected bool _isEnemyDetectingWall;
    protected bool _isEnemyDetectingLedge;
    protected bool _isPlayerInMinAgroRange;
    protected bool _isPlayerInMaxAgroRange;
    protected bool _performCloseRangeAction;
    protected bool _isEnemyGrounded;


    public Enemy_GroundedState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
    {
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

    public override void DoEnemyChecks()
    {
        base.DoEnemyChecks();
        
        if (_enemyBase.CoreCollisionSenses)
        {
           _isEnemyDetectingLedge = _enemyBase.CoreCollisionSenses.CheckIfEntityTouchesLedgeVertical;
           _isEnemyDetectingWall = _enemyBase.CoreCollisionSenses.CheckIfEntityTouchesWall;
           _isEnemyGrounded = _enemyBase.CoreCollisionSenses.CheckIfEntityGrounded;
        }
        
        _isPlayerInMinAgroRange = _enemyBase.CoreCollisionSenses.EnemyCheckPlayerInMinAgroRange();
        _performCloseRangeAction = _enemyBase.CoreCollisionSenses.EnemyCheckPlayerInCloseRangeAction();
        _isPlayerInMaxAgroRange = _enemyBase.CoreCollisionSenses.EnemyCheckPlayerInMaxAgroRange();
    }
}
