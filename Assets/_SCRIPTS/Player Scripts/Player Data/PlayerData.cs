using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Movement State Data")] 
    public float playerMovementSpeed = 10f;
    
    [Header("Jump State Data")]
    public float playerJumpVelocity = 15f;

    [Header("Player Check Variables")] 
    public float playerGroundCheckRadius = 0.3f;
    public LayerMask whatIsGround;
}
