using Tomas.Weapons.Components.ComponentData.AttackData;
using UnityEngine;

namespace Tomas.Weapons.Components.ComponentData
{
    public class PlayerWeaponSpriteData : PlayerWeaponComponentData
    {
        [field: SerializeField] public PlayerWeaponAttackSprites[] PlayerAttackData { get; private set; }
    }
}