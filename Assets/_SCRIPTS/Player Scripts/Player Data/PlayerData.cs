using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Player Movement State Data")] 
    public float playerMovementSpeed = 10f;
    
    [Header("Player Jump State Data")]
    public float playerJumpVelocity = 15f;
    public int playerJumps = 1;

    [Header("Player Wall Jump State Data")]
    public float playerWallJumpStrength = 20f;
    public float playerWallJumpTime = 0.4f;
    public Vector2 playerWallJumpAngle = new Vector2(1, 2);

    [Header("Player In Air State Data")] 
    public float playerCoyoteTime = 0.2f;
    public float playerJumpHeightStrength = 0.5f;

    [Header("Player Wall Slide State Data")]
    public float playerWallSlideSpeed = 3f;

    [Header("Player Wall Climb State Data")]
    public float playerWallClimbSpeed = 3f;

    [Header("Player Ledge Climb State Data")]
    public Vector2 playerStartOffset;
    public Vector2 playerStopOffset;

    [Header("Player Dash State Data")] 
    public float playerDashCooldown = 0.5f;
    public float maxDashHoldTime = 1f;
    public float slowMotionTimeScale = 0.25f;
    public float playerDashTime = 0.2f;
    public float playerDashSpeed = 30f;
    public float playerAirDrag = 10f;
    public float playerDashHeightMultiplier = 0.2f;
    public float playerAfterImageDistance = 0.5f;

    [Header("Player Crouch States Data")] 
    public float playerCrouchMoveSpeed = 5f;
    public float playerCrouchHitBoxHeight = 0.8f;
    public float playerStandHitBoxHeight = 1.6f;

    [Header("Player Grapple Hook State Data")]
    public float playerGrappleSpeed = 5f;
    public float playerGrappleHookStopDistance = 10f;

}
