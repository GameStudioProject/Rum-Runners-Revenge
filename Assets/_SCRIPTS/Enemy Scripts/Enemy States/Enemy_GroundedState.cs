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
        
        if (coreCollisionSenses)
        {
           _isEnemyDetectingLedge = coreCollisionSenses.CheckIfEntityTouchesLedgeVertical;
           _isEnemyDetectingWall = coreCollisionSenses.CheckIfEntityTouchesWall;
           _isEnemyGrounded = coreCollisionSenses.CheckIfEntityGrounded;
        }
        
        _isPlayerInMinAgroRange = coreCollisionSenses.EnemyCheckPlayerInMinAgroRange();
        _performCloseRangeAction = coreCollisionSenses.EnemyCheckPlayerInCloseRangeAction();
        _isPlayerInMaxAgroRange = coreCollisionSenses.EnemyCheckPlayerInMaxAgroRange();
    }
}
