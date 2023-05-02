using System;
using Tomas.Weapons;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBase : MonoBehaviour 
{
    #region Player State Variables
    public PlayerStateMachine PlayerStateMachine { get; private set; }
    
    public PlayerIdleState PlayerIdleState { get; private set; }
    public PlayerMoveState PlayerMoveState { get; private set; }
    public PlayerJumpState PlayerJumpState { get; private set; }
    public PlayerInAirState PlayerInAirState { get; private set; }
    public PlayerLandState PlayerLandState { get; private set; }
    public PlayerWallSlideState PlayerWallSlideState { get; private set; }
    public PlayerWallGrabState PlayerWallGrabState { get; private set; }
    public PlayerWallClimbState PlayerWallClimbState { get; private set; }
    public PlayerWallJumpState PlayerWallJumpState { get; private set; }
    public PlayerLedgeClimbState PlayerLedgeClimbState { get; private set; }
    public PlayerDashState PlayerDashState { get; private set; }
    public PlayerCrouchIdleState PlayerCrouchIdleState { get; private set; }
    public PlayerCrouchMoveState PlayerCrouchMoveState { get; private set; }
    public PlayerAttackState PlayerPrimaryAttackState { get; private set; }
    public PlayerAttackState PlayerSecondaryAttackState { get; private set; }
    public PlayerGrappleHookState PlayerGrappleHookState { get; private set; }
    
    
    [SerializeField] private PlayerData _playerData;
    #endregion

    #region Components

    public Core Core { get; private set; }
    
    private StatsComponent StatsComponent
    {
        get => _statsComponent ??= Core.GetCoreComponent<StatsComponent>();
    }
    private StatsComponent _statsComponent;
    public Animator PlayerAnimator { get; private set; }
    public PlayerInputHandler PlayerInputHandler { get; private set; }
    public Rigidbody2D PlayerRB { get; private set; }
    public Transform PlayerDashDirectionIndicator { get; private set; }
    public BoxCollider2D PlayerHitBox { get; private set; }
    public HealthBarScript healthBar;
    
    #endregion

    #region Other Variables

    private Vector2 _velocityWorkspace;

    private PlayerWeapon _primaryWeapon;
    private PlayerWeapon _secondaryWeapon;
    #endregion
    
    #region Unity Functions
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();

        _primaryWeapon = transform.Find("PrimaryWeapon").GetComponent<PlayerWeapon>();
        _secondaryWeapon = transform.Find("SecondaryWeapon").GetComponent<PlayerWeapon>();
        
        PlayerStateMachine = new PlayerStateMachine();

        PlayerIdleState = new PlayerIdleState(this, PlayerStateMachine, _playerData, "idle");
        PlayerMoveState = new PlayerMoveState(this, PlayerStateMachine, _playerData, "move");
        PlayerJumpState = new PlayerJumpState(this, PlayerStateMachine, _playerData, "inAir");
        PlayerInAirState = new PlayerInAirState(this, PlayerStateMachine, _playerData, "inAir");
        PlayerLandState = new PlayerLandState(this, PlayerStateMachine, _playerData, "land");
        PlayerWallSlideState = new PlayerWallSlideState(this, PlayerStateMachine, _playerData, "wallSlide");
        PlayerWallGrabState = new PlayerWallGrabState(this, PlayerStateMachine, _playerData, "wallGrab");
        PlayerWallClimbState = new PlayerWallClimbState(this, PlayerStateMachine, _playerData, "wallClimb");
        PlayerWallJumpState = new PlayerWallJumpState(this, PlayerStateMachine, _playerData, "inAir");
        PlayerLedgeClimbState = new PlayerLedgeClimbState(this, PlayerStateMachine, _playerData, "ledgeClimbState");
        PlayerDashState = new PlayerDashState(this, PlayerStateMachine, _playerData, "inAir");
        PlayerCrouchIdleState = new PlayerCrouchIdleState(this, PlayerStateMachine, _playerData, "crouchIdle");
        PlayerCrouchMoveState = new PlayerCrouchMoveState(this, PlayerStateMachine, _playerData, "crouchMove");
        PlayerPrimaryAttackState = new PlayerAttackState(this, PlayerStateMachine, _playerData, "attack", _primaryWeapon);
        PlayerSecondaryAttackState = new PlayerAttackState(this, PlayerStateMachine, _playerData, "attack", _secondaryWeapon);
        PlayerGrappleHookState = new PlayerGrappleHookState(this, PlayerStateMachine, _playerData, "grappleHook");
    }

    private void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        PlayerInputHandler = GetComponent<PlayerInputHandler>();
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerDashDirectionIndicator = transform.Find("PlayerDashDirectionIndicator");
        PlayerHitBox = GetComponent<BoxCollider2D>();
        healthBar.SetMaxHealth(StatsComponent._maxEntityHealth);

        PlayerStateMachine.InitializeStateMachine(PlayerIdleState);
    }

    private void Update()
    {
        Core.EveryFrameUpdate();
        PlayerStateMachine.PlayerCurrentState.EveryFrameUpdate();
        healthBar.SetHealth(StatsComponent._currentEntityHealth);
    }

    private void FixedUpdate()
    {
        PlayerStateMachine.PlayerCurrentState.PhysicsUpdate();
    }
    #endregion

    #region Other Functions

    public void SetPlayerHitBoxHeight(float height)
    {
        Vector2 hitBoxCentre = PlayerHitBox.offset;
        _velocityWorkspace.Set(PlayerHitBox.size.x, height);

        hitBoxCentre.y += (height - PlayerHitBox.size.y) / 2;
        
        PlayerHitBox.size = _velocityWorkspace;
        PlayerHitBox.offset = hitBoxCentre;
    }
    

    private void PlayerAnimationTrigger() => PlayerStateMachine.PlayerCurrentState.PlayerAnimationTrigger();

    private void PlayerAnimationFinishTrigger() => PlayerStateMachine.PlayerCurrentState.PlayerAnimationFinishTrigger();
    
    
    #endregion
}
