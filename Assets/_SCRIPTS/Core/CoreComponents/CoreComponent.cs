using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MonoBehaviour, LogicUpdateInterface
{
    protected Core core;
    protected CoreAccessComponent<MovementComponent> movementComponent;
    protected CoreAccessComponent<CollisionSenses> collisionSenses;
    protected CoreAccessComponent<CombatComponent> combatComponent;
    protected CoreAccessComponent<DeathComponent> deathComponent;
    protected CoreAccessComponent<StatsComponent> statsComponent;
    protected CoreAccessComponent<ParticleManagerComponent> particleManagerComponent;

    protected virtual void Awake()
    {
        core = transform.parent.GetComponent<Core>();

        if (core == null)
        {
            Debug.LogError("Core is missing on parent game object");
        }
        core.AddCoreComponent(this);
        
        movementComponent = new CoreAccessComponent<MovementComponent>(core);
        collisionSenses = new CoreAccessComponent<CollisionSenses>(core);
        combatComponent = new CoreAccessComponent<CombatComponent>(core);
        deathComponent = new CoreAccessComponent<DeathComponent>(core);
        statsComponent = new CoreAccessComponent<StatsComponent>(core);
        particleManagerComponent = new CoreAccessComponent<ParticleManagerComponent>(core);
    }

    public virtual void LogicUpdate()
    {
        
    }
}
