using Unity.VisualScripting;
using UnityEngine;


public class PlayerStates
{
    protected Core _core;
    protected CoreAccessComponent<MovementComponent> movementComponent;
    protected CoreAccessComponent<CollisionSenses> collisionSenses;
    protected CoreAccessComponent<CoreKnockBackReceiver> combatComponent;
    protected CoreAccessComponent<DeathComponent> deathComponent;
    protected CoreAccessComponent<StatsComponent> statsComponent;
    protected CoreAccessComponent<ParticleManagerComponent> particleManagerComponent;
    
    protected PlayerBase _player;
    protected PlayerStateMachine _playerStateMachine;
    protected PlayerData _playerData;

    protected bool _isPlayerAnimationFinished;
    protected bool _isExitingPlayerState;

    protected float stateStartTime;

    private string _animationBoolName;

    public PlayerStates(PlayerBase player, PlayerStateMachine playerStateMachine, PlayerData playerData,
        string animationBoolName)
    {
        _player = player;
        _playerStateMachine = playerStateMachine;
        _playerData = playerData;
        _animationBoolName = animationBoolName;
        _core = player.Core;
        
        movementComponent = new CoreAccessComponent<MovementComponent>(_core);
        collisionSenses = new CoreAccessComponent<CollisionSenses>(_core);
        combatComponent = new CoreAccessComponent<CoreKnockBackReceiver>(_core);
        deathComponent = new CoreAccessComponent<DeathComponent>(_core);
        statsComponent = new CoreAccessComponent<StatsComponent>(_core);
        particleManagerComponent = new CoreAccessComponent<ParticleManagerComponent>(_core);
    }
    
    public virtual void PerformPlayerChecks() //check for ground etc etc
    {

    }

    public virtual void StateEnter()
    {
        PerformPlayerChecks();
        _player.PlayerAnimator.SetBool(_animationBoolName, true);
        stateStartTime = Time.time;
        //Debug.Log(_animationBoolName);
        //Debug.Log(_playerStateMachine.PlayerCurrentState);
        _isPlayerAnimationFinished = false;
        _isExitingPlayerState = false;
    }

    public virtual void StateExit()
    {
        _player.PlayerAnimator.SetBool(_animationBoolName, false);
        _isExitingPlayerState = true;
    }

    public virtual void EveryFrameUpdate() //unity Update();
    {

    }

    public virtual void PhysicsUpdate() //unity FixedUpdate();
    {
        PerformPlayerChecks();
    }

    

    public virtual void PlayerAnimationTrigger()
    {

    }

    public virtual void PlayerAnimationFinishTrigger() => _isPlayerAnimationFinished = true;
}