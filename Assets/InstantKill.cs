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
            
            DamageInterface damageInterface = other.GetComponentInChildren<DamageInterface>();
            
            if (damageInterface == null) return;

            damageInterface.InstantKill();
        }
    }
}
