using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AggressiveWeapon : Weapon
{
    protected SO_AggressiveWeaponData _aggressiveWeaponData;
    
    private List<DamageInterface> _damageInterfaceDetectable = new List<DamageInterface>();

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
        
        
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = _aggressiveWeaponData.AttackDetails[_playerAttackCounter];
        
        foreach (DamageInterface item in _damageInterfaceDetectable.ToList())
        {
            item.Damage(details.damageAmount);
        }
    }

    public void AddToDetected(Collider2D hitBox)
    {
        Debug.Log("AddToDetected");
        
        DamageInterface damageable = hitBox.GetComponent<DamageInterface>();

        if (damageable != null)
        {
            Debug.Log("Added");
            _damageInterfaceDetectable.Add(damageable);
        }
    }

    public void RemoveFromDetected(Collider2D hitBox)
    {
        Debug.Log("RemoveFromDetected");
        
        DamageInterface damageable = hitBox.GetComponent<DamageInterface>();

        if (damageable != null)
        {
            Debug.Log("Removed");
            _damageInterfaceDetectable.Remove(damageable);
        }
    }
}
