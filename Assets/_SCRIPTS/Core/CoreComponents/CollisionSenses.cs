using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CollisionSenses : CoreComponent
{
    public Transform EntityGroundCheck
    {
        get => GenericCoreNotImplementedError<Transform>.TryGet(_entityGroundCheck, transform.parent.name);
        private set => _entityGroundCheck = value;
    }
    
    public Transform EntityGrappleCheck
    {
        get => GenericCoreNotImplementedError<Transform>.TryGet(_entityGrappleCheck, transform.parent.name);
        private set => _entityGrappleCheck = value;
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
    public Transform EntityGrappleStuckCheck {
        get => GenericCoreNotImplementedError<Transform>.TryGet(_entityGrappleStuckCheck, transform.parent.name);
        private set => _entityGrappleStuckCheck = value;
    }
    public Transform EntityDodgeLandZone
    {
        get => GenericCoreNotImplementedError<Transform>.TryGet(_entityDodgeLandZone, transform.parent.name);
        private set => _entityDodgeLandZone = value;
    }

    public Transform EntityPlayerCheck
    {
        get => GenericCoreNotImplementedError<Transform>.TryGet(_entityPlayerCheck, transform.parent.name);
        private set => _entityPlayerCheck = value;
    }
    
    public EnemyBase EnemyBase {get; set; }
    public PlayerBase PlayerBase { get; set; }

    public D_EnemyData EntityData
    {
        get => EnemyBase.enemyData;
    }
    
    public float EntityWallCheckDistance { get => _entityWallCheckDistance; set => _entityWallCheckDistance = value; }
    public LayerMask WhatIsGround { get => _whatIsGround; set => _whatIsGround = value; }
    public LayerMask WhatIsPlayer { get => _whatIsPlayer; set => _whatIsPlayer = value; }
    public LayerMask WhatIsGrappleable { get => _whatisGrappleble; set => _whatisGrappleble = value; }
    
    [SerializeField] private Transform _entityGroundCheck;
    [SerializeField] private Transform _entityWallCheck;
    [SerializeField] private Transform _entityPlayerCheck;
    [SerializeField] public Transform _entityGrappleCheck;
    [SerializeField] private Transform _entityLedgeCheckHorizontal;
    [SerializeField] private Transform _entityLedgeCheckVertical;
    [SerializeField] private Transform _entityCeilingCheck;
    [SerializeField] public Transform _entityGrappleStuckCheck;
    [SerializeField] private Transform _entityDodgeLandZone;
    [SerializeField] private float _entityGroundCheckRadius;
    [SerializeField] private float _entityWallCheckDistance;
    [SerializeField] public float _entityGrappleCheckRadius;
    [SerializeField] public float _entityGrappleStuckRadius;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private LayerMask _whatisGrappleble;

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
        get => Physics2D.Raycast(EntityWallCheck.position, Vector2.right * coreMovement.EntityFacingDirection, _entityWallCheckDistance, _whatIsGround);
    }
    
    public bool CheckIfEntityTouchesWallBehind
    {
        get => Physics2D.Raycast(EntityWallCheck.position, Vector2.right * -coreMovement.EntityFacingDirection, _entityWallCheckDistance, _whatIsGround);
    }

    public bool CheckIfEntityTouchesLedgeHorizontal
    {
        get => Physics2D.Raycast(EntityLedgeCheckHorizontal.position, Vector2.right * coreMovement.EntityFacingDirection, _entityWallCheckDistance, _whatIsGround);
    }

    public bool CheckIfEntityTouchesLedgeVertical
    {
        get => Physics2D.Raycast(EntityLedgeCheckVertical.position, Vector2.down, _entityWallCheckDistance, _whatIsGround);
    }

    public bool CheckEntityDodgeLandZone
    {
        get => Physics2D.Raycast(_entityDodgeLandZone.position, Vector2.down, 3.0f, _whatIsGround);
    }

    public Collider2D[] CheckForGrappleble
    {
        get => Physics2D.OverlapCircleAll(_entityGrappleCheck.transform.position, _entityGrappleCheckRadius, _whatisGrappleble);
    }

    public bool CheckEntityGrappleStuck
    {
        get => Physics2D.OverlapCircle(_entityGrappleStuckCheck.transform.position, _entityGrappleStuckRadius, _whatIsGround);
    }
    
    public virtual bool EnemyCheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(_entityPlayerCheck.position, transform.right, EntityData.enemyMinAgroDistance, _whatIsPlayer);
    }

    public virtual bool EnemyCheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(_entityPlayerCheck.position, transform.right, EntityData.enemyMaxAgroDistance, _whatIsPlayer);
    }

    public virtual bool EnemyCheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(_entityPlayerCheck.position, transform.right, EntityData.enemyCloseRangeActionDistance, _whatIsPlayer);
    }

    #endregion
    
}
