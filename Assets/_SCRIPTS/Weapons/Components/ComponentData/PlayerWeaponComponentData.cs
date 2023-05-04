using System;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    [Serializable]
    public class PlayerWeaponComponentData
    {
        [SerializeField, HideInInspector] private string name;

        public PlayerWeaponComponentData()
        {
            SetWeaponComponentName();
        }

        public void SetWeaponComponentName() => name = GetType().Name;

        public virtual void SetAttackDataNames()
        {
            
        }

        public virtual void InitializeWeaponAttackData(int numberOfAttacks)
        {
            
        }
    }
    
    [Serializable]
    public class PlayerWeaponComponentData<T> : PlayerWeaponComponentData where T : PlayerWeaponAttackData
    {
        [SerializeField] private T[] _weaponAttackData;
        
        public T[] WeaponAttackData { get => _weaponAttackData; private set => _weaponAttackData = value; }

        public override void SetAttackDataNames()
        {
            base.SetAttackDataNames();
            
            for (var i = 0; i < WeaponAttackData.Length; i++)
            {
                WeaponAttackData[i].SetWeaponAttackName(i + 1);
            }
        }

        public override void InitializeWeaponAttackData(int numberOfAttacks)
        {
            base.InitializeWeaponAttackData(numberOfAttacks);

            var oldLength = _weaponAttackData != null ? _weaponAttackData.Length : 0;

            if (oldLength == numberOfAttacks)
            {
                return;
            }
            
            Array.Resize(ref _weaponAttackData, numberOfAttacks);

            if (oldLength < numberOfAttacks)
            {
                for (int i = oldLength; i < _weaponAttackData.Length; i++)
                {
                    var newObject = Activator.CreateInstance(typeof(T)) as T;
                    _weaponAttackData[i] = newObject;
                }
            }
            
            SetAttackDataNames();
        }
    }
}