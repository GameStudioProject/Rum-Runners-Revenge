using System;
using Tomas.Core.CoreStatsSystem;
using UnityEngine;

public class StatsComponent : CoreComponent
{
    [field: SerializeField] public CoreStatSystem EntityHealth { get; private set; }
    [field: SerializeField] public CoreStatSystem EntityPoise { get; private set; }

    [SerializeField] private float _entityPoiseRecoveryRate;
    
    protected override void Awake()
    {
        base.Awake();
        
        EntityHealth.StatInit();
        EntityPoise.StatInit();
    }

    private void Update()
    {
        if (EntityPoise.StatCurrentValue.Equals(EntityPoise.StatMaxValue))
            return;
        
        EntityPoise.IncreaseStat(_entityPoiseRecoveryRate * Time.deltaTime);
    }
}
