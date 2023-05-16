using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Tomas.Core.CoreComponents
{
    public class CoreDamageReceiver : CoreComponent, DamageInterface
    {
        [SerializeField] private GameObject _damageParticles;

        
        public void Damage(float _damageAmount)
        {
            GameObject.Find("Damage Audio").GetComponent<AudioSource>().Play();
            Debug.Log(core.transform.parent.name + " Damaged!");
            entityFX.StartCoroutine("FlashHitFX");
            coreStats.EntityHealth.DecreaseStat(_damageAmount);
            coreParticleManager.SpawnParticles(_damageParticles);
            
        }

        public void InstantKill()
        {
            coreStats.EntityHealth.DecreaseStat(coreStats.EntityHealth.StatMaxValue);
        }
    }
}