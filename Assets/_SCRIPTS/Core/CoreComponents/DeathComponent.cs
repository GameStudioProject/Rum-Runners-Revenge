using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComponent : CoreComponent
{
    [SerializeField] private GameObject[] deathParticles;
    
    
    public void Die()
    {
        foreach (var particle in deathParticles)
        {
            coreParticleManager.SpawnParticles(particle);
        }
        
        core.transform.parent.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        coreStats.OnHealthZero += Die;
    }

    private void OnDisable()
    {
        coreStats.OnHealthZero -= Die;
    }
}
