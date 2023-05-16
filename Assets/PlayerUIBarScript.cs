using System;
using System.Collections;
using System.Collections.Generic;
using Tomas.Core;
using Tomas.Core.CoreComponents;
using Tomas.Core.CoreStatsSystem;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerUIBarScript : MonoBehaviour
{
    
    public Slider _healthSlider;
    public Slider _staminaSlider;
    private MovementComponent _movementComponent;
    private StatsComponent _stats;
    private Core _core;
    private RectTransform _uiRectTransform;
    
    private void Start()
    {
        _core = GetComponentInParent<Core>();
        _movementComponent = _core.GetCoreComponent<MovementComponent>();
        _stats = _core.GetCoreComponent<StatsComponent>();
        _uiRectTransform = GetComponent<RectTransform>();
        _healthSlider = GetComponentInChildren<Slider>();

        _movementComponent.onEntityFlipped += FlipEntityUI;

    }

    private void Update()
    {
        UpdateEntityUI();
    }

    private void UpdateEntityUI()
    {
        _healthSlider.maxValue = _stats.EntityHealth.StatMaxValue;
        _healthSlider.value = _stats.EntityHealth.StatCurrentValue;
        
        if (_staminaSlider != null)
        {
            _staminaSlider.maxValue = _stats.EntityStamina.StatMaxValue;
            _staminaSlider.value = _stats.EntityStamina.StatCurrentValue;
        }
    }

    private void FlipEntityUI() => _uiRectTransform.Rotate(0, 180, 0);

    private void OnDisable()
    {
        _movementComponent.onEntityFlipped -= FlipEntityUI;
    }
}
