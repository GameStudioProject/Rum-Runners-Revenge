using UnityEngine;

public class StatsComponent : CoreComponent
{
    [SerializeField] private float _maxEntityHealth;
    private float _currentEntityHealth;

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
            Debug.Log("Health is zero, u ded bich");
        }
    }

    public void IncreaseHealth(float increaseAmount)
    {
        _currentEntityHealth = Mathf.Clamp(_currentEntityHealth + increaseAmount, 0, _maxEntityHealth);
    }
}
