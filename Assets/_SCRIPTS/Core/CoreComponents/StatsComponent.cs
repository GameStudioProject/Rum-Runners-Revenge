using System;
using Tomas.Core.CoreStatsSystem;
using UnityEngine;

public class StatsComponent : CoreComponent
{
    [field: SerializeField] public CoreStatSystem EntityHealth { get; private set; }
    [field: SerializeField] public CoreStatSystem EntityPoise { get; private set; }
    [field: SerializeField] public CoreStatSystem EntityStamina { get; private set; }

    [SerializeField] private float _entityPoiseRecoveryRate;
    [SerializeField] private float _entityStaminaRecoveryRate;
    
    protected override void Awake()
    {
        base.Awake();
        
        EntityHealth.StatInit();
        EntityPoise.StatInit();
        EntityStamina.StatInit();
    }

    private void Update()
    {
        if (EntityPoise.StatCurrentValue.Equals(EntityPoise.StatMaxValue) && EntityStamina.StatCurrentValue.Equals(EntityStamina.StatMaxValue))
            return;
        
        EntityPoise.IncreaseStat(_entityPoiseRecoveryRate * Time.deltaTime);
        EntityStamina.IncreaseStat(_entityStaminaRecoveryRate * Time.deltaTime);
    }
}
