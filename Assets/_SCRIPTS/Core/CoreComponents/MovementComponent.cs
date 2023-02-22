using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : CoreComponent
{
    public Rigidbody2D Rigidbody { get; private set; }
    
    public int EntityFacingDirection { get; private set; }
    
    public Vector2 EntityCurrentVelocity { get; private set; }
    
    private Vector2 _velocityWorkspace;

    protected override void Awake()
    {
        base.Awake();

        EntityFacingDirection = 1;

        Rigidbody = GetComponentInParent<Rigidbody2D>();
    }

    public void EveryFrameUpdate()
    {
        EntityCurrentVelocity = Rigidbody.velocity;
    }

    #region Set Functions

    public void SetEntityVelocityZero()
    {
        Rigidbody.velocity = Vector2.zero;
        EntityCurrentVelocity = Vector2.zero;
    }

    public void SetEntityVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        _velocityWorkspace.Set(angle.x * velocity * direction, angle.y * velocity);
        Rigidbody.velocity = _velocityWorkspace;
        EntityCurrentVelocity = _velocityWorkspace;
    }

    public void SetEntityVelocity(float velocity, Vector2 direction)
    {
        _velocityWorkspace = direction * velocity;
        Rigidbody.velocity = _velocityWorkspace;
        EntityCurrentVelocity = _velocityWorkspace;
    }
    
    public void SetEntityVelocityX(float velocity)
    {
        _velocityWorkspace.Set(velocity, EntityCurrentVelocity.y);
        Rigidbody.velocity = _velocityWorkspace;
        EntityCurrentVelocity = _velocityWorkspace;
    }

    public void SetEntityVelocityY(float velocity)
    {
        _velocityWorkspace.Set(EntityCurrentVelocity.x, velocity);
        Rigidbody.velocity = _velocityWorkspace;
        EntityCurrentVelocity = _velocityWorkspace;
    }
    
    public void CheckIfEntityShouldFlip(int playerXInput)
    {
        if (playerXInput != 0 && playerXInput != EntityFacingDirection)
        {
            EntityFlip();
        }
    }
    
    public void EntityFlip()
    {
        EntityFacingDirection *= -1;
        Rigidbody.transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    
    #endregion
}
