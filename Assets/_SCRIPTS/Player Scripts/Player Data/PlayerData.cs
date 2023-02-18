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

    [Header("Player Check Variables")] 
    public float playerGroundCheckRadius = 0.3f;
    public float PlayerWallCheckDistance = 0.5f;
    public LayerMask whatIsGround;
}
