public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
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
        
        _core.MovementComponent.CheckIfPlayerShouldFlip(_xPlayerInput);
        
        _core.MovementComponent.SetPlayerVelocityX(_playerData.playerMovementSpeed * _xPlayerInput);

        if (!_isExitingPlayerState)
        {
            if (_xPlayerInput == 0)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerIdleState);
            }
            else if (_yPlayerInput == -1)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerCrouchMoveState);
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
