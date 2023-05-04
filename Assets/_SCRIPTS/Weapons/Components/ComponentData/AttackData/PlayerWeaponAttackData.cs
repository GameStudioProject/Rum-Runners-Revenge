using UnityEngine;

namespace Tomas.Weapons.Components
{
    public class PlayerWeaponAttackData
    {
        [SerializeField, HideInInspector] private string name;

        public void SetWeaponAttackName(int i) => name = $"Attack {i}";
    }
}