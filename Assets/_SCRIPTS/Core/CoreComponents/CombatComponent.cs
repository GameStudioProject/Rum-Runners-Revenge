using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatComponent : CoreComponent, DamageInterface, KnockbackInterface
{
    private bool _isEntityKnockbackActive;
    private float _knockbackStartTime;

    public void LogicUpdate()
    {
        CheckEntityKnockback();
    }
    
    public void Damage(float _damageAmount)
    {
        Debug.Log(core.transform.parent.name + " Damaged! UWU");
    }

    public void Knockback(Vector2 angle, float strength, int direction)
    {
        core.MovementComponent.SetEntityVelocity(strength, angle, direction);
        core.MovementComponent.CanSetEntityVelocity = false;
        _isEntityKnockbackActive = true;
        _knockbackStartTime = Time.time;
    }

    private void CheckEntityKnockback()
    {
        if (_isEntityKnockbackActive && core.MovementComponent.EntityCurrentVelocity.y <= 0.01f && core.CollisionSenses.CheckIfEntityGrounded)
        {
            _isEntityKnockbackActive = false;
            core.MovementComponent.CanSetEntityVelocity = true;
        }
    }
}
