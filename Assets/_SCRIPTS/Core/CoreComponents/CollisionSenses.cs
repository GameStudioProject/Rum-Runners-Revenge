using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CollisionSenses : CoreComponent
{
    protected MovementComponent MovementComponent
    {
        get => _movementComponent ??= core.GetCoreComponent<MovementComponent>();
    }

    private MovementComponent _movementComponent;
    
    public Transform EntityGroundCheck
    {
        get => GenericCoreNotImplementedError<Transform>.TryGet(_entityGroundCheck, transform.parent.name);
        private set => _entityGroundCheck = value;
    }

    public Transform EntityWallCheck { 
        get => GenericCoreNotImplementedError<Transform>.TryGet(_entityWallCheck, transform.parent.name);
        private set => _entityWallCheck = value;
    }
    public Transform EntityLedgeCheckHorizontal {
        get => GenericCoreNotImplementedError<Transform>.TryGet(_entityLedgeCheckHorizontal, transform.parent.name);
        private set => _entityLedgeCheckHorizontal = value;
    }
    public Transform EntityLedgeCheckVertical { 
        get => GenericCoreNotImplementedError<Transform>.TryGet(_entityLedgeCheckVertical, transform.parent.name);
        private set => _entityLedgeCheckVertical = value;
    }
    public Transform EntityCeilingCheck { 
        get => GenericCoreNotImplementedError<Transform>.TryGet(_entityCeilingCheck, transform.parent.name);
        private set => _entityCeilingCheck = value; 
    }
    public float EntityGroundCheckRadius { get => _entityGroundCheckRadius; set => _entityGroundCheckRadius = value; }
    public float EntityWallCheckDistance { get => _entityWallCheckDistance; set => _entityWallCheckDistance = value; }
    public LayerMask WhatIsGround { get => _whatIsGround; set => _whatIsGround = value; }
    
    [SerializeField] private Transform _entityGroundCheck;
    [SerializeField] private Transform _entityWallCheck;
    [SerializeField] private Transform _entityLedgeCheckHorizontal;
    [SerializeField] private Transform _entityLedgeCheckVertical;
    [SerializeField] private Transform _entityCeilingCheck;
    [SerializeField] private float _entityGroundCheckRadius;
    [SerializeField] private float _entityWallCheckDistance;
    [SerializeField] private LayerMask _whatIsGround;
    
    #region Player Check Functions
    
    public bool CheckForCeiling
    {
        get => Physics2D.OverlapCircle(EntityCeilingCheck.position, _entityGroundCheckRadius, _whatIsGround);
    }

    public bool CheckIfEntityGrounded
    {
        get => Physics2D.OverlapCircle(EntityGroundCheck.position, _entityGroundCheckRadius, _whatIsGround);
    }

    public bool CheckIfEntityTouchesWall
    {
        get => Physics2D.Raycast(EntityWallCheck.position, Vector2.right * MovementComponent.EntityFacingDirection, _entityWallCheckDistance, _whatIsGround);
    }
    
    public bool CheckIfEntityTouchesWallBehind
    {
        get => Physics2D.Raycast(EntityWallCheck.position, Vector2.right * -MovementComponent.EntityFacingDirection, _entityWallCheckDistance, _whatIsGround);
    }

    public bool CheckIfEntityTouchesLedgeHorizontal
    {
        get => Physics2D.Raycast(EntityLedgeCheckHorizontal.position, Vector2.right * MovementComponent.EntityFacingDirection, _entityWallCheckDistance, _whatIsGround);
    }

    public bool CheckIfEntityTouchesLedgeVertical
    {
        get => Physics2D.Raycast(EntityLedgeCheckVertical.position, Vector2.down, _entityWallCheckDistance, _whatIsGround);
    }
    
    
    #endregion
}
