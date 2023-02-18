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
        
        _player.CheckIfPlayerShouldFlip(_xPlayerInput);
        
        _player.SetPlayerVelocityX(_playerData.playerMovementSpeed * _xPlayerInput);

        if (_xPlayerInput == 0 && !_isExitingPlayerState)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerIdleState);
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
