using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreComponent
{
    public Transform PlayerGroundCheck { get => _playerGroundCheck; private set => _playerGroundCheck = value; }
    public Transform PlayerWallCheck { get => _playerWallCheck; private set => _playerWallCheck = value; }
    public Transform PlayerLedgeCheck { get => _playerLedgeCheck; private set => _playerLedgeCheck = value; }
    public Transform PlayerCeilingCheck { get => _playerCeilingCheck; private set => _playerCeilingCheck = value; }
    public float PlayerGroundCheckRadius { get => _playerGroundCheckRadius; set => _playerGroundCheckRadius = value; }
    public float PlayerWallCheckDistance { get => _playerWallCheckDistance; set => _playerWallCheckDistance = value; }
    public LayerMask WhatIsGround { get => _whatIsGround; set => _whatIsGround = value; }
    
    [SerializeField] private Transform _playerGroundCheck;
    [SerializeField] private Transform _playerWallCheck;
    [SerializeField] private Transform _playerLedgeCheck;
    [SerializeField] private Transform _playerCeilingCheck;

    [SerializeField] private float _playerGroundCheckRadius;
    [SerializeField] private float _playerWallCheckDistance;
    [SerializeField] private LayerMask _whatIsGround;
    
    #region Player Check Functions
    
    public bool CheckForCeiling
    {
        get => Physics2D.OverlapCircle(_playerCeilingCheck.position, _playerGroundCheckRadius, _whatIsGround);
    }

    public bool CheckIfPlayerGrounded
    {
        get => Physics2D.OverlapCircle(_playerGroundCheck.position, _playerGroundCheckRadius, _whatIsGround);
    }

    public bool CheckIfPlayerTouchesWall
    {
        get => Physics2D.Raycast(_playerWallCheck.position, Vector2.right * core.MovementComponent.PlayerFacingDirection, _playerWallCheckDistance, _whatIsGround);
    }
    
    public bool CheckIfPlayerTouchesWallBehind
    {
        get => Physics2D.Raycast(_playerWallCheck.position, Vector2.right * -core.MovementComponent.PlayerFacingDirection, _playerWallCheckDistance, _whatIsGround);
    }

    public bool CheckIfPlayerTouchesLedge
    {
        get => Physics2D.Raycast(_playerLedgeCheck.position, Vector2.right * core.MovementComponent.PlayerFacingDirection,
            _playerWallCheckDistance, _whatIsGround);
    }
    
    
    #endregion
}
