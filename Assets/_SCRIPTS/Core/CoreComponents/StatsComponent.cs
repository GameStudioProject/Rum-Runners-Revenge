using System;
using UnityEngine;

public class StatsComponent : CoreComponent
{
    public event Action OnHealthZero;

    [SerializeField] public float _maxEntityHealth;
    public float _currentEntityHealth { get; private set; }
    public HealthBarScript healthbar;

    protected override void Awake()
    {
        base.Awake();

        _currentEntityHealth = _maxEntityHealth;
    }

    public void DecreaseHealth(float decreaseAmount)
    {
        _currentEntityHealth -= decreaseAmount;

        if (_currentEntityHealth <= 0)
        {
            _currentEntityHealth = 0;

            if (healthbar != null)
            {
                healthbar.SetHealth(_currentEntityHealth);
            }
            
            OnHealthZero?.Invoke();
            
            Debug.Log("Health is zero, u ded bich");
        }
    }

    public void IncreaseHealth(float increaseAmount)
    {
        _currentEntityHealth = Mathf.Clamp(_currentEntityHealth + increaseAmount, 0, _maxEntityHealth);
    }
}
