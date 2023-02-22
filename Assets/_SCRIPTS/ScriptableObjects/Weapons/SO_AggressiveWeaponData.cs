using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAggressiveWeaponData", menuName = "Data/Weapon Data/Aggressive Weapon")]
public class SO_AggressiveWeaponData : SO_WeaponData
{
    [SerializeField] private WeaponAttackDetails[] _attackDetails;
    
    public WeaponAttackDetails[] AttackDetails
    {
        get => _attackDetails;
        private set => _attackDetails = value;
    }

    private void OnEnable()
    {
        amountOfAttacks = _attackDetails.Length;

        weaponMovementSpeed = new float[amountOfAttacks];

        for (int i = 0; i < amountOfAttacks; i++)
        {
            weaponMovementSpeed[i] = _attackDetails[i].movementSpeed;
        }
    }
}
