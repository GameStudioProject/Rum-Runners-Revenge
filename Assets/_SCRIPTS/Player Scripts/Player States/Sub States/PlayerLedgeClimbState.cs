using UnityEngine;

public class PlayerLedgeClimbState : PlayerStates
{
    private Vector2 _playerDetectedPosition;
    private Vector2 _cornerPosition;
    private Vector2 _playerStartPosition;
    private Vector2 _playerStopPosition;

    private bool _isPlayerHanging;
    private bool _isPlayerClimbing;

    private int _playerXInput;
    private int _playerYInput;
    
    public PlayerLedgeClimbState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        
    }

    public void SetPlayerDetectedPosition(Vector2 position) => _playerDetectedPosition = position;
    
    public override void StateEnter()
    {
        base.StateEnter();
        
        _player.SetPlayerVelocityZero();
        _player.transform.position = _playerDetectedPosition;
        _cornerPosition = _player.FindCornerPosition();
        
        _playerStartPosition.Set(_cornerPosition.x - (_player.PlayerFacingDirection * _playerData.playerStartOffset.x), _cornerPosition.y - _playerData.playerStartOffset.y);
        _playerStopPosition.Set(_cornerPosition.x + (_player.PlayerFacingDirection * _playerData.playerStopOffset.x), _cornerPosition.y + _playerData.playerStopOffset.y);

        _player.transform.position = _playerStartPosition;
    }

    public override void StateExit()
    {
        base.StateExit();

        _isPlayerHanging = false;

        if (_isPlayerClimbing)
        {
            _player.transform.position = _playerStopPosition;
            _isPlayerClimbing = false;
        }
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        if (_isPlayerAnimationFinished)
        {
            _playerStateMachine.ChangePlayerState(_player.PlayerIdleState);
        }
        else
        {
            _playerXInput = _player.PlayerInputHandler.NormInputX;
            _playerYInput = _player.PlayerInputHandler.NormInputY;
        
            _player.SetPlayerVelocityZero();
            _player.transform.position = _playerStartPosition;

            if (_playerXInput == _player.PlayerFacingDirection && _isPlayerHanging && !_isPlayerClimbing)
            {
                _isPlayerClimbing = true;
                _player.PlayerAnimator.SetBool("climbLedge", true);
            
            }
            else if (_playerYInput == -1 && _isPlayerHanging && !_isPlayerClimbing)
            {
                _playerStateMachine.ChangePlayerState(_player.PlayerInAirState);
            }
        }

        
    }

    public override void PlayerAnimationTrigger()
    {
        base.PlayerAnimationTrigger();

        _isPlayerHanging = true;
    }

    public override void PlayerAnimationFinishTrigger()
    {
        base.PlayerAnimationFinishTrigger();
        
        _player.PlayerAnimator.SetBool("climbLedge", false);
    }
}
