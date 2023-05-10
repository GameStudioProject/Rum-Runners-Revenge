using System;
using System.Collections;
using System.Collections.Generic;
using Tomas.Core;
using Tomas.Core.CoreComponents;
using Tomas.Core.CoreStatsSystem;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider _slider;
    private MovementComponent _movementComponent;
    private CoreDamageReceiver _coreDamageReceiver;
    private StatsComponent _stats;
    private Core _core;
    private RectTransform _uiRectTransform;
    
    private void Start()
    {
        _core = GetComponentInParent<Core>();
        _movementComponent = _core.GetCoreComponent<MovementComponent>();
        _coreDamageReceiver = _core.GetCoreComponent<CoreDamageReceiver>();
        _stats = _core.GetCoreComponent<StatsComponent>();
        _uiRectTransform = GetComponent<RectTransform>();
        _slider = GetComponentInChildren<Slider>();

        _movementComponent.onEntityFlipped += FlipEntityUI;
        _coreDamageReceiver.onEntityHealthChange += UpdateEntityHealthUI;

    }

    private void UpdateEntityHealthUI()
    {
        _slider.maxValue = _stats.EntityHealth.StatMaxValue;
        _slider.value = _stats.EntityHealth.StatCurrentValue;
    }

    private void FlipEntityUI() => _uiRectTransform.Rotate(0, 180, 0);

    private void OnDisable()
    {
        _movementComponent.onEntityFlipped -= FlipEntityUI;
        _coreDamageReceiver.onEntityHealthChange -= UpdateEntityHealthUI;
    }
}
