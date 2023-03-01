using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Rendering;
using UnityEngine;

public class InstantKill : MonoBehaviour, DamageInterface
{
    private StatsComponent statsComponent;
    
    private void Awake()
    {
        statsComponent = GameObject.FindWithTag("Player").GetComponentInChildren<StatsComponent>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageInterface damageable = collision.GetComponent<DamageInterface>();
        
        if (collision.CompareTag("Player"))
        {
            damageable.Damage(statsComponent._maxEntityHealth);
        }
    }
}