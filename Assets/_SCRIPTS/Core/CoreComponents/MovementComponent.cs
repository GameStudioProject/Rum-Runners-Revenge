using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : CoreComponent
{
    public Rigidbody2D PlayerRB { get; private set; }
    
    public int PlayerFacingDirection { get; private set; }
    
    public Vector2 PlayerCurrentVelocity { get; private set; }
    
    private Vector2 _velocityWorkspace;

    protected override void Awake()
    {
        base.Awake();

        PlayerFacingDirection = 1;

        PlayerRB = GetComponentInParent<Rigidbody2D>();
    }

    public void EveryFrameUpdate()
    {
        PlayerCurrentVelocity = PlayerRB.velocity;
    }

    #region Set Functions

    public void SetPlayerVelocityZero()
    {
        PlayerRB.velocity = Vector2.zero;
        PlayerCurrentVelocity = Vector2.zero;
    }

    public void SetPlayerVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        _velocityWorkspace.Set(angle.x * velocity * direction, angle.y * velocity);
        PlayerRB.velocity = _velocityWorkspace;
        PlayerCurrentVelocity = _velocityWorkspace;
    }

    public void SetPlayerVelocity(float velocity, Vector2 direction)
    {
        _velocityWorkspace = direction * velocity;
        PlayerRB.velocity = _velocityWorkspace;
        PlayerCurrentVelocity = _velocityWorkspace;
    }
    
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
    
    public void CheckIfPlayerShouldFlip(int playerXInput)
    {
        if (playerXInput != 0 && playerXInput != PlayerFacingDirection)
        {
            PlayerFlip();
        }
    }
    
    public void PlayerFlip()
    {
        PlayerFacingDirection *= -1;
        PlayerRB.transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    
    #endregion
}
