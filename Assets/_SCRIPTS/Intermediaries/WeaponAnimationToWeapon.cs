using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationToWeapon : MonoBehaviour
{
    private Weapon _playerWeapon;

    private void Start()
    {
        _playerWeapon = GetComponentInParent<Weapon>();
    }

    private void AnimationFinishTrigger()
    {
        _playerWeapon.AnimationFinishTrigger();
    }

    private void AnimationStartMovementTrigger()
    {
        _playerWeapon.AnimationStartMovementTrigger();
    }

    private void AnimationStopMovementTrigger()
    {
        _playerWeapon.AnimationStopMovementTrigger();
    }

    private void AnimationTurnOffPlayerFlipTrigger()
    {
        _playerWeapon.AnimationTurnOffPlayerFlipTrigger();
    }

    private void AnimationTurnOnPlayerFlipTrigger()
    {
        _playerWeapon.AnimationTurnOnPlayerFlipTrigger();
    }

    private void AnimationPlayerActionTrigger()
    {
        _playerWeapon.AnimationPlayerActionTrigger();
    }
}
