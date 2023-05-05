using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tomas
{
    public class InstantKill : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") == false) return;
            
            StatsComponent statsComponent = other.GetComponentInChildren<StatsComponent>();
            DamageInterface damageInterface = other.GetComponentInChildren<DamageInterface>();
            
            if (statsComponent == null || damageInterface == null) return;

            damageInterface.Damage(statsComponent.EntityHealth.StatMaxValue);
        }
    }
}
