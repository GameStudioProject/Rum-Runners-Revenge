using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MonoBehaviour, LogicUpdateInterface
{
    protected Core core;
    protected CoreAccessComponent<MovementComponent> Movement;
    protected CoreAccessComponent<CollisionSenses> CollisionSenses;
    protected CoreAccessComponent<CoreKnockBackReceiver> Combat;
    protected CoreAccessComponent<DeathComponent> Death;
    protected CoreAccessComponent<StatsComponent> Stats;
    protected CoreAccessComponent<ParticleManagerComponent> ParticleManager;

    protected virtual void Awake()
    {
        core = transform.parent.GetComponent<Core>();

        if (core == null)
        {
            Debug.LogError("Core is missing on parent game object");
        }
        core.AddCoreComponent(this);
        
        Movement = new CoreAccessComponent<MovementComponent>(core);
        CollisionSenses = new CoreAccessComponent<CollisionSenses>(core);
        Combat = new CoreAccessComponent<CoreKnockBackReceiver>(core);
        Death = new CoreAccessComponent<DeathComponent>(core);
        Stats = new CoreAccessComponent<StatsComponent>(core);
        ParticleManager = new CoreAccessComponent<ParticleManagerComponent>(core);
    }

    public virtual void LogicUpdate()
    {
        
    }
}
