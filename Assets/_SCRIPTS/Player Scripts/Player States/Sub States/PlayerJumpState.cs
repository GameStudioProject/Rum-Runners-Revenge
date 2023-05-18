using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int _playerAmountOfJumpsLeft;

    public PlayerJumpState(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animationBoolName) : base(player, playerStateMachine, playerData, animationBoolName)
    {
        _playerAmountOfJumpsLeft = playerData.playerJumps;
    }

    public override void StateEnter()
    {
        base.StateEnter();
        
        _player.PlayerInputHandler.PlayerUsedJumpInput();

        if (inWater())
        {
            _playerData.playerJumpVelocity = 20f;
        }
        else
        {
            _playerData.playerJumpVelocity = _playerData.playerJumpVelocity;
        }
        
        GameObject.Find("Jump Audio").GetComponent<AudioSource>().Play();
        _player.CoreMovement.SetEntityVelocityY(_playerData.playerJumpVelocity);
        _isPlayerAbilityDone = true;
        _playerAmountOfJumpsLeft--;
        _player.PlayerInAirState.SetPlayerJump();
    }

    public bool CanPlayerJump()
    {
        if (_playerAmountOfJumpsLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetPlayerJumps() => _playerAmountOfJumpsLeft = _playerData.playerJumps;

    public void DecreasePlayerJumps() => _playerAmountOfJumpsLeft--;

    private bool inWater()
    {
        return _player.CoreCollisionSenses.CheckIfEntityUnderWater;
    }
}        
    
