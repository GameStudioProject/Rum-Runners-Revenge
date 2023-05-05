using System;
using UnityEngine;

namespace Tomas.Core.CoreStatsSystem
{
    [Serializable]
    public class CoreStatSystem
    {
        public event Action OnCurrentStatValueZero;
        
        [field: SerializeField] public float StatMaxValue { get; private set; }

        public float StatCurrentValue
        {
            get => _statCurrentValue;
            private set
            {
                _statCurrentValue = Mathf.Clamp(value, 0f, StatMaxValue);

                if (_statCurrentValue <= 0f)
                {
                    OnCurrentStatValueZero?.Invoke();
                }
            }
        }
        
        private float _statCurrentValue;

        public void StatInit() => StatCurrentValue = StatMaxValue;

        public void IncreaseStat(float amount) => StatCurrentValue += amount;

        public void DecreaseStat(float amount) => StatCurrentValue -= amount;
    }
}