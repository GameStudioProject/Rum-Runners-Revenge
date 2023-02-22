using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool CanPlayerDash { get; private set; }
    private bool _isPlayerHolding;
    private bool _playerDashInputStop;

    private float _lastPlayerDashTime;

    private Vector2 _playerDashDirection;
    private Vector2 _playerDashDirectionInput;
    private Vector2 _lastAfterImagePosition;
    
    public PlayerDashState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
    }

    public override void StateEnter()
    {
        base.StateEnter();
        
        CanPlayerDash = false;
        _player.PlayerInputHandler.PlayerUsedDashInput();

        _isPlayerHolding = true;
        _playerDashDirection = Vector2.right * MovementComponent.EntityFacingDirection;

        Time.timeScale = _playerData.slowMotionTimeScale; //slowmotion
        stateStartTime = Time.unscaledTime; //constant time so the slowmotion scaleTime has no effect on countdown
        
        _player.PlayerDashDirectionIndicator.gameObject.SetActive(true);
    }

    public override void StateExit()
    {
        base.StateExit();

        if (MovementComponent.EntityCurrentVelocity.y > 0)
        {
            MovementComponent?.SetEntityVelocityY(MovementComponent.EntityCurrentVelocity.y * _playerData.playerDashHeightMultiplier);
        }
        
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();
        
        if (!_isExitingPlayerState)
        {
            _player.PlayerAnimator.SetFloat("yVelocity", MovementComponent.EntityCurrentVelocity.y);
            _player.PlayerAnimator.SetFloat("xVelocity", Mathf.Abs(MovementComponent.EntityCurrentVelocity.x));
            
            if (_isPlayerHolding)
            {
                _playerDashDirectionInput = _player.PlayerInputHandler.PlayerDashDirectionInput;
                _playerDashInputStop = _player.PlayerInputHandler.PlayerDashInputStop;

                if (_playerDashDirectionInput != Vector2.zero)
                {
                    _playerDashDirection = _playerDashDirectionInput;
                    _playerDashDirection.Normalize();
                }

                float angle = Vector2.SignedAngle(Vector2.right, _playerDashDirection);
                _player.PlayerDashDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 45f);

                if (_playerDashInputStop || Time.unscaledTime >= stateStartTime + _playerData.maxDashHoldTime)
                {
                    _isPlayerHolding = false;
                    Time.timeScale = 1f;
                    stateStartTime = Time.time;
                    MovementComponent?.CheckIfEntityShouldFlip(Mathf.RoundToInt(_playerDashDirection.x));
                    _player.PlayerRB.drag = _playerData.playerAirDrag;
                    MovementComponent?.SetEntityVelocity(_playerData.playerDashSpeed, _playerDashDirection);
                    _player.PlayerDashDirectionIndicator.gameObject.SetActive(false);
                    PlaceAfterImage();
                }
            }
            else
            {
                MovementComponent?.SetEntityVelocity(_playerData.playerDashSpeed, _playerDashDirection);
                CheckIfAfterImageIsNeeded();

                if (Time.time >= stateStartTime + _playerData.playerDashTime)
                {
                    _player.PlayerRB.drag = 0f;
                    _isPlayerAbilityDone = true;
                    _lastPlayerDashTime = Time.time;
                }
            }
        }
    }

    private void CheckIfAfterImageIsNeeded()
    {
        if (Vector2.Distance(_player.transform.position, _lastAfterImagePosition) >= _playerData.playerAfterImageDistance)
        {
            PlaceAfterImage();
        }
    }

    private void PlaceAfterImage()
    {
        PlayerAfterImagePool.Instance.GetFromPool();
        _lastAfterImagePosition = _player.transform.position;
    }
    
    public bool CheckIfPlayerCanDash()
    {
        return CanPlayerDash && Time.time >= _lastPlayerDashTime + _playerData.playerDashCooldown;
    }

    public void ResetPlayerDash()
    {
        CanPlayerDash = true;
    }

}
