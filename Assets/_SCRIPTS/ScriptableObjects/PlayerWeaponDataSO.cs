using System.Collections.Generic;
using System.Linq;
using Tomas.Weapons.Components;
using UnityEngine;

namespace Tomas.Weapons
{
    [CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Basic Weapon Data", order = 0)]
    public class PlayerWeaponDataSO : ScriptableObject
    {
        [field: SerializeField] public int NumberOfAttacks { get; private set; }
        
        [field: SerializeReference] public List<PlayerWeaponComponentData> ComponentData { get; private set; }

        public T GetData<T>()
        {
            return ComponentData.OfType<T>().FirstOrDefault();
        }

        [ContextMenu("Add Weapon Sprite Data")]
        private void AddWeaponSpriteData() => ComponentData.Add(new PlayerWeaponSpriteData());
        
        [ContextMenu("Add Weapon Movement Data")]
        private void AddMovementData() => ComponentData.Add(new PlayerWeaponMovementData());
    }
}