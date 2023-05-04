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
            ParticleManager.Component.SpawnParticles(particle);
        }
        
        core.transform.parent.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Stats.Component.OnHealthZero += Die;
    }

    private void OnDisable()
    {
        Stats.Component.OnHealthZero -= Die;
    }
}
