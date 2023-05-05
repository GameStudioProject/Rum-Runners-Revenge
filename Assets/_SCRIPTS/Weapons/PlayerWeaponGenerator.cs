using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Tomas.Weapons.Components;

namespace Tomas.Weapons
{
    public class PlayerWeaponGenerator : MonoBehaviour
    {
        [SerializeField] private PlayerWeapon _playerWeapon;
        [SerializeField] private PlayerWeaponDataSO data;

        private List<PlayerWeaponComponent> _componentsAlreadyOnWeapon = new List<PlayerWeaponComponent>();

        private List<PlayerWeaponComponent> _componentsAddedToWeapon = new List<PlayerWeaponComponent>();

        private List<Type> _weaponComponentDependencies = new List<Type>();

        private void Start()
        {
            GeneratePlayerWeapon(data);
        }
        
        [ContextMenu("Test Generate")]
        private void TestGeneration()
        {
            GeneratePlayerWeapon(data);
        }
        
        public void GeneratePlayerWeapon(PlayerWeaponDataSO data)
        {
            _playerWeapon.SetWeaponData(data);
            
            _componentsAlreadyOnWeapon.Clear();
            _componentsAddedToWeapon.Clear();
            _weaponComponentDependencies.Clear();

            _componentsAlreadyOnWeapon = GetComponents<PlayerWeaponComponent>().ToList();

            _weaponComponentDependencies = data.GetAllWeaponDependencies();

            foreach (var dependency in _weaponComponentDependencies)
            {
                if (_componentsAddedToWeapon.FirstOrDefault(component => component.GetType() == dependency))
                    continue;

                var weaponComponent = _componentsAlreadyOnWeapon.FirstOrDefault(component => component.GetType() == dependency);

                if (weaponComponent == null)
                {
                    weaponComponent = gameObject.AddComponent(dependency)as PlayerWeaponComponent;
                }
                
                weaponComponent.WeaponInit();
                
                _componentsAddedToWeapon.Add(weaponComponent);
            }

            var weaponComponentsToRemove = _componentsAlreadyOnWeapon.Except(_componentsAddedToWeapon);

            foreach (var weaponComponent in weaponComponentsToRemove)
            {
                Destroy(weaponComponent);
            }
        }
    }
}