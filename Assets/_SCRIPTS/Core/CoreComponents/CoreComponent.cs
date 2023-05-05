using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MonoBehaviour, LogicUpdateInterface
{
    protected Core core;
    protected MovementComponent coreMovement;
    protected CollisionSenses coreCollisionSenses;
    protected DeathComponent coreDeath;
    protected StatsComponent coreStats;
    protected ParticleManagerComponent coreParticleManager;

    protected virtual void Awake()
    {
        core = transform.parent.GetComponent<Core>();

        if (core == null)
        {
            Debug.LogError("Core is missing on parent game object");
        }
        core.AddCoreComponent(this);

        coreMovement = core.GetCoreComponent<MovementComponent>();
        coreCollisionSenses = core.GetCoreComponent<CollisionSenses>();
        coreDeath = core.GetCoreComponent<DeathComponent>();
        coreStats = core.GetCoreComponent<StatsComponent>();
        coreParticleManager = core.GetCoreComponent<ParticleManagerComponent>();
    }

    public virtual void LogicUpdate()
    {
        
    }
}
