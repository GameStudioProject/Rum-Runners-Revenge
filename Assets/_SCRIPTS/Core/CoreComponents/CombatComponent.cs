using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatComponent : CoreComponent, DamageInterface, KnockbackInterface
{
    [SerializeField] private GameObject _damageParticles;
    
    protected MovementComponent MovementComponent
    {
        get => _movementComponent ??= core.GetCoreComponent<MovementComponent>();
    }
    protected CollisionSenses CollisionSenses
    {
        get => _collisionSenses ??= core.GetCoreComponent<CollisionSenses>();
    }
    
    protected StatsComponent StatsComponent
    {
        get => _statsComponent ??= core.GetCoreComponent<StatsComponent>();
    }
    protected ParticleManagerComponent ParticleManagerComponent
    {
        get => _particleManagerComponent ??= core.GetCoreComponent<ParticleManagerComponent>();
    }
    
    private MovementComponent _movementComponent;
    private CollisionSenses _collisionSenses;
    private StatsComponent _statsComponent;
    private ParticleManagerComponent _particleManagerComponent;
    
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
        StatsComponent?.DecreaseHealth(_damageAmount);
        ParticleManagerComponent?.SpawnParticles(_damageParticles);
    }

    public void Knockback(Vector2 angle, float strength, int direction)
    {
        MovementComponent?.SetEntityVelocity(strength, angle, direction);
        MovementComponent.CanSetEntityVelocity = false;
        _isEntityKnockbackActive = true;
        _knockbackStartTime = Time.time;
    }

    private void CheckEntityKnockback()
    {
        if (_isEntityKnockbackActive && ((MovementComponent?.EntityCurrentVelocity.y <= 0.01f && CollisionSenses.CheckIfEntityGrounded) || Time.time >= _knockbackStartTime + _maxKnockbackTime))
        {
            _isEntityKnockbackActive = false;
            MovementComponent.CanSetEntityVelocity = true;
        }
    }
}
