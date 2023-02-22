using System;
using UnityEngine;

public class WeaponHitBoxToWeapon : MonoBehaviour
{
    private AggressiveWeapon _weapon;

    private void Awake()
    {
        _weapon = GetComponentInParent<AggressiveWeapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        _weapon.AddToDetected(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OnTriggerExit2D");
        _weapon.RemoveFromDetected(collision);
    }
}