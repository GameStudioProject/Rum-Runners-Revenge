using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AggressiveWeapon : Weapon
{
    protected SO_AggressiveWeaponData _aggressiveWeaponData;
    
    private List<DamageInterface> _damageInterfaceDetectable = new List<DamageInterface>();
    private List<KnockbackInterface> _knockbackInterfaceDetectable = new List<KnockbackInterface>();

    protected override void Awake()
    {
        base.Awake();

        if (_playerWeaponData.GetType() == typeof(SO_AggressiveWeaponData))
        {
            _aggressiveWeaponData = (SO_AggressiveWeaponData)_playerWeaponData;
        }
        else
        {
            Debug.LogError("Wrong data for the weapon");
        }
    }

    public override void AnimationPlayerActionTrigger()
    {
        base.AnimationPlayerActionTrigger();
        
        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = _aggressiveWeaponData.AttackDetails[_playerAttackCounter];
        
        foreach (DamageInterface item in _damageInterfaceDetectable.ToList())
        {
            item.Damage(details.damageAmount);
        }

        foreach (KnockbackInterface item in _knockbackInterfaceDetectable.ToList())
        {
            item.Knockback(details.knockbackAngle, details.knockbackStrength, _core.MovementComponent.EntityFacingDirection);
        }
    }

    public void AddToDetected(Collider2D hitBox)
    {

        DamageInterface damageable = hitBox.GetComponent<DamageInterface>();

        if (damageable != null)
        {
            _damageInterfaceDetectable.Add(damageable);
        }

        KnockbackInterface knockbackable = hitBox.GetComponent<KnockbackInterface>();

        if (knockbackable != null)
        {
            _knockbackInterfaceDetectable.Add(knockbackable);
        }
    }

    public void RemoveFromDetected(Collider2D hitBox)
    {

        DamageInterface damageable = hitBox.GetComponent<DamageInterface>();

        if (damageable != null)
        {
            _damageInterfaceDetectable.Remove(damageable);
        }
        
        KnockbackInterface knockbackable = hitBox.GetComponent<KnockbackInterface>();

        if (knockbackable != null)
        {
            _knockbackInterfaceDetectable.Remove(knockbackable);
        }
    }
}
