using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : CoreComponent
{
    public Rigidbody2D Rigidbody { get; private set; }
    
    public int EntityFacingDirection { get; private set; }
    
    public bool CanSetEntityVelocity { get; set; }
    
    public Vector2 EntityCurrentVelocity { get; private set; }
    
    private Vector2 _velocityWorkspace;

    protected override void Awake()
    {
        base.Awake();

        EntityFacingDirection = 1;

        Rigidbody = GetComponentInParent<Rigidbody2D>();
        CanSetEntityVelocity = true;
    }

    public override void LogicUpdate()
    {
        EntityCurrentVelocity = Rigidbody.velocity;
    }

    #region Set Functions

    public void SetEntityVelocityZero()
    {
        _velocityWorkspace = Vector2.zero;
        SetFinalEntityVelocity();
    }

    public void SetEntityVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        _velocityWorkspace.Set(angle.x * velocity * direction, angle.y * velocity);
        SetFinalEntityVelocity();
    }

    public void SetEntityVelocity(float velocity, Vector2 direction)
    {
        _velocityWorkspace = direction * velocity;
        SetFinalEntityVelocity();
    }
    
    public void SetEntityVelocityX(float velocity)
    {
        _velocityWorkspace.Set(velocity, EntityCurrentVelocity.y);
        SetFinalEntityVelocity();
    }

    public void SetEntityVelocityY(float velocity)
    {
        _velocityWorkspace.Set(EntityCurrentVelocity.x, velocity);
        SetFinalEntityVelocity();
    }

    public void SetFinalEntityVelocity()
    {
        if (CanSetEntityVelocity)
        {
            Rigidbody.velocity = _velocityWorkspace;
            EntityCurrentVelocity = _velocityWorkspace;
        }
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
