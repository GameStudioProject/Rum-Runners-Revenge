using System;
using UnityEngine;

public class StatsComponent : CoreComponent
{
    public event Action OnHealthZero;

    [SerializeField] public float _maxEntityHealth;
    [SerializeField] public float _maxEntityStamina;
    private float _currentEntityHealth;
    private float _currentEntityStamina;

    protected override void Awake()
    {
        base.Awake();

        _currentEntityHealth = _maxEntityHealth;
        _currentEntityStamina = _maxEntityStamina;
    }

    public void DecreaseHealth(float decreaseAmount)
    {
        _currentEntityHealth -= decreaseAmount;

        if (_currentEntityHealth <= 0)
        {
            _currentEntityHealth = 0;
            
            OnHealthZero?.Invoke();
            
            Debug.Log("Health is zero, u ded bich");
        }
    }

    public void DecreaseStamina(float decreaseAmount)
    {
        _currentEntityStamina -= decreaseAmount;
    }

    public void IncreaseHealth(float increaseAmount)
    {
        _currentEntityHealth = Mathf.Clamp(_currentEntityHealth + increaseAmount, 0, _maxEntityHealth);
    }
}
