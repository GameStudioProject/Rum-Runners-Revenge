public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public override void StateEnter()
    {
        base.StateEnter();
        
        coreMovement.SetEntityVelocityX(0f);
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (!_isExitingPlayerState)
        {
            //player will stop running into wall
            if (_xPlayerInput == coreMovement.EntityFacingDirection && coreCollisionSenses.CheckIfEntityTouchesWall)
            {
                return;
            }
            
            if (_xPlayerInput != 0)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerMoveState);
            }
            else if (_yPlayerInput == -1)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerCrouchIdleState);
            }
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void PerformPlayerChecks()
    {
        base.PerformPlayerChecks();
    }
}
