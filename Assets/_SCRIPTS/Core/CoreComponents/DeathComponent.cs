using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComponent : CoreComponent
{
    [SerializeField] private GameObject[] deathParticles;

    private ParticleManagerComponent ParticleManagerComponent
    {
        get => _particleManagerComponent ??= core.GetCoreComponent<ParticleManagerComponent>();
    }
    private ParticleManagerComponent _particleManagerComponent;

    private StatsComponent StatsComponent
    {
        get => _statsComponent ??= core.GetCoreComponent<StatsComponent>();
    }
    private StatsComponent _statsComponent;
    
    public void Die()
    {
        foreach (var particle in deathParticles)
        {
            ParticleManagerComponent.SpawnParticles(particle);
        }
        
        core.transform.parent.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StatsComponent.OnHealthZero += Die;
    }

    private void OnDisable()
    {
        StatsComponent.OnHealthZero -= Die;
    }
}
