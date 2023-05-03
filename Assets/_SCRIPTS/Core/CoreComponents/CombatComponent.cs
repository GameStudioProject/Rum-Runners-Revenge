using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatComponent : CoreComponent, DamageInterface, KnockbackInterface
{
    [SerializeField] private GameObject _damageParticles;

    [SerializeField] private float _maxKnockbackTime = 0.2f;
    
    private bool _isEntityKnockbackActive;
    private float _knockbackStartTime;

    public override void LogicUpdate()
    {
        CheckEntityKnockback();
    }
    
    public void Damage(float _damageAmount)
    {
        Debug.Log(core.transform.parent.name + " Damaged! UWU");
        statsComponent.Component.DecreaseHealth(_damageAmount);
        particleManagerComponent.Component.SpawnParticles(_damageParticles);
    }

    public void Knockback(Vector2 angle, float strength, int direction)
    {
        movementComponent.Component.SetEntityVelocity(strength, angle, direction);
        movementComponent.Component.CanSetEntityVelocity = false;
        _isEntityKnockbackActive = true;
        _knockbackStartTime = Time.time;
    }

    private void CheckEntityKnockback()
    {
        if (_isEntityKnockbackActive && ((movementComponent.Component.EntityCurrentVelocity.y <= 0.01f && collisionSenses.Component.CheckIfEntityGrounded) || Time.time >= _knockbackStartTime + _maxKnockbackTime))
        {
            _isEntityKnockbackActive = false;
            movementComponent.Component.CanSetEntityVelocity = true;
        }
    }
}
