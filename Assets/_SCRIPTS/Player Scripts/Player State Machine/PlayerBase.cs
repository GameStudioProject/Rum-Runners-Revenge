using System;
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
    
    
    [SerializeField] private PlayerData _playerData;
    #endregion

    #region Components
    public Animator PlayerAnimator { get; private set; }
    public PlayerInput PlayerInputHandler { get; private set; }
    public Rigidbody2D PlayerRB { get; private set; }
    #endregion

    #region Check Player Transforms

    [SerializeField] private Transform _playerGroundCheck;
    [SerializeField] private Transform _playerWallCheck;

    #endregion
    
    #region Other Variables
    public Vector2 PlayerCurrentVelocity { get; private set; }
    public int PlayerFacingDirection { get; private set; }
    
    private Vector2 _velocityWorkspace;
    #endregion
    
    #region Unity Functions
    private void Awake()
    {
        PlayerStateMachine = new PlayerStateMachine();

        PlayerIdleState = new PlayerIdleState(this, PlayerStateMachine, _playerData, "idle");
        PlayerMoveState = new PlayerMoveState(this, PlayerStateMachine, _playerData, "move");
        PlayerJumpState = new PlayerJumpState(this, PlayerStateMachine, _playerData, "inAir");
        PlayerInAirState = new PlayerInAirState(this, PlayerStateMachine, _playerData, "inAir");
        PlayerLandState = new PlayerLandState(this, PlayerStateMachine, _playerData, "land");
        PlayerWallSlideState = new PlayerWallSlideState(this, PlayerStateMachine, _playerData, "wallSlide");
        PlayerWallGrabState = new PlayerWallGrabState(this, PlayerStateMachine, _playerData, "wallGrab");
        PlayerWallClimbState = new PlayerWallClimbState(this, PlayerStateMachine, _playerData, "wallClimb");
    }

    private void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        PlayerInputHandler = GetComponent<PlayerInput>();
        PlayerRB = GetComponent<Rigidbody2D>();

        PlayerFacingDirection = 1;
        
        
        PlayerStateMachine.InitializeStateMachine(PlayerIdleState);
    }

    private void Update()
    {
        PlayerCurrentVelocity = PlayerRB.velocity;
        
        PlayerStateMachine.PlayerCurrentState.EveryFrameUpdate();
    }

    private void FixedUpdate()
    {
        PlayerStateMachine.PlayerCurrentState.PhysicsUpdate();
    }
    #endregion

    #region Set Functions

    
    public void SetPlayerVelocityX(float velocity)
    {
        _velocityWorkspace.Set(velocity, PlayerCurrentVelocity.y);
        PlayerRB.velocity = _velocityWorkspace;
        PlayerCurrentVelocity = _velocityWorkspace;
    }

    public void SetPlayerVelocityY(float velocity)
    {
        _velocityWorkspace.Set(PlayerCurrentVelocity.x, velocity);
        PlayerRB.velocity = _velocityWorkspace;
        PlayerCurrentVelocity = _velocityWorkspace;
    }
    
    #endregion

    #region Player Check Functions

    public bool CheckIfPlayerGrounded()
    {
        return Physics2D.OverlapCircle(_playerGroundCheck.position, _playerData.playerGroundCheckRadius, _playerData.whatIsGround);
    }

    public bool CheckIfPlayerTouchesWall()
    {
        return Physics2D.Raycast(_playerWallCheck.position, Vector2.right * PlayerFacingDirection, _playerData.PlayerWallCheckDistance, _playerData.whatIsGround);
    }
    
    public void CheckIfPlayerShouldFlip(int playerXInput)
    {
        if (playerXInput != 0 && playerXInput != PlayerFacingDirection)
        {
            PlayerFlip();
        }
    }
    #endregion
    
    #region Other Functions

    private void PlayerAnimationTrigger() => PlayerStateMachine.PlayerCurrentState.PlayerAnimationTrigger();

    private void PlayerAnimationFinishTrigger() => PlayerStateMachine.PlayerCurrentState.PlayerAnimationFinishTrigger();
    
    public void PlayerFlip()
    {
        PlayerFacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    #endregion
}
